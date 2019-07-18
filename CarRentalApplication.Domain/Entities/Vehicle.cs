using System.Diagnostics.CodeAnalysis;
using CarRentalApplication.Domain.Enums;
using CarRentalApplication.Domain.Validators;
using FluentValidation;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CarRentalApplication.Domain.Entities
{
    [ExcludeFromCodeCoverage]
    public class Vehicle
    {
        private static readonly VehicleValidator VehicleValidator = new VehicleValidator();

        public short Id { get; set; }
        public string Name { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public VehicleType Type { get; set; }
        public short FuelPercentage { get; set; }
        public short DamagePercentage { get; set; }

        public virtual void ValidateAndThrow()
        {
            VehicleValidator.ValidateAndThrow(this);
        }
    }
}
