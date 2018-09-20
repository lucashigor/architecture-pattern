using Domain;
using Repository;

namespace Business
{
    public class AddressBusiness : IAddressBusiness
    {
        private readonly IAddressRepository _addressRepository;

        public AddressBusiness(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }

        public void Delete(Address address)
        {
            Delete(address);
        }

        public void Delete(int id)
        {
            _addressRepository.Delete(id);
        }

        public Address Get(int id)
        {
            return _addressRepository.GetById(id);
        }

        public Address Create(Address value)
        {
            return _addressRepository.Create(value);
        }

        public Address Update(Address value)
        {
            _addressRepository.Update(value);

            return value;
        }
    }
}
