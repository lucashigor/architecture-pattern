using Domain;
using System.Collections.Generic;

namespace Services
{
    public interface IDeliveryBoxServices
    {
        void Delete(int id);
        IEnumerable<DeliveryBox> Get();
        DeliveryBox Get(int id);
        DeliveryBox Create(DeliveryBox value);
        DeliveryBox Update(DeliveryBox value);
    }
}