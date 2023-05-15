using SistemaNoticias.Domain.Entities;
using SistemaNoticias.Infra.Data;

namespace SistemaNoticias.Domain.Repository
{
    public class ClassificacaoNoticiasRepository : IClassificacaoNoticiasRepository
    {
        private readonly NoticiasContext _context;

        public ClassificacaoNoticiasRepository(NoticiasContext context)
        {
            _context = context;
        }

        public void Cadastrar(Classificacao classificacao)
        {
            _context.Add(classificacao);
            _context.SaveChanges();
        }

        public async Task<IEnumerable<Classificacao>> Listar()
        {
            return _context.Classificacao.ToList();
        }
    }
}
