using Domain;
using Repository;
using System.Collections.Generic;
using System.Linq;

namespace Business
{
    public class EngagedBusiness : IEngagedBusiness
    {
        private readonly IEngagedRepository _engagedRepository;

        public EngagedBusiness(IEngagedRepository engagedRepository)
        {
            _engagedRepository = engagedRepository;
        }

        public void Delete(Engaged engaged)
        {
            Delete(engaged);
        }

        public void Delete(int id)
        {
            _engagedRepository.Delete(id);
        }

        public ICollection<Engaged> Get()
        {
            return _engagedRepository.GetAll().ToList();
        }

        public Engaged Get(int id)
        {
            return _engagedRepository.GetById(id);
        }

        public Engaged Create(Engaged value)
        {
            return _engagedRepository.Create(value);
        }

        public Engaged Update(Engaged value)
        {
            _engagedRepository.Update(value);

            return value;
        }
    }
}
