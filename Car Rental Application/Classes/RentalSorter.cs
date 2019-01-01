using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Car_Rental_Application.User_Controls;

namespace Car_Rental_Application.Classes
{
    public class RentalSorter
    {
        public List<Rental> SortListByID(List<Rental> rentals)
        {
            return rentals.OrderBy( vehicle => vehicle.ID ).ToList();
        }

        public List<Rental> SortListByOwnerName(List<Rental> rentals)
        {
            return rentals.OrderBy(vehicle => vehicle.Owner.Name).ToList();
        }

        public List<Rental> SortListByOwnerPhoneNumber(List<Rental> rentals)
        {
            return rentals.OrderBy(vehicle => vehicle.Owner.PhoneNumber).ToList();
        }

        public List<Rental> SortListByReturnDate(List<Rental> rentals)
        {
            return rentals.OrderBy(vehicle => vehicle.ReturnDate).ToList();
        }

        public List<Rental> SortListByVehicleName(List<Rental> rentals)
        {
            return rentals.OrderBy( vehicle => vehicle.Vehicle.VehicleName ).ToList();
        }

        public List<Rental> SortListByVehicleType(List<Rental> rentals)
        {
            return rentals.OrderBy( vehicle => vehicle.Vehicle.GetType().ToString() ).ToList();
        }

        public List<Rental> SortListByVehicleFuelPercent(List<Rental> rentals)
        {
            return rentals.OrderBy( vehicle => vehicle.Vehicle.FuelPercentage ).ToList();
        }

        public List<Rental> SortListByVehicleDamagePercent(List<Rental> rentals)
        {
            return rentals.OrderBy( vehicle => vehicle.Vehicle.DamagePercentage ).ToList();
        }
    }
}
