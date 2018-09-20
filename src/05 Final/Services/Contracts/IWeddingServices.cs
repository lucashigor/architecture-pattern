using System.Collections.Generic;
using EntityPhoto;

namespace Services
{
    public interface IWeddingServices
    {
        Wedding Create(Wedding _wedding);
        Wedding GetWedding(int id);
        ICollection<Wedding> GetWedding(int pageIndex, int pagesize, out int totalPage);
        void Deletar(int id, bool commit);
    }
}