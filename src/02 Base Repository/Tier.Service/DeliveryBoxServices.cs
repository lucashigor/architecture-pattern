using System.Collections.Generic;
using DBAccess;
using EntityPhoto;

namespace Services
{
    public class DeliveryBoxServices : IDeliveryBoxServices
    {
        private readonly IUnitOfWork _unityWork;

        public DeliveryBoxServices(IUnitOfWork unityWork)
        {
            _unityWork = unityWork;
        }

        public void Delete(int id, bool commit)
        {
            _unityWork.DeliveryBoxRepository.Delete(x => x.Id == id);

            if (commit)
            {
                Commit();
            }
        }

        public DeliveryBox Get(int id)
        {
            return _unityWork.DeliveryBoxRepository.GetById(id);
        }

        public IEnumerable<DeliveryBox> Get()
        {
            return _unityWork.DeliveryBoxRepository.GetAll();
        }

        public DeliveryBox Post(DeliveryBox value)
        {
            return _unityWork.DeliveryBoxRepository.Create(value);
        }

        public DeliveryBox Put(int id, DeliveryBox value)
        {
            var deliveryBox = _unityWork.DeliveryBoxRepository.GetById(id);

            if (value.Name != null)
            {
                deliveryBox.Name = value.Name ;
            }

            _unityWork.DeliveryBoxRepository.Update(deliveryBox);
            Commit();

            return deliveryBox;
        }

        private void Commit()
        {
            _unityWork.Commit();
        }
    }
}
