using Business;
using Domain;
using System.Collections.Generic;

namespace Services
{
    public class DeliveryBoxServices : IDeliveryBoxServices
    {
        private readonly IDeliveryBoxBusiness _deliveryBoxBusiness;

        public DeliveryBoxServices(IDeliveryBoxBusiness deliveryBoxBusiness)
        {
            _deliveryBoxBusiness = deliveryBoxBusiness;
        }

        public void Delete(int id)
        {
            _deliveryBoxBusiness.Delete(id);
        }

        public DeliveryBox Get(int id)
        {
            return _deliveryBoxBusiness.Get(id);
        }

        public IEnumerable<DeliveryBox> Get()
        {
            return _deliveryBoxBusiness.Get();
        }

        public DeliveryBox Create(DeliveryBox value)
        {
            return _deliveryBoxBusiness.Create(value);
        }

        public DeliveryBox Update(DeliveryBox value)
        {
            _deliveryBoxBusiness.Update(value);

            return value;
        }
    }
}
