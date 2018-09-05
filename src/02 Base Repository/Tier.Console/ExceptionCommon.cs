using System;
using Tier.Common;

namespace Tier.Console
{
    public class ExceptionCommon
    {
        public void BusinessException(BusinessException businessException)
        {
            if (businessException.Level ==(int)EnumExceptionLevel.ExceptionLevel.Warning)
            {
                System.Console.WriteLine("Cuidado");
            }
            else if (businessException.Level == (int)EnumExceptionLevel.ExceptionLevel.Error)
            {
                System.Console.WriteLine("Deu Erro");
            }

            System.Console.WriteLine(businessException.Id);
            System.Console.WriteLine(businessException.Message);
        }

        public void Exception(Exception exception)
        {
            System.Console.WriteLine("Aconteceu um erro interno, favor entrar em contato com os administrador.");
        }
    }
}