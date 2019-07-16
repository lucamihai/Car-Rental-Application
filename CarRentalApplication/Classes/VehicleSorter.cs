using System.Collections.Generic;
using System.Linq;
using Car_Rental_Application.User_Controls;

namespace CarRentalApplication.Classes
{
    public class VehicleSorter
    {
        public List<Vehicle> SortListByID(List <Vehicle> vehicles)
        {
            return vehicles.OrderBy( vehicle => vehicle.ID ).ToList();
        }

        public List<Vehicle> SortListByName(List <Vehicle> vehicles)
        {
            return vehicles.OrderBy( vehicle => vehicle.VehicleName ).ToList();
        }

        public List<Vehicle> SortListByType(List <Vehicle> vehicles)
        {
            return vehicles.OrderBy( vehicle => vehicle.GetType().ToString() ).ToList();
        }

        public List<Vehicle> SortListByFuelPercent(List <Vehicle> vehicles)
        {
            return vehicles.OrderBy( vehicle => vehicle.FuelPercentage ).ToList();
        }

        public List<Vehicle> SortListByDamagePercent(List <Vehicle> vehicles)
        {
            return vehicles.OrderBy( vehicle => vehicle.DamagePercentage ).ToList();
        }
    }
}
