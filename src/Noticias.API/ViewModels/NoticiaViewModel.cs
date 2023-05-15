using SistemaNoticias.Domain.Entities;

namespace SistemaNoticias.API.ViewModels
{
    public class NoticiaViewModel
    {
        public string Titulo { get; set; }
        public string Conteudo { get; set; }
        public DateTime DataCadastro { get; set; }
        public IEnumerable<Classificacao> Classificacao { get; set; }
    }
}
