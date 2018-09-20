using EntityPhoto;
using System.Collections.Generic;

namespace Services
{
    public interface IPaymentPlanServices
    {
        void Delete(PaymentPlan PaymentPlan, bool commit);
        ICollection<PaymentPlan> Get();
        PaymentPlan Get(int id);
        PaymentPlan Post(PaymentPlan value);
        PaymentPlan Put(int id, PaymentPlan value);
        void Delete(int id, bool commit);
    }
}