using EntityPhoto;
using System.Collections.Generic;

namespace Services
{
    public interface IDeliveryBoxServices
    {
        void Delete(int id, bool commit);
        IEnumerable<DeliveryBox> Get();
        DeliveryBox Get(int id);
        DeliveryBox Post(DeliveryBox value);
        DeliveryBox Put(int id, DeliveryBox value);
    }
}