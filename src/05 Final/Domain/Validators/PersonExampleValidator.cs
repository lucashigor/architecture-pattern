using FluentValidation;
using CrossCulting;
using System;

namespace Domain
{
    public class PersonExampleValidator : ValidatorBase<ExamplePerson>, IPersonExampleValidator
    {
        private readonly IExamplesMessages _examplesMessages;

        public PersonExampleValidator(IExamplesMessages examplesMessages)
        {
            _examplesMessages = examplesMessages;

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage(_examplesMessages.GetNameRequired("Name"))
                .Length(0, 100).WithMessage(_examplesMessages.GetMaxLenght("Name", "100"));
            RuleFor(x => x.BirthDate)
                .GreaterThan(DateTime.MinValue).WithMessage(_examplesMessages.GetNameRequired("Birth Date"));
        }
    }
}
