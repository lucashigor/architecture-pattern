
using Itau.SE4.Entities;

namespace Itau.SE4.Repository
{
    public class ExamplePersonRepository : BaseRepository<ExamplePerson>, IExamplePersonRepository
    {
        public ExamplePersonRepository(IContextFactory factoryBase) : base(factoryBase)
        {
        }

        public ExamplePerson GetByCpf(string cpf)
        {
            return Get(x => x.Cpf == cpf);
        }

        public void DeleteByCpf(string cpf)
        {
            Delete(x => x.Cpf.Equals(cpf));
        }
    }
}
