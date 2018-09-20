using Business;
using Domain;

namespace Services
{
    public class AddressServices : IAddressServices
    {
        private readonly IAddressBusiness _addressBusiness;

        public AddressServices(IAddressBusiness addressBusiness)
        {
            _addressBusiness = addressBusiness;
        }

        public void Delete(Address address)
        {
            Delete(address);
        }

        public void Delete(int id)
        {
            _addressBusiness.Delete(id);
        }

        public Address Get(int id)
        {
            return _addressBusiness.Get(id);
        }

        public Address Create(Address value)
        {
            return _addressBusiness.Create(value);
        }

        public Address Update(Address value)
        {
            _addressBusiness.Update(value);

            return value;
        }
    }
}
