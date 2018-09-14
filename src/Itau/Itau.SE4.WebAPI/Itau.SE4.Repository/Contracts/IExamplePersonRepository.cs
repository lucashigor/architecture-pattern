using Itau.SE4.Domain;

namespace Itau.SE4.Repository
{
    public interface IExamplePersonRepository : IBaseRepository<ExamplePerson>
    {
        ExamplePerson GetByCpf(string cpf);

        void DeleteByCpf(string cpf);
    }
}
