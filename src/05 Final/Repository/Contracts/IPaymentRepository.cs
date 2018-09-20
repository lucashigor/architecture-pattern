using Domain;
using System.Collections.Generic;

namespace Repository
{
    public interface IPaymentRepository : IBaseRepository<Payment>
    {
        IEnumerable<Payment> GetByPaymentPlanId(int id);

        Payment GetById(int id, int idPaymentPlan);
    }
}