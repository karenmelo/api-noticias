namespace SistemaNoticias.Domain.Entities
{
    public class Noticia : Entity
    {
        public string Titulo { get; set; }
        public string Conteudo { get; set; }
        public DateTime DataCadastro { get; set; }

        public virtual ICollection<ClassificacaoNoticias> Classificacoes { get; set; }

        //public virtual IEnumerable<ClassificacaoNoticias> ClassificacaoNoticias { get; set; }
    }
}


