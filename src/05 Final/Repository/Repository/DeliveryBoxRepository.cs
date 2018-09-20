using Domain;

namespace Repository
{
    public class DeliveryBoxRepository : BaseRepository<DeliveryBox>, IDeliveryBoxRepository
    {
        public DeliveryBoxRepository(IContextFactory factoryBase) : base(factoryBase)
        {
        }
    }
}