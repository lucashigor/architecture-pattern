using EntityPhoto;

namespace Services
{
    public interface IUserServices
    {
        void CreateUser(User _user);
        User Login(string userName, string password);
    }
}