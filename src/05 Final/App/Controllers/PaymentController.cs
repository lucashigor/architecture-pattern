using Domain;
using Microsoft.AspNetCore.Mvc;
using Services;
using System.Collections.Generic;

namespace Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentServices _paymentServices;

        public PaymentController(IPaymentServices paymentServices)
        {
            _paymentServices = paymentServices;
        }

        [HttpGet("{id}")] //Payment
        public IEnumerable<Payment> Get(int id)
        {
          return _paymentServices.Get(id);
        }

        [HttpGet("{id},{idPaymentPlan}")] //Payment/5
        public Payment Get(int id, int idPaymentPlan)
        {
            return _paymentServices.GetById(id, idPaymentPlan);
        }

        [HttpPost]//Payment
        public void Post([FromBody]Payment value)
        {
            _paymentServices.Create(value);
        }

        [HttpPut]// api/Payment/5
        public void Put([FromBody]Payment value)
        {
            _paymentServices.Update(value);
        }

        [HttpDelete("{id}")]// api/Payment/5
        public void Delete(int id)
        {
            _paymentServices.Delete(id);
        }
    }
}
