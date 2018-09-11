using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
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

        private static DefaultContractResolver contractResolver = new DefaultContractResolver
        {
            NamingStrategy = new SnakeCaseNamingStrategy()
        };

    private static readonly JsonSerializerSettings SerializerSettings = new JsonSerializerSettings
    {
        ContractResolver = contractResolver,
        Formatting = Formatting.Indented,
        NullValueHandling = NullValueHandling.Ignore
    };

        // GET: api/Person
        public IEnumerable<Person> Get()
        {
            return personService.GetCollection();
        }

        // GET: api/Person/5
        public IHttpActionResult Get(int id)
        {
            var obj = personService.Get(id);

            return Json(obj, SerializerSettings);
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
            personService.DeletePerson(id);
        }

        // DELETE: api/Person/5
        public void Delete(Person value)
        {
            personService.DeletePerson(value);
        }
    }
}
