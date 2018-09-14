using FluentValidation;
using System.Collections.Generic;
using System.Linq;

namespace Itau.SE4.Domain
{
    public class ValidatorBase<T> : AbstractValidator<T> where T : class
    {
        public void Validar(T obj)
        {
            List<string> erros = new List<string>();

            var ret = Validate(obj);

            if(!ret.IsValid)
            {
                ret.Errors.ToList().ForEach(x => erros.Add(x.ErrorMessage));

                throw new ValidationException(string.Format("Ocorreram erros nas validações da classe: {0}", typeof(T).FullName)
                                              , erros);
            }
        }
    }
}
