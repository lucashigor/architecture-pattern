using Domain;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeddingController : ControllerBase
    {
        private readonly IWeddingServices _weddingServices;

        public WeddingController(IWeddingServices weddingServices)
        {
            _weddingServices = weddingServices;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var obj = _weddingServices.GetWedding();

            return Ok(obj);
        }

        [HttpGet("{id}")] //Wedding/5
        public IActionResult Get(int id)
        {
            var obj = _weddingServices.GetWedding(id);

            return Ok(obj);
        }

        [HttpPost]//Wedding
        public IActionResult Post([FromBody]Wedding value)
        {
            var obj = _weddingServices.Create(value);

            return Ok(obj);
        }

        [HttpPut]// api/Wedding/5
        public void Put([FromBody]Wedding value)
        {
            //var obj = _weddingServices.
        }

        [HttpDelete("{id}")]// api/Wedding/5
        public void Delete(int id)
        {
            _weddingServices.Delete(id);
        }
    }
}
