using EntityPhoto;
using Services;
using System.Collections.Generic;
using System.Web.Http;

namespace Web.Api.Controllers
{
    public class PaymentController : ApiController
    {
        private readonly IPaymentServices _paymentServices;

        public PaymentController(IPaymentServices paymentServices)
        {
            _paymentServices = paymentServices;
        }

        // GET: api/Payment
        public IEnumerable<Payment> Get(int idPaymentPlan)
        {
          return _paymentServices.Get(idPaymentPlan);
        }

        // GET: api/Payment/5
        public Payment Get(int id, int idPaymentPlan)
        {
            return _paymentServices.Get(id, idPaymentPlan);
        }

        // POST: api/Payment
        public void Post([FromBody]Payment value)
        {
            _paymentServices.Post(value);
        }

        // PUT: api/Payment/5
        public void Put(int id, [FromBody]Payment value)
        {
            _paymentServices.Put(id, value);
        }

        // DELETE: api/Payment/5
        public void Delete(int id)
        {
            _paymentServices.Delete(id, true);
        }
    }
}
