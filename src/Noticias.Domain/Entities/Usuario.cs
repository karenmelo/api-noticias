using SistemaNoticias.Domain.Enums;

namespace SistemaNoticias.Domain.Entities
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public TipoUsuario Perfil { get; set; }
    }
}
