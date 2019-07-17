using System;
using System.Diagnostics.CodeAnalysis;
using CarRentalApplication.Domain.Validators;
using FluentValidation;

namespace CarRentalApplication.Domain.Entities
{
    [ExcludeFromCodeCoverage]
    public class Rental
    {
        private static readonly RentalValidator RentalValidator = new RentalValidator();

        public int Id { get; set; }
        public Vehicle Vehicle { get; set; }
        public Person Owner { get; set; }
        public DateTime ReturnDate { get; set; }

        public void ValidateAndThrow()
        {
            RentalValidator.ValidateAndThrow(this);
        }
    }
}
