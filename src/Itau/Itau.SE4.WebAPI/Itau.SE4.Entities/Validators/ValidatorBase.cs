using FluentValidation;
using Itau.SE4.Commons;

namespace Itau.SE4.Entities
{
    public class ValidatorBase<T> : AbstractValidator<T> where T : class
    {
        public void Validar(T obj)
        {
            var ret = Validate(obj);

            if(!ret.IsValid)
            {
                var errorMessage = string.Empty;

                foreach (var item in ret.Errors)
                {
                    errorMessage = errorMessage + "\\" + item.ErrorMessage;
                }
                throw new BusinessException(errorMessage);
            }
        }
    }
}
