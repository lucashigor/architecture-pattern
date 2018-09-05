using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Tier.Business;
using Tier.Entities;

namespace Tiers.Web.Controllers
{
    public class PersonController : ApiController
    {
        IPersonBusiness personBusiness;

            public PersonController(IPersonBusiness _personBusiness)
        {
            personBusiness = _personBusiness;
        }
        // GET: api/Person
        public IEnumerable<Person> Get()
        {
            return personBusiness.GetCollection();
        }

        // GET: api/Person/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Person
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Person/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Person/5
        public void Delete(int id)
        {
        }
    }
}
