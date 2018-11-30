using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Car_Rental_Application.Interfaces;
using Car_Rental_Application.User_Controls;

namespace Car_Rental_Application.Classes
{
    public class RentedCarsSorter: ISort
    {
        #region ISort methods

        public List<VehicleUserControl> SortListByID(List<VehicleUserControl> vehicles)
        {
            return vehicles.OrderBy( vehicle => vehicle.GetRentID() ).ToList();
        }

        public List<VehicleUserControl> SortListByName(List<VehicleUserControl> vehicles)
        {
            return vehicles.OrderBy( vehicle => vehicle.GetVehicleName() ).ToList();
        }

        public List<VehicleUserControl> SortListByType(List<VehicleUserControl> vehicles)
        {
            return vehicles.OrderBy( vehicle => vehicle.GetType().ToString() ).ToList();
        }

        public List<VehicleUserControl> SortListByReturnDate(List<VehicleUserControl> vehicles)
        {
            return vehicles.OrderBy( vehicle => vehicle.GetReturnDate() ).ToList();
        }

        public List<VehicleUserControl> SortListByOwnerPhoneNumber(List<VehicleUserControl> vehicles)
        {
            return vehicles.OrderBy( vehicle => vehicle.GetOwner().GetPhoneNumber() ).ToList();
        }

        public List<VehicleUserControl> SortListByOwnerName(List<VehicleUserControl> vehicles)
        {
            return vehicles.OrderBy( vehicle => vehicle.GetOwner().GetName() ).ToList();
        }

        public List<VehicleUserControl> SortListByFuelPercent(List<VehicleUserControl> vehicles)
        {
            return vehicles.OrderBy( vehicle => vehicle.GetFuelPercentage() ).ToList();
        }

        public List<VehicleUserControl> SortListByDamagePercent(List<VehicleUserControl> vehicles)
        {
            return vehicles.OrderBy( vehicle => vehicle.GetDamagePercentage() ).ToList();
        }

        #endregion
    }
}
