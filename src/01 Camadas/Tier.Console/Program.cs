using System;
using Tier.Common;
using Tier.Entities;
using Tier.Service;

namespace Tier.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                PersonServices personService = new PersonServices();
                Person person = new Person();

                System.Console.WriteLine("Digite o Nome da Pessoa");
                person.Name = System.Console.ReadLine();

                System.Console.WriteLine("Digite a data de Nascimento dd/mm/yyyy");
                person.BirthDay = DateTime.Parse(System.Console.ReadLine());


                personService.SavePerson(person);

                System.Console.WriteLine("Inserirdo");
                System.Console.WriteLine(person.Id);
            }
            catch (BusinessException ex)
            {
                new ExceptionCommon().BusinessException(ex);
            }
            catch (Exception ex)
            {
                new ExceptionCommon().Exception(ex);
            }


            System.Console.ReadKey();
        }
    }
}
