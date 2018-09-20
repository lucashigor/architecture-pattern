using System.Collections.Generic;
using EntityPhoto;

namespace Services
{
    public interface IPaymentServices
    {
        void Delete(ICollection<Payment> collection, bool commit);
        void Delete(int Id, bool commit);
        ICollection<Payment> Get(int idPaymentPlan);
        Payment Get(int id, int idPaymentPlan);
        Payment Post(Payment value);
        Payment Put(int id, Payment value);
    }
}