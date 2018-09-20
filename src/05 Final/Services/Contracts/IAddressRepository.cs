using Domain;

namespace Services
{
    public interface IAddressServices
    {
        void Delete(Address address);
        Address Get(int id);
        Address Create(Address value);
        Address Update(Address value);
        void Delete(int id);
    }
}