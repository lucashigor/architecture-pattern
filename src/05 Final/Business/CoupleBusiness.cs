using Domain;
using Repository;

namespace Business
{
    public class CoupleBusiness : ICoupleBusiness
    {
        private readonly ICoupleRepository _coupleRepository;

        public CoupleBusiness(ICoupleRepository coupleRepository)
        {
            _coupleRepository = coupleRepository;
        }

        public void Delete(Couple couple)
        {
            _coupleRepository.Delete(couple);            
        }
    }
}
