using Domain;
using System.Collections.Generic;

namespace Services
{
    public interface IWeddingServices
    {
        Wedding Create(Wedding _wedding);
        Wedding GetWedding(int id);
        ICollection<Wedding> GetWedding();
        void Delete(int id);
    }
}