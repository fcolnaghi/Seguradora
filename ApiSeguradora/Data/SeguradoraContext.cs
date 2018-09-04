using Microsoft.EntityFrameworkCore;

namespace Seguradora.Models
{
    public class SeguradoraContext : DbContext
    {
        public SeguradoraContext (DbContextOptions<SeguradoraContext> options)
            : base(options)
        {
        }

        public DbSet<Seguradora.Model.User> User { get; set; }
    }
}
