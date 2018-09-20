using Domain;
using Microsoft.AspNetCore.Mvc;
using Services;
using System.Collections.Generic;

namespace Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeliveryBoxController : ControllerBase
    {
        private readonly IDeliveryBoxServices _deliveryBoxServices;

        public DeliveryBoxController(IDeliveryBoxServices deliveryBoxServices)
        {
            _deliveryBoxServices = deliveryBoxServices;
        }

        [HttpGet] //DeliveryBox
        public IEnumerable<DeliveryBox> Get()
        {
            return _deliveryBoxServices.Get();
        }

        [HttpGet("{id}")] //DeliveryBox/5
        public DeliveryBox Get(int id)
        {
            return _deliveryBoxServices.Get(id);
        }

        [HttpPost]//DeliveryBox
        public DeliveryBox Post([FromBody]DeliveryBox value)
        {
            return _deliveryBoxServices.Create(value);
        }

        [HttpPut]// api/DeliveryBox/5
        public DeliveryBox Put([FromBody]DeliveryBox value)
        {
            return _deliveryBoxServices.Update(value);
        }

        [HttpDelete("{id}")]// api/DeliveryBox/5
        public void Delete(int id)
        {
            _deliveryBoxServices.Delete(id);
        }
    }
}
