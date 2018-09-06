using System.Collections.Generic;
using System.Web.Http;
using Tier.Entities;
using Tier.Service;

namespace Tiers.Web.Controllers
{
    public class PersonController : ApiController
    {
        IPersonService personService;

            public PersonController(IPersonService _personService)
        {
            personService = _personService;
        }
        // GET: api/Person
        public IEnumerable<Person> Get()
        {
            return personService.GetCollection();
        }

        // GET: api/Person/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Person
        public void Post([FromBody]Person value)
        {
            personService.SavePerson(value);
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
