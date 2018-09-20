using Domain;
using System.Collections.Generic;

namespace Business
{
    public interface IDeliveryBoxBusiness
    {
        void Delete(int id);
        IEnumerable<DeliveryBox> Get();
        DeliveryBox Get(int id);
        DeliveryBox Create(DeliveryBox value);
        DeliveryBox Update(DeliveryBox value);
    }
}