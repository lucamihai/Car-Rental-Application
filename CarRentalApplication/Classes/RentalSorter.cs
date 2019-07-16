using System.Collections.Generic;
using System.Linq;
using CarRentalApplication.User_Controls;

namespace CarRentalApplication.Classes
{
    public class RentalSorter
    {
        public List<Rental> SortListByID(List<Rental> rentals)
        {
            return rentals.OrderBy( vehicle => vehicle.ID ).ToList();
        }

        public List<Rental> SortListByVehicleID(List<Rental> rentals)
        {
            return rentals.OrderBy(vehicle => vehicle.Vehicle.ID).ToList();
        }

        public List<Rental> SortListByVehicleName(List<Rental> rentals)
        {
            return rentals.OrderBy(vehicle => vehicle.Vehicle.VehicleName).ToList();
        }

        public List<Rental> SortListByVehicleType(List<Rental> rentals)
        {
            return rentals.OrderBy(vehicle => vehicle.Vehicle.GetType().ToString()).ToList();
        }

        public List<Rental> SortListByVehicleFuelPercentage(List<Rental> rentals)
        {
            return rentals.OrderBy(vehicle => vehicle.Vehicle.FuelPercentage).ToList();
        }

        public List<Rental> SortListByVehicleDamagePercentage(List<Rental> rentals)
        {
            return rentals.OrderBy(vehicle => vehicle.Vehicle.DamagePercentage).ToList();
        }

        public List<Rental> SortListByOwnerName(List<Rental> rentals)
        {
            return rentals.OrderBy( vehicle => vehicle.Owner.Name ).ToList();
        }

        public List<Rental> SortListByOwnerPhoneNumber(List<Rental> rentals)
        {
            return rentals.OrderBy( vehicle => vehicle.Owner.PhoneNumber ).ToList();
        }

        public List<Rental> SortListByReturnDate(List<Rental> rentals)
        {
            return rentals.OrderBy( vehicle => vehicle.ReturnDate ).ToList();
        }
    }
}
