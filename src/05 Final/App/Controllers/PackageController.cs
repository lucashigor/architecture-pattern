using Domain;
using Microsoft.AspNetCore.Mvc;
using Services;
using System.Collections.Generic;

namespace Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PackageController : ControllerBase
    {
        private readonly IPackageServices _packageServices;

        public PackageController(IPackageServices packageServices)
        {
            _packageServices = packageServices;
        }
        [HttpGet]
        public ICollection<Package> Get()
        {
            return _packageServices.Get();
        }
        [HttpGet("{id}")]
        public Package Get(int id)
        {
            return _packageServices.Get(id);
        }
        [HttpPost]
        public Package Post([FromBody]Package value)
        {
            return _packageServices.Create(value);
        }
        [HttpPut]
        public Package Put([FromBody]Package value)
        {
            return _packageServices.Update(value);
        }
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _packageServices.Delete(id);
        }
    }
}
