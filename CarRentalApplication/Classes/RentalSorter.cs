using System.Collections.Generic;
using System.Linq;
using CarRentalApplication.EntityViews;

namespace CarRentalApplication.Classes
{
    public class RentalSorter
    {
        public List<RentalView> SortListByID(List<RentalView> rentals)
        {
            return rentals.OrderBy( vehicle => vehicle.Id ).ToList();
        }

        public List<RentalView> SortListByVehicleID(List<RentalView> rentals)
        {
            return rentals.OrderBy(vehicle => vehicle.Vehicle.Id).ToList();
        }

        public List<RentalView> SortListByVehicleName(List<RentalView> rentals)
        {
            return rentals.OrderBy(vehicle => vehicle.Vehicle.VehicleName).ToList();
        }

        public List<RentalView> SortListByVehicleType(List<RentalView> rentals)
        {
            return rentals.OrderBy(vehicle => vehicle.Vehicle.GetType().ToString()).ToList();
        }

        public List<RentalView> SortListByVehicleFuelPercentage(List<RentalView> rentals)
        {
            return rentals.OrderBy(vehicle => vehicle.Vehicle.FuelPercentage).ToList();
        }

        public List<RentalView> SortListByVehicleDamagePercentage(List<RentalView> rentals)
        {
            return rentals.OrderBy(vehicle => vehicle.Vehicle.DamagePercentage).ToList();
        }

        public List<RentalView> SortListByOwnerName(List<RentalView> rentals)
        {
            return rentals.OrderBy( vehicle => vehicle.Owner.Name ).ToList();
        }

        public List<RentalView> SortListByOwnerPhoneNumber(List<RentalView> rentals)
        {
            return rentals.OrderBy( vehicle => vehicle.Owner.PhoneNumber ).ToList();
        }

        public List<RentalView> SortListByReturnDate(List<RentalView> rentals)
        {
            return rentals.OrderBy( vehicle => vehicle.ReturnDate ).ToList();
        }
    }
}
