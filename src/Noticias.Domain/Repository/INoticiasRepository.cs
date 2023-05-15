using SistemaNoticias.Domain.Entities;

namespace SistemaNoticias.Domain.Repository
{
    public interface INoticiasRepository
    {
        void Cadastrar(Noticia noticia);
        Task<IEnumerable<Noticia>> Listar();
    }
}
