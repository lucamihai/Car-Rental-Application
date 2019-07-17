using System.Collections.Generic;
using System.Linq;
using CarRentalApplication.EntityViews;

namespace CarRentalApplication.Classes
{
    public class VehicleSorter
    {
        public List<VehicleView> SortListByID(List <VehicleView> vehicles)
        {
            return vehicles.OrderBy( vehicle => vehicle.Id ).ToList();
        }

        public List<VehicleView> SortListByName(List <VehicleView> vehicles)
        {
            return vehicles.OrderBy( vehicle => vehicle.VehicleName ).ToList();
        }

        public List<VehicleView> SortListByType(List <VehicleView> vehicles)
        {
            return vehicles.OrderBy( vehicle => vehicle.GetType().ToString() ).ToList();
        }

        public List<VehicleView> SortListByFuelPercent(List <VehicleView> vehicles)
        {
            return vehicles.OrderBy( vehicle => vehicle.FuelPercentage ).ToList();
        }

        public List<VehicleView> SortListByDamagePercent(List <VehicleView> vehicles)
        {
            return vehicles.OrderBy( vehicle => vehicle.DamagePercentage ).ToList();
        }
    }
}
