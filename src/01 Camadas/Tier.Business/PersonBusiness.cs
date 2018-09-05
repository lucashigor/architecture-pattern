using System;
using Tier.Common;
using Tier.Entities;

namespace Tier.Business
{
    public class PersonBusiness
    {
        public void ValidateMaxAge(Person person)
        {
            if (person.BirthDay < (DateTime.Today.AddYears(-Parameters.max_age)))
            {
                throw new BusinessException(ExceptionsMessages.IDADE_NAO_PERMITIDA
                                            , (int)EnumExceptionLevel.ExceptionLevel.Error
                                            , ExceptionsMessages.COD_IDADE_NAO_PERMITIDA);
            }
        }

        public void ValidateAdvancedAge(Person person)
        {
            if (person.BirthDay < (DateTime.Today.AddYears(-Parameters.warning_max_age)))
            {
                throw new BusinessException(ExceptionsMessages.IDADE_AVANCADA
                                            , (int)EnumExceptionLevel.ExceptionLevel.Warning
                                            , ExceptionsMessages.COD_IDADE_AVANCADA);
            }
        }
    }
}
