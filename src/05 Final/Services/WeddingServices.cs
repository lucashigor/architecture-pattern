using DBAccess;
using EntityPhoto;
using System.Collections.Generic;
using System.Linq;

namespace Services
{
    public class WeddingServices : IWeddingServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPackageServices _packageServices;
        private readonly IDeliveryBoxServices _deliveryBoxServices;
        private readonly ICoupleServices _coupleServices;
        private readonly IAddressServices _addressServices;
        private readonly IPaymentPlanServices _paymentPlanServices;

        public WeddingServices(IUnitOfWork unitOfWork
            , IPackageServices packageServices
            , IDeliveryBoxServices deliveryBoxServices
            , ICoupleServices coupleServices
            , IAddressServices addressServices
            , IPaymentPlanServices paymentPlanServices)
        {
            _unitOfWork = unitOfWork;
            _packageServices = packageServices;
            _deliveryBoxServices = deliveryBoxServices;
            _coupleServices = coupleServices;
            _addressServices = addressServices;
            _paymentPlanServices = paymentPlanServices;
        }

        public Wedding GetWedding(int id)
        {
            return _unitOfWork.WeddingRepository.GetById(id);
        }

        public ICollection<Wedding> GetWedding(int pageIndex, int pagesize, out int totalPages)
        {
            return _unitOfWork.WeddingRepository.GetAll(x => x.Id,pagesize,pageIndex, out totalPages).ToList();
        }

        public Wedding Create(Wedding wedding)
        {
            if(wedding.DeliveryBox?.Id != null)
            {
                wedding.DeliveryBox = _unitOfWork.DeliveryBoxRepository.GetById(wedding.DeliveryBox.Id);
            }

            if (wedding.Package?.Id != null)
            {
                wedding.Package = _unitOfWork.PackageRepository.GetById(wedding.Package.Id);
            }

            _unitOfWork.WeddingRepository.Create(wedding);

            Commit();

            return wedding;
        }

        public void Deletar(int id, bool commit)
        {
            var wedding = _unitOfWork.WeddingRepository.GetById(id);

            var couple = wedding.Couple;
            var cerimony = wedding.Cerimony;
            var party = wedding.Party;
            var paymentPlan = wedding.PaymentPlan;

            _unitOfWork.WeddingRepository.Delete(x => x.Id == wedding.Id);

            if (commit)
            {
                Commit();
            }

            if (couple != null)
            {
                _coupleServices.Delete(couple, true);
            }

            if (cerimony != null)
            {
                _addressServices.Delete(cerimony, true);
            }

            if (party != null)
            {
                _addressServices.Delete(party, true);
            }

            if (paymentPlan != null)
            {
                _paymentPlanServices.Delete(paymentPlan, true);
            }

        }

        private void Commit()
        {
            _unitOfWork.Commit();
        }
    }
}
