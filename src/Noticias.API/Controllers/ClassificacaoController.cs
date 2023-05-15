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
    public class ClassificacaoController : ControllerBase
    {
        private readonly IClassificacaoNoticiasRepository _classificacaoNoticiasrepository;
        private readonly IMapper _mapper;

        public ClassificacaoController(IClassificacaoNoticiasRepository classificacaoNoticiasrepository, IMapper mapper)
        {
            _classificacaoNoticiasrepository = classificacaoNoticiasrepository;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("nova-classificacao")]
        public async Task<IActionResult> CadastrarTiposDeClassificacao(ClassificacaoViewModel classificacao)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            _classificacaoNoticiasrepository.Cadastrar(_mapper.Map<Classificacao>(classificacao));
            return Ok();
        }


        [HttpGet]
        public async Task<IActionResult> ListarTiposDeClassificacoes()
        {
            var lista = await _classificacaoNoticiasrepository.Listar();


            return Ok(lista);
        }
    }
}
