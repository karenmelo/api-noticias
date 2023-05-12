using Microsoft.EntityFrameworkCore;

namespace Noticias.Infra.Data
{
    public class NoticiasContext : DbContext
    {
        public NoticiasContext(DbContextOptions<NoticiasContext> options)
           : base(options)
        {
        }
    }
}
