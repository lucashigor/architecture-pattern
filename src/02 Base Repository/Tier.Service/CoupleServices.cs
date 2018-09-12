using DBAccess;
using EntityPhoto;

namespace Services
{
    public class CoupleServices : ICoupleServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEngagedServices _engagedServices;

        public CoupleServices(IUnitOfWork unitOfWork, IEngagedServices engagedServices)
        {
            _unitOfWork = unitOfWork;
            _engagedServices = engagedServices;
        }

        public void Delete(Couple couple, bool commit)
        {
            var engaged1 = couple.Engaged1;
            var engaged2 = couple.Engaged2;

            _unitOfWork.CoupleRepository.Delete(x => x.Id == couple.Id);

            if (commit)
            {
                Commit();
            }

            if (engaged1 != null)
            {
                _engagedServices.Delete(engaged1, true);
            }
            if (engaged2 != null)
            {
                _engagedServices.Delete(engaged2, true);
            }

            
        }

        private void Commit()
        {
            _unitOfWork.Commit();
        }
    }
}
