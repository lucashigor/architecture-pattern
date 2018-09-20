using Business;
using Domain;

namespace Services
{
    public class CoupleServices : ICoupleServices
    {
        private readonly ICoupleBusiness _coupleBusiness;
        private readonly IEngagedServices _engagedServices;

        public CoupleServices(ICoupleBusiness coupleBusiness, IEngagedServices engagedServices)
        {
            _coupleBusiness = coupleBusiness;
            _engagedServices = engagedServices;
        }

        public void Delete(Couple couple)
        {
            var engaged1 = couple.Engaged1;
            var engaged2 = couple.Engaged2;

            _coupleBusiness.Delete(couple);

            if (engaged1 != null)
            {
                _engagedServices.Delete(engaged1);
            }
            if (engaged2 != null)
            {
                _engagedServices.Delete(engaged2);
            }

            
        }
    }
}
