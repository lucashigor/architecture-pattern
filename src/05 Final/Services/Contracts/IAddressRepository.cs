using EntityPhoto;

namespace Services
{
    public interface IAddressServices
    {
        void Delete(Address address, bool commit);
        Address Get(int id);
        Address Post(Address value);
        Address Put(int id, Address value);
        void Delete(int id, bool commit);
    }
}