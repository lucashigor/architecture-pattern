using AutoMapper;
using System;

namespace MapperDTO
{
    class Program
    {
        static void Main(string[] args)
        {
            var source = new Entidade()
            {
                CodigoPessoaFisica = "123",
                NomeDoParticipante = "Lucas Higor"
            };
            MapperConfiguration config = GetConfiguration();

            IMapper iMapper = config.CreateMapper();

            var destination = iMapper.Map<Entidade, EntidadeDTO>(source);

            Console.WriteLine("Classe DTO Name: " + destination.Nome + " " + destination.Cpf);

            Console.ReadKey();
        }

        private static MapperConfiguration GetConfiguration()
        {
            return new MapperConfiguration(cfg =>
            {

                cfg.CreateMap<Entidade, EntidadeDTO>()
                .ForMember(dest => dest.Nome, from => from.MapFrom(src => src.NomeDoParticipante))
                .ForMember(dest => dest.Cpf, from => from.MapFrom(src => src.CodigoPessoaFisica));

            });
        }
    }
}