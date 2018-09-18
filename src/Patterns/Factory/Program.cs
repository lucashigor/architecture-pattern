using System;

namespace Factory
{
    class Program
    {
        static void Main(string[] args)
        {
            RefrigeranteFactory rf = new RefrigeranteFactory();
            Refrigerante refrigerante = null;

            Console.WriteLine("Qual refrigerante você quer? (K / P)");

            String tipo = Console.ReadLine();
            refrigerante = rf.fazerRefrigerante(tipo);

            if (refrigerante != null)
            {
                executar(refrigerante);
            }

            else Console.WriteLine("Digite K ou P...");

            Console.ReadKey();
        }

        public static void executar(Refrigerante refri)
        {
            refri.abrir();
        }
    }
}
