using Domain;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
    public class PaymentRepository : BaseRepository<Payment>, IPaymentRepository
    {
        public PaymentRepository(IContextFactory factoryBase) : base(factoryBase)
        {
        }

        public IEnumerable<Payment> GetByPaymentPlanId(int id)
        {
            return GetMany(x => x.PaymentPlan_Id == id).ToList();
        }

        public Payment GetById(int id, int paymentPlanId)
        {
            return GetMany(x => x.PaymentPlan_Id == paymentPlanId && x.Id == id).FirstOrDefault();
        }
    }
}
