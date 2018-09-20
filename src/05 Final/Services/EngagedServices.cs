using DBAccess;
using EntityPhoto;
using System.Collections.Generic;
using System.Linq;

namespace Services
{
    public class EngagedServices : IEngagedServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAddressServices _addressServices;

        public EngagedServices(IUnitOfWork unitOfWork, IAddressServices addressServices)
        {
            _unitOfWork = unitOfWork;
            _addressServices = addressServices;
        }

        public void Delete(Engaged engaged, bool commit)
        {
            var address = engaged.MakingOf;

            Delete(engaged.Id, commit);

            if (address != null)
            {
                _addressServices.Delete(address, true);
            }
        }

        public void Delete(int id, bool commit)
        {
            _unitOfWork.EngagedRepository.Delete(x => x.Id == id);

            if (commit)
            {
                Commit();
            }
        }

        public ICollection<Engaged> Get()
        {
            return _unitOfWork.EngagedRepository.GetAll().ToList();
        }

        public Engaged Get(int id)
        {
            return _unitOfWork.EngagedRepository.GetById(id);
        }

        public Engaged Post(Engaged value)
        {
            return _unitOfWork.EngagedRepository.Create(value);
        }

        public Engaged Put(int id, Engaged value)
        {
            var engaged = _unitOfWork.EngagedRepository.GetById(id);

            if (value.Name != null)
            {
                engaged.Name = value.Name;
            }

            if (value.MakingOf != null)
            {
                _addressServices.Put(engaged.Id, value.MakingOf);
            }

            _unitOfWork.EngagedRepository.Update(engaged);

            return engaged;
        }

        private void Commit()
        {
            _unitOfWork.Commit();
        }
    }
}
