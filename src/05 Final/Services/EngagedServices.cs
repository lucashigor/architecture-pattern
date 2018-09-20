using Business;
using Domain;
using System.Collections.Generic;

namespace Services
{
    public class EngagedServices : IEngagedServices
    {
        private readonly IEngagedBusiness _engagedBusiness;
        private readonly IAddressServices _addressServices;

        public EngagedServices(IEngagedBusiness engagedBusiness, IAddressServices addressServices)
        {
            _engagedBusiness = engagedBusiness;
            _addressServices = addressServices;
        }

        public void Delete(Engaged engaged)
        {
            var address = engaged.MakingOf;

            Delete(engaged.Id);

            if (address != null)
            {
                _addressServices.Delete(address);
            }
        }

        public void Delete(int id)
        {
            _engagedBusiness.Delete(id);
        }

        public ICollection<Engaged> Get()
        {
            return _engagedBusiness.Get();
        }

        public Engaged Get(int id)
        {
            return _engagedBusiness.Get(id);
        }

        public Engaged Create(Engaged value)
        {
            return _engagedBusiness.Create(value);
        }

        public Engaged Update(Engaged value)
        {
            _engagedBusiness.Update(value);

            return value;
        }
    }
}
