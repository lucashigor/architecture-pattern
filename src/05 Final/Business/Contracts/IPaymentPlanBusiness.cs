using Domain;
using System.Collections.Generic;

namespace Business
{
    public interface IPaymentPlanBusiness
    {
        void Delete(PaymentPlan PaymentPlan);
        ICollection<PaymentPlan> Get();
        PaymentPlan Get(int id);
        PaymentPlan Create(PaymentPlan value);
        PaymentPlan Update(PaymentPlan value);
        void Delete(int id);
    }
}