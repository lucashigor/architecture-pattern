using DBAccess;
using EntityPhoto;

namespace Services
{
    public class AddressServices : IAddressServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddressServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Delete(Address address, bool commit)
        {
            Delete(address.Id, commit);
        }

        public void Delete(int id, bool commit)
        {
            _unitOfWork.AddressRepository.Delete(x => x.Id == id);

            if (commit)
            {
                Commit();
            }
        }

        public Address Get(int id)
        {
            return _unitOfWork.AddressRepository.GetById(id);
        }

        public Address Post(Address value)
        {
            return _unitOfWork.AddressRepository.Create(value);
        }

        public Address Put(int id, Address value)
        {
            var address = _unitOfWork.AddressRepository.GetById(id);

            if(value.LiberatedTime != null)
            {
                address.LiberatedTime = value.LiberatedTime;
            }
            if (value.Name != null)
            {
                address.Name = value.Name;
            }
            if (value.StreetName != null)
            {
                address.StreetName = value.StreetName;
            }

            _unitOfWork.AddressRepository.Update(address);

            return address;
        }

        private void Commit()
        {
            _unitOfWork.Commit();
        }

    }
}
