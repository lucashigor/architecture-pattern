using System;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;
using Tier.Entities;

namespace Tier.Repository
{
    public class Context : DbContext
    {
        public Context(DbConnection connection) : base(connection, true)
        {
            
        }

        public Context() 
            : base("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"D:\\Projetos\\GitHub\\architecturepattern\\src\\02 Base Repository\\Globalmantics.mdf\";Integrated Security=True;Connect Timeout=30")
        {
            Database.SetInitializer<Context>(new CreateDatabaseIfNotExists<Context>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //   modelBuilder.Entity<
            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<Person> Person { get; set; }

        public virtual void Commit()
        {
            try
            {
                base.SaveChanges();
            }
            catch (Exception e)
            {
                var errorMessage = "Ocorreram erros ao salvar os dados. Error Message: " + e.Message;

                if (GetValidationErrors().Any())
                {
                    throw new Exception(errorMessage + " - Entity Validation Errors:" +
                                        GetValidationErrors().First().ValidationErrors.First().ErrorMessage);
                }

                throw new Exception(errorMessage);
            }
        }
    }

    public class ContextInitializer : CreateDatabaseIfNotExists<Context>
    {
        protected new void InitializeDatabase(Context context)
            {
            base.InitializeDatabase(context);
        }
    }
}
