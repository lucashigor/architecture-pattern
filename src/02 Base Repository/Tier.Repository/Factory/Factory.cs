namespace Tier.Repository
{
    public class Factory : IFactoryBase
    {
        Context _context;

        public Context GetContext()
        {
            return _context ?? (_context = new Context());
        }
    }
}
