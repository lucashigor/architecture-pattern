using Domain;

namespace Repository
{
    public class EngagedRepository : BaseRepository<Engaged>, IEngagedRepository
    {
        public EngagedRepository(IContextFactory factoryBase) : base(factoryBase)
        {
        }
    }
}