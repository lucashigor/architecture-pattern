using Domain;

namespace Repository
{
    public class CoupleRepository : BaseRepository<Couple>, ICoupleRepository
    {
        public CoupleRepository(IContextFactory factoryBase) : base(factoryBase)
        {
        }
    }
}