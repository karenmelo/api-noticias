namespace SistemaNoticias.Domain.Entities
{
    public class ClassificacaoNoticias
    {
        public Guid NoticiaId { get; set; }
        public virtual Noticia Noticia { get; set; }
        public Guid ClassificacaoId { get; set; }
        public virtual Classificacao Classificacao { get; set; }
    }
}
