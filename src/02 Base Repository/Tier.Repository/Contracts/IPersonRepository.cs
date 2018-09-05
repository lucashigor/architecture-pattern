using Tier.Entities;

namespace Tier.Repository
{
    public interface IPersonRepository : IBaseRepository<Person>
    {
        Person GetByCpf(string cpf);
    }
}
