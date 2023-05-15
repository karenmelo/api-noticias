using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaNoticias.API.ViewModels;
using SistemaNoticias.Domain.Entities;
using SistemaNoticias.Domain.Repository;

namespace SistemaNoticias.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class NoticiaController : ControllerBase
    {
        private readonly INoticiasRepository _noticiasRepository;
        private readonly IMapper _mapper;

        public NoticiaController(INoticiasRepository noticiasRepository, IMapper mapper)
        {
            _noticiasRepository = noticiasRepository;
            _mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> CadastrarNoticia(NoticiaViewModel noticia)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            _noticiasRepository.Cadastrar(_mapper.Map<Noticia>(noticia));
            return Ok(noticia);
        }

        [HttpGet]
        public async Task<IActionResult> ListarNoticias()
        {
            return Ok(_mapper.Map<NoticiaViewModel>(await _noticiasRepository.Listar()));
        }
    }
}
