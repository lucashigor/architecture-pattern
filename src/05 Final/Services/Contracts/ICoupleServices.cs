using EntityPhoto;

namespace Services
{
    public interface ICoupleServices
    {
        void Delete(Couple couple, bool commit);
    }
}