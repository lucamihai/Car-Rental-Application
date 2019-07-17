using System.Diagnostics.CodeAnalysis;
using CarRentalApplication.Domain.Validators;
using FluentValidation;

namespace CarRentalApplication.Domain.Entities
{
    [ExcludeFromCodeCoverage]
    public class Vehicle
    {
        private static readonly VehicleValidator VehicleValidator = new VehicleValidator();

        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; protected set; }
        public short FuelPercentage { get; set; }
        public short DamagePercentage { get; set; }

        public virtual void ValidateAndThrow()
        {
            VehicleValidator.ValidateAndThrow(this);
        }
    }
}
