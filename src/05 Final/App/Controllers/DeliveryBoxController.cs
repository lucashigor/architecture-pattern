using EntityPhoto;
using Services;
using System.Collections.Generic;
using System.Web.Http;

namespace Web.Api.Controllers
{
    public class DeliveryBoxController : ApiController
    {
        private readonly IDeliveryBoxServices _deliveryBoxServices;

        public DeliveryBoxController(IDeliveryBoxServices deliveryBoxServices)
        {
            _deliveryBoxServices = deliveryBoxServices;
        }

        // GET: api/DeliveryBox
        public IEnumerable<DeliveryBox> Get()
        {
            return _deliveryBoxServices.Get();
        }

        // GET: api/DeliveryBox/5
        public DeliveryBox Get(int id)
        {
            return _deliveryBoxServices.Get(id);
        }

        // POST: api/DeliveryBox
        public DeliveryBox Post([FromBody]DeliveryBox value)
        {
            return _deliveryBoxServices.Post(value);
        }

        // PUT: api/DeliveryBox/5
        public DeliveryBox Put(int id, [FromBody]DeliveryBox value)
        {
            return _deliveryBoxServices.Put(id, value);
        }

        // DELETE: api/DeliveryBox/5
        public void Delete(int id)
        {
            _deliveryBoxServices.Delete(id, true);
        }
    }
}
