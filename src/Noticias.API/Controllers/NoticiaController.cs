using Microsoft.AspNetCore.Mvc;

namespace Noticias.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NoticiaController : Controller
    {
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Cadastrar()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> ListarNoticias()
        {
            return View();
        }
    }
}
