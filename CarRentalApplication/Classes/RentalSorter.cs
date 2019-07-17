using System.Collections.Generic;
using System.Linq;
using CarRentalApplication.EntityViews;

namespace CarRentalApplication.Classes
{
    public class RentalSorter
    {
        public List<RentalView> SortListById(List<RentalView> rentals)
        {
            return rentals.OrderBy(rentalView => rentalView.Id).ToList();
        }

        public List<RentalView> SortListByVehicleId(List<RentalView> rentals)
        {
            return rentals.OrderBy(rentalView => rentalView.RentedVehicle.Id).ToList();
        }

        public List<RentalView> SortListByVehicleName(List<RentalView> rentals)
        {
            return rentals.OrderBy(rentalView => rentalView.RentedVehicle.Name).ToList();
        }

        public List<RentalView> SortListByVehicleType(List<RentalView> rentals)
        {
            return rentals.OrderBy(rentalView => rentalView.RentedVehicle.GetType().ToString()).ToList();
        }

        public List<RentalView> SortListByVehicleFuelPercentage(List<RentalView> rentals)
        {
            return rentals.OrderBy(rentalView => rentalView.RentedVehicle.FuelPercentage).ToList();
        }

        public List<RentalView> SortListByVehicleDamagePercentage(List<RentalView> rentals)
        {
            return rentals.OrderBy(rentalView => rentalView.RentedVehicle.DamagePercentage).ToList();
        }

        public List<RentalView> SortListByOwnerName(List<RentalView> rentals)
        {
            return rentals.OrderBy(rentalView => rentalView.Owner.Name).ToList();
        }

        public List<RentalView> SortListByOwnerPhoneNumber(List<RentalView> rentals)
        {
            return rentals.OrderBy(rentalView => rentalView.Owner.PhoneNumber).ToList();
        }

        public List<RentalView> SortListByReturnDate(List<RentalView> rentals)
        {
            return rentals.OrderBy(rentalView => rentalView.ReturnDate).ToList();
        }
    }
}
