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
    class AvailableCars : ISort
    {
        public Panel availableCarsPanel, availableCarsPanelElements;
        public AvailableCars(Panel availableCarsPanel, Panel rentedCarsPanel)
        {
            this.availableCarsPanel = availableCarsPanel;
            this.availableCarsPanelElements = rentedCarsPanel;
        }
        #region ISort methods
        public void SortListByName(List <VehicleUserControl> vehicles)
        {

        }
        public void SortListByType(List <VehicleUserControl> vehicles)
        {

        }
        public void SortListByReturnDate(List <VehicleUserControl> vehicles)
        {

        }
        public void SortListByOwnerPhoneNumber(List <VehicleUserControl> vehicles)
        {

        }
        public void SortListByOwnerName(List <VehicleUserControl> vehicles)
        {

        }
        public void SortListByFuelPercent(List <VehicleUserControl> vehicles)
        {

        }
        public void SortListByDamagePercent(List <VehicleUserControl> vehicles)
        {

        }
        #endregion
    }
}
