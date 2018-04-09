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
    public class RentedCarsManager: ISort
    {
        static List<string> rentConfigurations;
        public static void AddRentConfiguration(string config) { rentConfigurations.Add(config); }
        public static string GetRentConfiguration()
        {
            string config = rentConfigurations.First();
            rentConfigurations.RemoveAt(0);
            return config;
        }
        public static void ClearRentConfiguration() { rentConfigurations.Clear(); }
        public Panel rentedCarsPanel, rentedCarsElementsPanel;
        public MainWindow mainWindow;
        public RentedCarsManager(Panel rentedCarsPanel, Panel rentedCarsElementsPanel)
        {
            this.rentedCarsPanel = rentedCarsPanel;
            this.rentedCarsElementsPanel = rentedCarsElementsPanel;
            rentConfigurations = new List<string>();
        }
        public void RentVehicle(VehicleUserControl vehicle)
        {
            rentedCarsElementsPanel.VerticalScroll.Value = 0;
            mainWindow.AddToRentedCarsList(vehicle);
            mainWindow.PopulateRentedVehiclesPanel();
        }
        public void Link(MainWindow m) { mainWindow = m; }
        

        #region ISort methods
        public List<VehicleUserControl> SortListByID(List<VehicleUserControl> vehicles)
        {
            return vehicles.OrderBy(o => o.GetVehicleID()).ToList();
        }
        public List<VehicleUserControl> SortListByName(List<VehicleUserControl> vehicles)
        {
            return vehicles.OrderBy(o => o.GetVehicleName()).ToList();
        }
        public List<VehicleUserControl> SortListByType(List<VehicleUserControl> vehicles)
        {
            return vehicles;
        }
        public List<VehicleUserControl> SortListByReturnDate(List<VehicleUserControl> vehicles)
        {
            return vehicles;
        }
        public List<VehicleUserControl> SortListByOwnerPhoneNumber(List<VehicleUserControl> vehicles)
        {
            return vehicles;
        }
        public List<VehicleUserControl> SortListByOwnerName(List<VehicleUserControl> vehicles)
        {
            return vehicles;
        }
        public List<VehicleUserControl> SortListByFuelPercent(List<VehicleUserControl> vehicles)
        {
            return vehicles.OrderBy(o => o.GetFuelPercentage()).ToList();
        }
        public List<VehicleUserControl> SortListByDamagePercent(List<VehicleUserControl> vehicles)
        {
            return vehicles.OrderBy(o => o.GetDamagePercentage()).ToList();
        }
        #endregion
    }
}
