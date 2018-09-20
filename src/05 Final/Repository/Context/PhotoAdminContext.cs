using Domain;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class PhotoAdminContext : DbContext
    {
        public PhotoAdminContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"D:\\PhotoAdminContext.mdf\";Integrated Security=True;Connect Timeout=30");
        }

        public PhotoAdminContext(DbContextOptions<PhotoAdminContext> options)
            : base(options)
        {

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

            modelBuilder.Entity<Address>(etd =>
            {
                etd.Property(c => c.Id).UseSqlServerIdentityColumn();
                etd.Property(c => c.Name).HasMaxLength(100);
                etd.Property(c => c.StreetName).HasMaxLength(100);
            });

            modelBuilder.Entity<Couple>(etd =>
            {
                etd.Property(c => c.Id).UseSqlServerIdentityColumn();
            });

            modelBuilder.Entity<DeliveryBox>(etd =>
            {
                etd.Property(c => c.Id).UseSqlServerIdentityColumn();
                etd.Property(c => c.Name).HasMaxLength(100);
            });

            modelBuilder.Entity<Engaged>(etd =>
            {
                etd.Property(c => c.Id).UseSqlServerIdentityColumn();
                etd.Property(c => c.Name).HasMaxLength(100);
            });

            modelBuilder.Entity<Package>(etd =>
            {
                etd.Property(c => c.Id).UseSqlServerIdentityColumn();
                etd.Property(c => c.Name).HasMaxLength(100);
            });

            modelBuilder.Entity<PaymentPlan>(etd =>
            {
                etd.Property(c => c.Id).UseSqlServerIdentityColumn();
            });

            modelBuilder.Entity<Wedding>(etd =>
            {
                etd.Property(c => c.Id).UseSqlServerIdentityColumn();
                etd.Property(c => c.ExtraInformation).HasMaxLength(300);
            });

            modelBuilder.Entity<CommercialContract>(etd =>
            {
                etd.Property(c => c.Id).UseSqlServerIdentityColumn();
                etd.Property(c => c.Name).HasMaxLength(100);
                etd.Property(c => c.Path).HasMaxLength(255);
            });


        }

        public virtual DbSet<ExamplePerson> ExamplePerson { get; set; }
        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Couple> Couples { get; set; }
        public virtual DbSet<DeliveryBox> DeliveryBoxes { get; set; }
        public virtual DbSet<Engaged> Engageds { get; set; }
        public virtual DbSet<Package> Packages { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<PaymentPlan> PaymentPlans { get; set; }
        public virtual DbSet<Wedding> Weddings { get; set; }
        public virtual DbSet<CommercialContract> CommercialContracts { get; set; }
    }
}

