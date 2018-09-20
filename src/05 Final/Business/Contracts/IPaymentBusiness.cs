using Domain;
using System.Collections.Generic;

namespace Business
{
    public interface IPaymentBusiness
    {
        void Delete(ICollection<Payment> collection);
        void Delete(int Id);
        ICollection<Payment> GetByPaymentPlanId(int idPaymentPlan);
        Payment GetById(int id, int idPaymentPlan);
        Payment Create(Payment value);
        Payment Update(Payment value);
    }
}