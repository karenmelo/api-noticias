using SistemaNoticias.Domain.Entities;
using SistemaNoticias.Domain.Repository;
using SistemaNoticias.Infra.Data;

namespace SistemaNoticias.Infra.Repositories
{
    public class NoticiasRepository : INoticiasRepository
    {
        private readonly NoticiasContext _context;

        public NoticiasRepository(NoticiasContext context)
        {
            _context = context;
        }

        public void Cadastrar(Noticia noticia)
        {
            _context.Add(noticia);
            _context.SaveChanges();
        }

        public Task<IEnumerable<Noticia>> Listar()
        {
            throw new NotImplementedException();
        }
    }
}
