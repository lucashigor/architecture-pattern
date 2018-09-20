using Business;
using Domain;
using System.Collections.Generic;

namespace Services
{
    public class PaymentPlanServices : IPaymentPlanServices
    {
        private readonly IPaymentPlanBusiness _paymentPlanBusiness;
        private readonly IPaymentServices _paymentServices;

        public PaymentPlanServices(IPaymentPlanBusiness paymentPlanBusiness, IPaymentServices paymentServices)
        {
            _paymentPlanBusiness = paymentPlanBusiness;
            _paymentServices = paymentServices;
        }

        public void Delete(PaymentPlan PaymentPlan)
        {
            var payments = PaymentPlan.Payments;

            if (payments != null)
            {
                _paymentServices.Delete(payments);
            }

            Delete(PaymentPlan.Id);
        }

        public void Delete(int id)
        {
            _paymentPlanBusiness.Delete(id);
        }

        public ICollection<PaymentPlan> Get()
        {
            return _paymentPlanBusiness.Get();
        }

        public PaymentPlan Get(int id)
        {
            return _paymentPlanBusiness.Get(id);
        }

        public PaymentPlan Create(PaymentPlan value)
        {
            return _paymentPlanBusiness.Create(value);
        }

        public PaymentPlan Update(PaymentPlan value)
        {
            _paymentPlanBusiness.Update(value);

            return value;
        }
    }
}
