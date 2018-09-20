using Domain;

namespace Repository
{
    public class WeddingRepository : BaseRepository<Wedding>, IWeddingRepository
    {
        public WeddingRepository(IContextFactory factoryBase) : base(factoryBase)
        {
        }
    }
}
