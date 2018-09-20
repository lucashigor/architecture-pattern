using EntityPhoto;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Web.Api.Controllers
{
    public class AddressController : ApiController
    {
        private readonly IAddressServices _addressServices;

        public AddressController(IAddressServices addressServices)
        {
            _addressServices = addressServices;
        }

        // GET: api/Address/5
        public Address Get(int id)
        {
            return _addressServices.Get(id);
        }

        // POST: api/Address
        public void Post([FromBody]Address value)
        {
            _addressServices.Post(value);
        }

        // PUT: api/Address/5
        public void Put(int id, [FromBody]Address value)
        {
            _addressServices.Put(id, value);
        }

        // DELETE: api/Address/5
        public void Delete(int id)
        {
            _addressServices.Delete(id, true);
        }
    }
}
