using Domain;

namespace Repository
{
    public class AddressRepository : BaseRepository<Address>, IAddressRepository
    {
        public AddressRepository(IContextFactory factoryBase) : base(factoryBase)
        {
        }
    }
}