using Domain;
using Microsoft.AspNetCore.Mvc;
using Services;
using System.Collections.Generic;

namespace Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EngagedController : ControllerBase
    {
        private readonly IEngagedServices _engagedServices;

        public EngagedController(IEngagedServices engagedServices)
        {
            _engagedServices = engagedServices;
        }

        [HttpGet] //Engaged
        public IEnumerable<Engaged> Get()
        {
            return _engagedServices.Get();
        }

        [HttpGet("{id}")] //Engaged/5
        public Engaged Get(int id)
        {
            return _engagedServices.Get(id);
        }

        [HttpPost]//Engaged
        public void Post([FromBody]Engaged value)
        {
            _engagedServices.Create(value);
        }

        [HttpPut]// api/Engaged/5
        public Engaged Put([FromBody]Engaged value)
        {
            return _engagedServices.Update(value);
        }

        [HttpDelete("{id}")]// api/Engaged/5
        public void Delete(int id)
        {
            _engagedServices.Delete(id);
        }
    }
}
