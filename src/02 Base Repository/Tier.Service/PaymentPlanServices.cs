using System.Collections.Generic;
using System.Linq;
using DBAccess;
using EntityPhoto;

namespace Services
{
    public class PaymentPlanServices : IPaymentPlanServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPaymentServices _paymentServices;

        public PaymentPlanServices(IUnitOfWork unitOfWork, IPaymentServices paymentServices)
        {
            _unitOfWork = unitOfWork;
            _paymentServices = paymentServices;
        }

        public void Delete(PaymentPlan PaymentPlan, bool commit)
        {
            var payments = PaymentPlan.Payments;

            if (payments != null)
            {
                _paymentServices.Delete(payments, true);
            }

            Delete(PaymentPlan.Id, commit);
        }

        public void Delete(int id, bool commit)
        {
            _unitOfWork.PaymentPlanRepository.Delete(x => x.Id == id);

            if (commit)
            {
                Commit();
            }
        }

        public ICollection<PaymentPlan> Get()
        {
            return _unitOfWork.PaymentPlanRepository.GetAll().ToList();
        }

        public PaymentPlan Get(int id)
        {
            return _unitOfWork.PaymentPlanRepository.GetById(id);
        }

        public PaymentPlan Post(PaymentPlan value)
        {
            return _unitOfWork.PaymentPlanRepository.Create(value);
        }

        public PaymentPlan Put(int id, PaymentPlan value)
        {
            var paymentPlan = _unitOfWork.PaymentPlanRepository.GetById(id);

            if(value.ExtraValue != null)
            {
                paymentPlan.ExtraValue = value.ExtraValue;
            }
            if (value.PercentualDiscount != null)
            {
                paymentPlan.PercentualDiscount = value.PercentualDiscount;
            }
            if (value.Value != null)
            {
                paymentPlan.Value = value.Value;
            }
            if (value.ValueDiscount != null)
            {
                paymentPlan.ValueDiscount = value.ValueDiscount;
            }

            _unitOfWork.PaymentPlanRepository.Update(paymentPlan);

            Commit();

            return paymentPlan;
        }

        private void Commit()
        {
            _unitOfWork.Commit();
        }
    }
}
