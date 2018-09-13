using Itau.SE4.Entities;
using Microsoft.EntityFrameworkCore;

namespace Itau.SE4.Repository
{
    public class SE4Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"D:\\ItauSE4.mdf\";Integrated Security=True;Connect Timeout=30");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ExamplePerson>(etd =>
            {
                etd.ToTable("TAB_EXAMPLE_PERSON");
                etd.HasKey(c => c.Id).HasName("Id");
                etd.Property(c => c.Id).UseSqlServerIdentityColumn();
                etd.Property(c => c.Name).HasColumnName("PER_NAME").HasMaxLength(100);
                etd.Property(c => c.Cpf).HasColumnName("PER_CPF").HasMaxLength(11);
                etd.Property(c => c.BirthDate).HasColumnName("PER_BIRTHDATE").HasMaxLength(11);
            });

        }

        public virtual DbSet<ExamplePerson> ExamplePerson { get; set; }
    }
}

