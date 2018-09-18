using System;

namespace Factory
{
    public abstract class Refrigerante
    {
        public String Nome;

        public void abrir()
        {
            Console.WriteLine("Você abriu uma lata de " + Nome);
        }
    }
}
