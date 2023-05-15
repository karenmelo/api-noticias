using SistemaNoticias.Domain.Entities;

namespace SistemaNoticias.Domain.Repository
{
    public interface IClassificacaoNoticiasRepository
    {
        void Cadastrar(Classificacao classificacao);
        Task<IEnumerable<Classificacao>> Listar();
    }
}
