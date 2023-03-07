using Infra.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infra.DataContext
{
    public class CadastroContext : DbContext
    {
        public CadastroContext(DbContextOptions<CadastroContext> options) : base(options)
        {

        }

        public DbSet<Person> Persons { get; set; }
    }
}
