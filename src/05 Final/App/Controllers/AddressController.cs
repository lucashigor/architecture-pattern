using Domain;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IAddressServices _addressServices;

        public AddressController(IAddressServices addressServices)
        {
            _addressServices = addressServices;
        }

        [HttpGet("{id}")] //Address/5
        public Address Get(int id)
        {
            return _addressServices.Get(id);
        }

        [HttpPost]//Address
        public void Post([FromBody]Address value)
        {
            _addressServices.Create(value);
        }

        [HttpPut]// api/Address/5
        public void Put([FromBody]Address value)
        {
            _addressServices.Update(value);
        }

        [HttpDelete("{id}")]// api/Address/5
        public void Delete(int id)
        {
            _addressServices.Delete(id);
        }
    }
}
