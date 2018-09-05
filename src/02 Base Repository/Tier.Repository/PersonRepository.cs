using Tier.Entities;

namespace Tier.Repository
{
    public class PersonRepository : BaseRepository<Person>, IPersonRepository
    {
        public PersonRepository(IFactoryBase factoryBase) : base(factoryBase)
        {
        }

        public Person GetByCpf(string cpf)
        {
            return Get(x => x.Cpf == cpf);
        }
    }
}
