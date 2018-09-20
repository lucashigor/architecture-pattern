using Business;
using Domain;
using System.Collections.Generic;

namespace Services
{
    public class WeddingServices : IWeddingServices
    {
        private readonly IWeddingBusiness _weddingBusiness;
        private readonly IPackageServices _packageServices;
        private readonly IDeliveryBoxServices _deliveryBoxServices;
        private readonly ICoupleServices _coupleServices;
        private readonly IAddressServices _addressServices;
        private readonly IPaymentPlanServices _paymentPlanServices;
        private readonly object _unitOfWork;

        public WeddingServices(IWeddingBusiness weddingBusiness
            , IPackageServices packageServices
            , IDeliveryBoxServices deliveryBoxServices
            , ICoupleServices coupleServices
            , IAddressServices addressServices
            , IPaymentPlanServices paymentPlanServices)
        {
            _weddingBusiness = weddingBusiness;
            _packageServices = packageServices;
            _deliveryBoxServices = deliveryBoxServices;
            _coupleServices = coupleServices;
            _addressServices = addressServices;
            _paymentPlanServices = paymentPlanServices;
        }

        public Wedding GetWedding(int id)
        {
            return _weddingBusiness.GetWedding(id);
        }

        public ICollection<Wedding> GetWedding()
        {
            return _weddingBusiness.GetWedding();
        }

        public Wedding Create(Wedding wedding)
        {
            if(wedding.DeliveryBox?.Id != null)
            {
                wedding.DeliveryBox = _deliveryBoxServices.Get(wedding.DeliveryBox.Id);
            }

            if (wedding.Package?.Id != null)
            {
                wedding.Package = _packageServices.Get(wedding.Package.Id);
            }

            _weddingBusiness.Create(wedding);

            return wedding;
        }

        public void Delete(int id)
        {
            var wedding = _weddingBusiness.GetWedding(id);

            var couple = wedding.Couple;
            var cerimony = wedding.Cerimony;
            var party = wedding.Party;
            var paymentPlan = wedding.PaymentPlan;

            _weddingBusiness.Delete(wedding.Id);

            if (couple != null)
            {
                _coupleServices.Delete(couple);
            }

            if (cerimony != null)
            {
                _addressServices.Delete(cerimony);
            }

            if (party != null)
            {
                _addressServices.Delete(party);
            }

            if (paymentPlan != null)
            {
                _paymentPlanServices.Delete(paymentPlan);
            }
        }
    }
}
