using Noticias.Domain.Enums;

namespace Noticias.Domain.Entities
{
    public class Noticias
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Noticia { get; set; }
        public DateTime DataCadastro { get; set; }
        public IEnumerable<ClassificacaoNoticias> Classificacao { get; set; }
    }
}
