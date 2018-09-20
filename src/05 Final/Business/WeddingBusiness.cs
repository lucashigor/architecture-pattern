using Domain;
using Repository;
using System.Collections.Generic;
using System.Linq;

namespace Business
{
    public class WeddingBusiness : IWeddingBusiness
    {
        private readonly IWeddingRepository _weddingRepository;

        public WeddingBusiness(IWeddingRepository weddingRepository)
        {
            _weddingRepository = weddingRepository;
        }

        public Wedding GetWedding(int id)
        {
            return _weddingRepository.GetById(id);
        }

        public ICollection<Wedding> GetWedding()
        {
            return _weddingRepository.GetAll().ToList();
        }

        public Wedding Create(Wedding wedding)
        {
            _weddingRepository.Create(wedding);

            return wedding;
        }

        public void Delete(int id)
        {
            _weddingRepository.Delete(id);
        }
    }
}
