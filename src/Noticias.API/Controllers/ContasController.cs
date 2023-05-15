using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SistemaNoticias.API.Extensions;
using SistemaNoticias.API.ViewModels;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SistemaNoticias.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContasController : ControllerBase
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly AppSettings _appSettings;
        private readonly ILogger _logger;

        public ContasController(SignInManager<IdentityUser> signInManager,
                                UserManager<IdentityUser> userManager,
                                IOptions<AppSettings> appSettings,
                                ILogger<ContasController> logger)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _appSettings = appSettings.Value;
            _logger = logger;
        }

        [HttpPost]
        [Route("nova-conta")]
        public async Task<IActionResult> CriarConta(RegistroUsuarioViewModel registroUsuario)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var usuario = new IdentityUser
            {
                UserName = registroUsuario.Email,
                Email = registroUsuario.Email,
                EmailConfirmed = true
            };

            var result = await _userManager.CreateAsync(usuario, registroUsuario.Password);
            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(usuario, false);
                return Ok(await GerarJwt(usuario.Email));
            }
            foreach (var error in result.Errors)
            {
                BadRequest(error.Description);
            }

            return Ok(registroUsuario);

        }

        [HttpPost("entrar")]
        public async Task<ActionResult> Login(LoginUsuarioViewModel loginUser)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var result = await _signInManager.PasswordSignInAsync(loginUser.Email, loginUser.Password, false, true);

            if (result.Succeeded)
            {
                _logger.LogInformation("Usuario " + loginUser.Email + " logado com sucesso");
                return Ok(await GerarJwt(loginUser.Email));
            }
            if (result.IsLockedOut)
            {
                return BadRequest("Usuário temporariamente bloqueado por tentativas inválidas");
            }

            return BadRequest("Usuário ou Senha incorretos");

        }

        private async Task<LoginRespostaViewModel> GerarJwt(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            var claims = await _userManager.GetClaimsAsync(user);
            var userRoles = await _userManager.GetRolesAsync(user);

            claims.Add(new Claim(JwtRegisteredClaimNames.Sub, user.Id));
            claims.Add(new Claim(JwtRegisteredClaimNames.Email, user.Email));
            claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
            //claims.Add(new Claim(JwtRegisteredClaimNames.Nbf, ToUnixEpochDate(DateTime.UtcNow).ToString()));
            //claims.Add(new Claim(JwtRegisteredClaimNames.Iat, ToUnixEpochDate(DateTime.UtcNow).ToString(), ClaimValueTypes.Integer64));
            foreach (var userRole in userRoles)
            {
                claims.Add(new Claim("role", userRole));
            }

            var identityClaims = new ClaimsIdentity();
            identityClaims.AddClaims(claims);

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var token = tokenHandler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = _appSettings.Emissor,
                Audience = _appSettings.ValidoEm,
                Subject = identityClaims,
                Expires = DateTime.UtcNow.AddHours(_appSettings.ExpiracaoHoras),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            });

            var encodedToken = tokenHandler.WriteToken(token);

            var response = new LoginRespostaViewModel
            {
                TokenAcesso = encodedToken,
                ExpiracaoEm = TimeSpan.FromHours(_appSettings.ExpiracaoHoras).TotalSeconds,
                UsuarioToken = new UsuarioTokenViewModel
                {
                    Id = user.Id,
                    Email = user.Email,
                    Claims = claims.Select(c => new ClaimViewModel { Tipo = c.Type, Valor = c.Value })
                }
            };

            return response;
        }
    }
}
