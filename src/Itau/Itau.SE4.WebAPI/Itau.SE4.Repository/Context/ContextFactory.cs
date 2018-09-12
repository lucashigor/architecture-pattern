namespace Itau.SE4.Repository
{
    public class ContextFactory : IContextFactory
    {
        SE4Context _context;

        public SE4Context GetContext()
        {
            return _context ?? (_context = new SE4Context());
        }
    }
}
