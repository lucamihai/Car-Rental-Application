using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Car_Rental_Application.Classes;

namespace Car_Rental_Application.User_Controls
{
    public partial class AvailableSedanUserControl : SedanUserControl
    {

        public AvailableSedanUserControl()
        {
            InitializeComponent();
        }

        public AvailableSedanUserControl(string vehicleName)
        {
            InitializeComponent();
            short id = (short)IDManagement.GetLowestAvailableID();

            SetVehicleID(id);
            SetVehicleName(vehicleName);
            SetVehicleFuelPercentage(100);
            SetVehicleDamagePercentage(0);
            IDManagement.MarkIDAsUnavailable(id);
        }
        public AvailableSedanUserControl(string vehicleName, short fuelPercent, short damagePercent)
        {
            InitializeComponent();
            short id = (short)IDManagement.GetLowestAvailableID();

            SetVehicleID(id);
            SetVehicleName(vehicleName);
            SetVehicleFuelPercentage(fuelPercent);
            SetVehicleDamagePercentage(damagePercent);
            IDManagement.MarkIDAsUnavailable(id);
        }
        #region Set methods

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
        public void SetVehicleFuelPercentage(short fuelPercentage)
        {
            this.fuelPercentage = fuelPercentage;
            fuelPercentValueLabel.Text = fuelPercentage.ToString();
        }
        public void SetVehicleDamagePercentage(short damagePercentage)
        {
            this.damagePercent = damagePercentage;
            damagePercentValueLabel.Text = damagePercentage.ToString();
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
    }
}
