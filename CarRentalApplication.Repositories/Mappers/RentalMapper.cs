using System;
using CarRentalApplication.Domain.Entities;

namespace CarRentalApplication.Repositories.Mappers
{
    //TODO: Remove virtual keywords from methods, and create interface for class (required for mocking)
    public class RentalMapper
    {
        private readonly VehicleMapper vehicleMapper;

        public RentalMapper(VehicleMapper vehicleMapper)
        {
            this.vehicleMapper = vehicleMapper;
        }

        public virtual Rental GetDomainRentalFromModelRental(Database.Models.Rental rental)
        {
            if (rental == null)
            {
                throw new ArgumentNullException();
            }

            return new Rental
            {
                Id = (short)rental.Id,
                Vehicle = vehicleMapper.GetDomainVehicleFromModelVehicle(rental.Vehicle),
                Owner = new Person(rental.OwnerName, rental.OwnerPhone),
                ReturnDate = rental.ReturnDate
            };
        }

        public virtual Database.Models.Rental GetModelRentalFromDomainRental(Rental rental)
        {
            if (rental == null)
            {
                throw new ArgumentNullException();
            }

            return new Database.Models.Rental
            {
                Id = rental.Id,
                VehicleId = rental.Vehicle.Id,
                Vehicle = vehicleMapper.GetModelVehicleFromDomainVehicle(rental.Vehicle),
                OwnerName = rental.Owner.Name,
                OwnerPhone = rental.Owner.PhoneNumber,
                ReturnDate = rental.ReturnDate
            };
        }
    }
}
