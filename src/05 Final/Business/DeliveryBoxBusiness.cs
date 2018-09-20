using Domain;
using Repository;
using System.Collections.Generic;

namespace Business
{
    public class DeliveryBoxBusiness : IDeliveryBoxBusiness
    {
        private readonly IDeliveryBoxRepository _deliveryBoxRepository;

        public DeliveryBoxBusiness(IDeliveryBoxRepository deliveryBoxRepository)
        {
            _deliveryBoxRepository = deliveryBoxRepository;
        }

        public void Delete(int id)
        {
            _deliveryBoxRepository.Delete(id);
        }

        public DeliveryBox Get(int id)
        {
            return _deliveryBoxRepository.GetById(id);
        }

        public IEnumerable<DeliveryBox> Get()
        {
            return _deliveryBoxRepository.GetAll();
        }

        public DeliveryBox Create(DeliveryBox value)
        {
            return _deliveryBoxRepository.Create(value);
        }

        public DeliveryBox Update(DeliveryBox value)
        {
            _deliveryBoxRepository.Update(value);

            return value;
        }
    }
}
