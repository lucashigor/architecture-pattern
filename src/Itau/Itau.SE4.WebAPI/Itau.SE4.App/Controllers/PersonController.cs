using Itau.SE4.Entities;
using Itau.SE4.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Itau.SE4.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IExamplePersonServices _examplePersonServices;

        public PersonController(IExamplePersonServices examplePersonServices)
        {
            _examplePersonServices = examplePersonServices;
        }
        // GET api/values
        [HttpGet]
        public ICollection<ExamplePerson> Get()
        {
            var ret = _examplePersonServices.GetCollection();

            return ret;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] ExamplePerson value)
        {
            _examplePersonServices.SavePerson(value);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
