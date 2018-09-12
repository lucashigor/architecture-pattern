using Itau.SE4.Entities;
using Microsoft.EntityFrameworkCore;

namespace Itau.SE4.Repository
{
    public class SE4Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"D:\\Globalmantics.mdf\";Integrated Security=True;Connect Timeout=30");
        }

        public virtual DbSet<ExamplePerson> ExamplePerson { get; set; }
    }
}

