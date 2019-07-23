using CarRentalApplication.Domain.Entities;

namespace CarRentalApplication.Repositories.Mappers
{
    public class RentalMapper
    {
        private readonly VehicleMapper vehicleMapper;

        public RentalMapper(VehicleMapper vehicleMapper)
        {
            this.vehicleMapper = vehicleMapper;
        }

        public Rental GetDomainRentalFromModelRental(Database.Models.Rental rental)
        {
            return new Rental
            {
                Id = (short)rental.Id,
                Vehicle = vehicleMapper.GetDomainVehicleFromModelVehicle(rental.Vehicle),
                Owner = new Person(rental.OwnerName, rental.OwnerPhone),
                ReturnDate = rental.ReturnDate
            };
        }

        public Database.Models.Rental GetModelRentalFromDomainRental(Rental rental)
        {
            return new Database.Models.Rental
            {
                Id = rental.Id,
                VehicleId = rental.Vehicle.Id,
                OwnerName = rental.Owner.Name,
                OwnerPhone = rental.Owner.PhoneNumber,
                ReturnDate = rental.ReturnDate
            };
        }
    }
}
