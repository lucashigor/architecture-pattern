using Domain;

namespace Repository
{
    public class PaymentPlanRepository : BaseRepository<PaymentPlan>, IPaymentPlanRepository
    {
        public PaymentPlanRepository(IContextFactory factoryBase) : base(factoryBase)
        {
        }
    }
}