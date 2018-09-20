using Business;
using Domain;
using Repository;
using System.Collections.Generic;
using System.Linq;

namespace Business
{
    public class PaymentPlanBusiness : IPaymentPlanBusiness
    {
        private readonly IPaymentPlanRepository _paymentPlanRepository;

        public PaymentPlanBusiness(IPaymentPlanRepository paymentPlanRepository)
        {
            _paymentPlanRepository = paymentPlanRepository;
        }

        public void Delete(PaymentPlan PaymentPlan)
        {
            _paymentPlanRepository.Delete(PaymentPlan);
        }

        public void Delete(int id)
        {
            _paymentPlanRepository.Delete(id);
        }

        public ICollection<PaymentPlan> Get()
        {
            return _paymentPlanRepository.GetAll().ToList();
        }

        public PaymentPlan Get(int id)
        {
            return _paymentPlanRepository.GetById(id);
        }

        public PaymentPlan Create(PaymentPlan value)
        {
            return _paymentPlanRepository.Create(value);
        }

        public PaymentPlan Update(PaymentPlan value)
        {
            _paymentPlanRepository.Update(value);

            return value;
        }
    }
}
