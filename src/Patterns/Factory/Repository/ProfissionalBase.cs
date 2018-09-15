using System;
using System.Collections.Generic;
using System.Text;

namespace Factory.Repository
{
    public class ProfissionalBase
    {
        public IList<Profissional> GetProfissionais()
        {
            var Dev = new Profissional()
            {
                Cargo = "Developer",
                Id = 1,
                Nome = "José da Silva",
                Salario = 3000,
                Telefone = "999.888.777"
            };

            var Sm = new Profissional()
            {
                Cargo = "Mandador de e-Mail",
                Id = 2,
                Nome = "João da Neves",
                Salario = 5000,
                Telefone = "999.888.777"
            };

            var Arq = new Profissional()
            {
                Cargo = "Petulante",
                Id = 3,
                Nome = "Mohamed",
                Salario = 5000,
                Telefone = "999.888.777"
            };

            var list = new List<Profissional>();

            list.Add(Dev);
            list.Add(Sm);
            list.Add(Arq);

            return list;
        }
    }
}
