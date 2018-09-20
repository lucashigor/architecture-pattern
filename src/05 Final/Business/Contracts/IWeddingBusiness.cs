using Domain;
using System.Collections.Generic;

namespace Business
{
    public interface IWeddingBusiness
    {
        Wedding Create(Wedding _wedding);
        Wedding GetWedding(int id);
        ICollection<Wedding> GetWedding();
        void Delete(int id);
    }
}