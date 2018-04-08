using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Car_Rental_Application.Interfaces;
using Car_Rental_Application.Classes;

namespace Car_Rental_Application.User_Controls
{
    public partial class AvailableMinivanUserControl : MinivanUserControl
    {
        public AvailableMinivanUserControl()
        {
            InitializeComponent();
        }
        public AvailableMinivanUserControl(string vehicleName)
        {
            InitializeComponent();
            short id = (short)IDManagement.GetLowestAvailableID();

            SetVehicleID(id);
            SetVehicleName(vehicleName);
            SetVehicleFuelPercentage(100);
            SetVehicleDamagePercentage(0);
            IDManagement.MarkIDAsUnavailable(id);
        }
        public AvailableMinivanUserControl(string vehicleName, short fuelPercent, short damagePercent)
        {
            InitializeComponent();
            short id = (short)IDManagement.GetLowestAvailableID();

            SetVehicleID(id);
            SetVehicleName(vehicleName);
            SetVehicleFuelPercentage(fuelPercent);
            SetVehicleDamagePercentage(damagePercent);
            IDManagement.MarkIDAsUnavailable(id);
        }
        public AvailableMinivanUserControl(RentedMinivanUserControl minivan)
        {
            InitializeComponent();

            short returnedVehicleID = minivan.GetVehicleID();
            string returnedVehicleName = minivan.GetVehicleName();
            short returnedVehicleFuelPercentage = minivan.GetFuelPercentage();
            short returnedVehicleDamagePercentage = minivan.GetDamagePercentage();

            SetVehicleID(returnedVehicleID);
            SetVehicleName(returnedVehicleName);
            SetVehicleFuelPercentage(returnedVehicleFuelPercentage);
            SetVehicleDamagePercentage(returnedVehicleDamagePercentage);
        }
        #region Set  methods

        public void SetVehicleID(short id)
        {
            this.id = id;
            IDValueLabel.Text = id.ToString();
        }
        public void SetVehicleName(string vehicleName)
        {
            this.vehicleName = vehicleName;
            vehicleNameValueLabel.Text = vehicleName;
        }
        public override void SetVehicleFuelPercentage(short fuelPercentage)
        {
            this.fuelPercentage = fuelPercentage;
            fuelPercentValueLabel.Text = fuelPercentage.ToString();
        }
        public override void SetVehicleDamagePercentage(short damagePercent)
        {
            this.damagePercent = damagePercent;
            damagePercentValueLabel.Text = damagePercent.ToString();
        }

        #endregion

        private void selectCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (selectCheckBox.Checked == true)
            {
                mainWindow.indexesOfSelectedAvailableCars.Add(id);
                return;
            }
            mainWindow.indexesOfSelectedAvailableCars.Remove(id);
        }

        private void buttonRent_Click(object sender, EventArgs e)
        {
            rentVehicleUserControl.SelectVehicleToBeRent(this);
            mainWindow.RentMenu();
        }
    }
}
