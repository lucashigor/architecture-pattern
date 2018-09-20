using EntityPhoto;
using Services;
using System.Collections.Generic;
using System.Web.Http;

namespace Web.Api.Controllers
{
    public class PackageController : ApiController
    {
        private readonly IPackageServices _packageServices;

        public PackageController(IPackageServices packageServices)
        {
            _packageServices = packageServices;
        }

        public ICollection<Package> Get()
        {
            return _packageServices.Get();
        }

        public Package Get(int id)
        {
            return _packageServices.Get(id);
        }

        public Package Post([FromBody]Package value)
        {
            return _packageServices.Post(value);
        }

        public Package Put(int id, [FromBody]Package value)
        {
            return _packageServices.Put(id,value);
        }

        public void Delete(int id)
        {
            _packageServices.Delete(id);
        }
    }
}
