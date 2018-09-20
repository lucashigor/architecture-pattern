using Domain;

namespace Repository
{
    public class PackageRepository : BaseRepository<Package>, IPackageRepository
    {
        public PackageRepository(IContextFactory factoryBase) : base(factoryBase)
        {
        }
    }
}