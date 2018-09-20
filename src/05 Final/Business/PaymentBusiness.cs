using Domain;
using Repository;
using System.Collections.Generic;
using System.Linq;

namespace Business
{
    public class PaymentBusiness : IPaymentBusiness
    {
        private readonly IPaymentRepository _paymentRepository;

        public PaymentBusiness(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
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
            _paymentRepository.Delete(id);
        }

        public ICollection<Payment> GetByPaymentPlanId(int idPaymentPlan)
        {
            return _paymentRepository.GetByPaymentPlanId(idPaymentPlan).ToList();
        }

        public Payment GetById(int id, int idPaymentPlan)
        {
            return _paymentRepository.GetById(id, idPaymentPlan);
        }

        public Payment Create(Payment value)
        {
            return _paymentRepository.Create(value);
        }

        public Payment Update(Payment value)
        {
            _paymentRepository.Update(value);

            return value;
        }
    }
}
