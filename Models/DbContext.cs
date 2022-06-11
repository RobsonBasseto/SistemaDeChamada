using Microsoft.EntityFrameworkCore;

namespace FormularioCadastro.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> opcoes)
               : base(opcoes){ }

        public DbSet<DbChamada> chamada { get; set; }

    }
}
