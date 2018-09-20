using BUPhoto;
using DBAccess;
using EntityPhoto;
using System;

namespace Services
{
    public class UserServices : IUserServices
    {
        private readonly IBUUser _buUser;
        private readonly IUnitOfWork _unitOfWork;

        public UserServices(IUnitOfWork unitOfWork, IBUUser buUser)
        {
            _unitOfWork = unitOfWork;
            _buUser = buUser;
        }

        public User Login(string userName, string password)
        {
            User ret;

            try
            {
                ret = _unitOfWork.UserRepository.GetUser(userName, password);

                _buUser.UsuarioAtivo(ret);

                return ret;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void CreateUser(User _user)
        {
            if (_user.Type?.Id > 0)
            {
                _user.Type = _unitOfWork.UserTypeRepository.GetById(_user.Type.Id);
            }

            _unitOfWork.UserRepository.Create(_user);
            _unitOfWork.Commit();
        }
    }
}
