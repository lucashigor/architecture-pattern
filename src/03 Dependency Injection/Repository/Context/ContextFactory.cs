using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class ContextFactory : IContextFactory
    {
        private DbContext _context;

        public DbContext GetContext()
        {
            return _context ?? (_context = new SE4Context());
        }
    }
}
