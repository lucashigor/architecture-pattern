using Effort;
using Moq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Reflection;
using Tier.Entities;
using Tier.Repository;
using Xunit;

namespace IntegrationTests
{
    public class PersonRepositoryTests
    {

        protected Mock<IFactoryBase> _fabrica;
        protected Context _context;

        [Fact]
        public void TestMethod1()
        {

            CreateDatabase();

            _fabrica = new Mock<IFactoryBase>();

            var conn = DbConnectionFactory.CreateTransient();

            _context = new Context(conn);

            _fabrica.Setup(x => x.GetContext()).Returns(_context);


            var app = new PersonRepository(_fabrica.Object);
            var cpf = "121.230.200-10";

            var person = new Person()
            {
                Name = "Usuario 1",
                BirthDay = DateTime.Today,
                Cpf = cpf
            };

            app.Create(person);
          

            var ret = app.GetByCpf(cpf);

            Assert.Equal(cpf, ret.Cpf);
        }

        private static void CreateDatabase()
        {
            ExecuteSqlCommand(Master, $@"
                CREATE DATABASE [Globalmantics]
                ON (NAME = 'Globalmantics',
                FILENAME = '{Filename}')");

            var migration = new MigrateDatabaseToLatestVersion<
                Context, Tier.Repository.Migrations.Configuration>();
            migration.InitializeDatabase(new Context());
        }

        private static void DestroyDatabase()
        {
            var fileNames = ExecuteSqlQuery(Master, @"
                SELECT [physical_name] FROM [sys].[master_files]
                WHERE [database_id] = DB_ID('Globalmantics')",
                row => (string)row["physical_name"]);

            if (fileNames.Any())
            {
                ExecuteSqlCommand(Master, @"
                    ALTER DATABASE [Globalmantics] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
                    EXEC sp_detach_db 'Globalmantics'");

                fileNames.ForEach(File.Delete);
            }
        }

        private static void ExecuteSqlCommand(
            SqlConnectionStringBuilder connectionStringBuilder,
            string commandText)
        {
            using (var connection = new SqlConnection(connectionStringBuilder.ConnectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = commandText;
                    command.ExecuteNonQuery();
                }
            }
        }

        private static List<T> ExecuteSqlQuery<T>(
            SqlConnectionStringBuilder connectionStringBuilder,
            string queryText,
            Func<SqlDataReader, T> read)
        {
            var result = new List<T>();
            using (var connection = new SqlConnection(connectionStringBuilder.ConnectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = queryText;
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.Add(read(reader));
                        }
                    }
                }
            }
            return result;
        }

        private static SqlConnectionStringBuilder Master =>
            new SqlConnectionStringBuilder
            {
                DataSource = @"(LocalDB)\MSSQLLocalDB",
                InitialCatalog = "master",
                IntegratedSecurity = true
            };

        private static string Filename => Path.Combine(
            Path.GetDirectoryName(
                Assembly.GetExecutingAssembly().Location),
            "Globalmantics.mdf");
    }
}
