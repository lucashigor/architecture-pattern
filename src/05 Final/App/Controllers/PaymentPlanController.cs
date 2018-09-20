using EntityPhoto;
using Services;
using System.Collections.Generic;
using System.Web.Http;

namespace Web.Api.Controllers
{
    public class PaymentPlanController : ApiController
    {
        private readonly IPaymentPlanServices _paymentPlanServices;

        public PaymentPlanController(IPaymentPlanServices paymentPlanServices)
        {
            _paymentPlanServices = paymentPlanServices;
        }

        // GET: api/PaymentPlan
        public ICollection<PaymentPlan> Get()
        {
            return _paymentPlanServices.Get();
        }

        // GET: api/PaymentPlan/5
        public PaymentPlan Get(int id)
        {
            return _paymentPlanServices.Get(id);
        }

        // POST: api/PaymentPlan
        public PaymentPlan Post([FromBody]PaymentPlan value)
        {
            return _paymentPlanServices.Post(value);
        }

        // PUT: api/PaymentPlan/5
        public PaymentPlan Put(int id, [FromBody]PaymentPlan value)
        {
            return _paymentPlanServices.Put(id,value);
        }

        // DELETE: api/PaymentPlan/5
        public void Delete(int id)
        {
            _paymentPlanServices.Delete(id, true);
        }
    }
}
