using System.Diagnostics.CodeAnalysis;
using CarRentalApplication.Domain.Entities;
using FluentValidation;

namespace CarRentalApplication.Domain.Validators
{
    [ExcludeFromCodeCoverage]
    public class PersonValidator : AbstractValidator<Person>
    {
        public PersonValidator()
        {
            ValidateName();
            ValidatePhoneNumber();
        }

        private void ValidateName()
        {
            RuleFor(x => x.Name)
                .NotEmpty();
        }

        private void ValidatePhoneNumber()
        {
            RuleFor(x => x.PhoneNumber)
                .NotEmpty();
        }
    }
}
