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
    public class AvailableCarsManager : ISort
    {
        public MainWindow mainWindow;
        public Panel availableCarsPanel, availableCarsElementsPanel;
        public AvailableCarsManager(Panel availableCarsPanel, Panel rentedCarsPanel)
        {
            this.availableCarsPanel = availableCarsPanel;
            this.availableCarsElementsPanel = rentedCarsPanel;
        }
        public AvailableCarsManager(MainWindow mainWindow) { this.mainWindow = mainWindow; }
        public void Link(MainWindow m) { mainWindow = m; }
        public void AddAvailableVehicle(VehicleUserControl vehicle)
        {
            availableCarsElementsPanel.VerticalScroll.Value = 0;
            mainWindow.AddToAvailableCarsList(vehicle);
            mainWindow.PopulateAvailableVehiclesPanel();
        }
        #region ISort methods

        public List<VehicleUserControl> SortListByID(List <VehicleUserControl> vehicles)
        {
            return vehicles.OrderBy(o => o.GetVehicleID()).ToList();
        }
        public List<VehicleUserControl> SortListByName(List <VehicleUserControl> vehicles)
        {
            return vehicles.OrderBy(o => o.GetVehicleName()).ToList();
        }
        public List<VehicleUserControl> SortListByType(List <VehicleUserControl> vehicles)
        {
            return vehicles.OrderBy(o => o.GetType().ToString()).ToList();
        }
        public List<VehicleUserControl> SortListByReturnDate(List <VehicleUserControl> vehicles)
        {
            return vehicles;
        }
        public List<VehicleUserControl> SortListByOwnerPhoneNumber(List <VehicleUserControl> vehicles)
        {
            return vehicles;
        }
        public List<VehicleUserControl> SortListByOwnerName(List <VehicleUserControl> vehicles)
        {
            return vehicles;
        }
        public List<VehicleUserControl> SortListByFuelPercent(List <VehicleUserControl> vehicles)
        {
            return vehicles.OrderBy(o => o.GetFuelPercentage()).ToList();
        }
        public List<VehicleUserControl> SortListByDamagePercent(List <VehicleUserControl> vehicles)
        {
            return vehicles.OrderBy(o => o.GetDamagePercentage()).ToList();
        }

        #endregion
    }
}
