using EntityPhoto;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Web.Api.Controllers
{
    public class WeddingController : ApiController
    {
        private readonly IWeddingServices _weddingServices;

        public WeddingController(IWeddingServices weddingServices)
        {
            _weddingServices = weddingServices;
        }

        public GetReturn<Wedding> Get()
        {
            GetReturn<Wedding> ret = new GetReturn<Wedding>();
            
            ret.Values = _weddingServices.GetWedding(1,10, out ret.TotalRegisters);

            return ret;
        }

        // GET: api/Wedding/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Wedding
        public Wedding Post([FromBody]Wedding value)
        {
            return _weddingServices.Create(value);
        }

        // PUT: api/Wedding/5
        public void Put(int id, [FromBody]Wedding value)
        {
        }

        // DELETE: api/Wedding/5
        public void Delete(int id)
        {
            _weddingServices.Deletar(id, true);
        }
    }
}
