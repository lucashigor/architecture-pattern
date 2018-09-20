using Business;
using Domain;
using System.Collections.Generic;

namespace Services
{
    public class PaymentServices : IPaymentServices
    {
        private readonly IPaymentBusiness _paymentBusiness;

        public PaymentServices(IPaymentBusiness paymentBusiness)
        {
            _paymentBusiness = paymentBusiness;
        }

        public void Delete(ICollection<Payment> collection)
        {
            foreach (var item in collection)
            {
                Delete(item.Id);
            }
        }

        public void Delete(int id)
        {
            _paymentBusiness.Delete(id);
        }

        public ICollection<Payment> Get(int idPaymentPlan)
        {
            return _paymentBusiness.GetByPaymentPlanId(idPaymentPlan);
        }

        public Payment GetById(int id, int idPaymentPlan)
        {
            return _paymentBusiness.GetById(id, idPaymentPlan);
        }

        public Payment Create(Payment value)
        {
            return _paymentBusiness.Create(value);
        }

        public Payment Update(Payment value)
        {
            _paymentBusiness.Update(value);

            return value;
        }
    }
}
