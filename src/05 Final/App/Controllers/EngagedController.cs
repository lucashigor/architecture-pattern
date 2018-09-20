using EntityPhoto;
using Services;
using System.Collections.Generic;
using System.Web.Http;

namespace Web.Api.Controllers
{
    public class EngagedController : ApiController
    {
        private readonly IEngagedServices _engagedServices;

        public EngagedController(IEngagedServices engagedServices)
        {
            _engagedServices = engagedServices;
        }

        // GET: api/Engaged
        public IEnumerable<Engaged> Get()
        {
            return _engagedServices.Get();
        }

        // GET: api/Engaged/5
        public Engaged Get(int id)
        {
            return _engagedServices.Get(id);
        }

        // POST: api/Engaged
        public void Post([FromBody]Engaged value)
        {
            _engagedServices.Post(value);
        }

        // PUT: api/Engaged/5
        public Engaged Put(int id, [FromBody]Engaged value)
        {
            return _engagedServices.Put(id,value);
        }

        // DELETE: api/Engaged/5
        public void Delete(int id)
        {
            _engagedServices.Delete(id, true);
        }
    }
}
