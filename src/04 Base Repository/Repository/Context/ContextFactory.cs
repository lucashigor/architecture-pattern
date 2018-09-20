using CrossCulting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Repository
{
    public class ContextFactory : IContextFactory
    {
        private readonly IConfiguration _configuration;
        private readonly IFeature _feature;

        public ContextFactory(IConfiguration configuration, IFeature feature)
        {
            _configuration = configuration;
            _feature = feature;
        }

        private DbContext _context;

        public DbContext GetContext()
        {
            if (_feature.IsFeatureEnabled("BancoMemoria"))
            {
                var bagulho = new DbContextOptionsBuilder<PhotoAdminContext>()
                .UseInMemoryDatabase(databaseName: "Add_writes_to_database")
                .Options;

                return _context ?? (_context = new PhotoAdminContext(bagulho));
            }
            else
            {
                var connectionString = _configuration.GetConnectionString("PhotoAdminContext");

                var options = new DbContextOptionsBuilder<PhotoAdminContext>()
                    .UseSqlServer(connectionString)
                    .Options;

                return _context ?? (_context = new PhotoAdminContext(options));
            }
        }
    }
}
