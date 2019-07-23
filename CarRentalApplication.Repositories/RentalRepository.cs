using System;
using System.Collections.Generic;
using System.Linq;
using CarRentalApplication.Database;
using CarRentalApplication.Domain.Entities;
using CarRentalApplication.Repositories.Mappers;

namespace CarRentalApplication.Repositories
{
    public class RentalRepository
    {
        public CarRentalContext CarRentalContext { get; }
        private readonly RentalMapper rentalMapper;

        public RentalRepository(CarRentalContext carRentalContext, RentalMapper rentalMapper)
        {
            CarRentalContext = carRentalContext;
            this.rentalMapper = rentalMapper;
        }

        public List<Rental> GetRentals()
        {
            var rentals = new List<Rental>();

            var databaseRentals = CarRentalContext.Rentals.ToList();

            foreach (var databaseRental in databaseRentals)
            {
                rentals.Add(rentalMapper.GetDomainRentalFromModelRental(databaseRental));
            }

            return rentals;
        }

        public void AddRental(Rental rental)
        {
            ValidateRental(rental);

            var databaseRental = rentalMapper.GetModelRentalFromDomainRental(rental);
            CarRentalContext.Rentals.Add(databaseRental);
            CarRentalContext.SaveChanges();
        }

        private void ValidateRental(Rental rental)
        {
            if (rental == null)
            {
                throw new ArgumentNullException($"{nameof(rental)} must be provided");
            }

            rental.ValidateAndThrow();
        }
    }
}
