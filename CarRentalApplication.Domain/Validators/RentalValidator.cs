using System;
using System.Diagnostics.CodeAnalysis;
using CarRentalApplication.Domain.Entities;
using FluentValidation;

namespace CarRentalApplication.Domain.Validators
{
    [ExcludeFromCodeCoverage]
    public class RentalValidator : AbstractValidator<Rental>
    {
        public RentalValidator()
        {
            ValidateVehicle();
            ValidateOwner();
            ValidateReturnDate();
        }

        private void ValidateVehicle()
        {
            RuleFor(x => x.Vehicle)
                .NotNull();
        }

        private void ValidateOwner()
        {
            RuleFor(x => x.Owner)
                .NotNull();
        }

        private void ValidateReturnDate()
        {
            RuleFor(x => x.ReturnDate)
                .GreaterThan(DateTime.MinValue);
        }
    }
}
