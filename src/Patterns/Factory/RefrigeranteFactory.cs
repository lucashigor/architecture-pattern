using System;
using System.Collections.Generic;
using System.Text;

namespace Factory
{
    public class RefrigeranteFactory
    {
        public Refrigerante fazerRefrigerante(String tipo)
        {
            if (tipo.ToUpper().Equals("K"))
            {
                return new RefrigeranteCola();
            }
            else if (tipo.ToUpper().Equals("P"))
            {
                return new RefrigeranteLaranja();
            }
            else return null;
        }
    }
}
