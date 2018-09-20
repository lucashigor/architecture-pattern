using Domain;
using Microsoft.AspNetCore.Mvc;
using Services;
using System.Collections.Generic;

namespace Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentPlanController : ControllerBase
    {
        private readonly IPaymentPlanServices _paymentPlanServices;

        public PaymentPlanController(IPaymentPlanServices paymentPlanServices)
        {
            _paymentPlanServices = paymentPlanServices;
        }

        [HttpGet] //PaymentPlan
        public ICollection<PaymentPlan> Get()
        {
            return _paymentPlanServices.Get();
        }

        [HttpGet("{id}")] //PaymentPlan/5
        public PaymentPlan Get(int id)
        {
            return _paymentPlanServices.Get(id);
        }

        [HttpPost]//PaymentPlan
        public PaymentPlan Post([FromBody]PaymentPlan value)
        {
            return _paymentPlanServices.Create(value);
        }

        [HttpPut]// api/PaymentPlan/5
        public PaymentPlan Put([FromBody]PaymentPlan value)
        {
            return _paymentPlanServices.Update(value);
        }

        [HttpDelete("{id}")]// api/PaymentPlan/5
        public void Delete(int id)
        {
            _paymentPlanServices.Delete(id);
        }
    }
}
