using Domain;

namespace Repository
{
    public interface IExamplePersonRepository : IBaseRepository<ExamplePerson>
    {
        ExamplePerson GetByCpf(string cpf);

        void DeleteByCpf(string cpf);
    }
}
