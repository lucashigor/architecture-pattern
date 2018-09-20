using Domain;
using System.Collections.Generic;

namespace Services
{
    public interface IPaymentServices
    {
        void Delete(ICollection<Payment> collection);
        void Delete(int Id);
        ICollection<Payment> Get(int idPaymentPlan);
        Payment GetById(int id, int idPaymentPlan);
        Payment Create(Payment value);
        Payment Update(Payment value);
    }
}