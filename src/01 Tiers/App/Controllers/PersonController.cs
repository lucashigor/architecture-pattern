using Microsoft.AspNetCore.Mvc;

namespace App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        public PersonController()
        {
        }
        
        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            var obj = new string[] { "value1", "value2" };

            return Ok(obj);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok("value");
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] string value)
        {
            var obj = value;

            return Ok(obj);
        }

        // PUT api/values/5
        [HttpPut]
        public IActionResult Put([FromBody] string value)
        {
            var obj = value;

            return Ok(obj);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {

        }
    }
}
