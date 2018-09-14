using Itau.SE4.Domain;
using Itau.SE4.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Itau.SE4.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IExamplePersonServices _examplePersonServices;
        private readonly ILogger<PersonController> _logger;

        public PersonController(IExamplePersonServices examplePersonServices,
                                ILogger<PersonController> logger)
        {
            _logger = logger;

            if (_logger.IsEnabled(LogLevel.Debug))
            {
                _logger.LogDebug("Calling PersonController");
            }

            _examplePersonServices = examplePersonServices;
        }
        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            var obj = _examplePersonServices.GetCollection();

            return Ok(obj);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var obj = _examplePersonServices.Get(id);

            return Ok(obj);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] ExamplePerson value)
        {
            var obj = _examplePersonServices.SavePerson(value);

            return Ok(obj);
        }

        // PUT api/values/5
        [HttpPut]
        public IActionResult Put([FromBody] ExamplePerson value)
        {
            var obj = _examplePersonServices.UpdatePerson(value);

            return Ok(obj);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _examplePersonServices.Delete(id);
        }
    }
}
