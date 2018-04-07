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
    public partial class RentedMinivanUserControl : MinivanUserControl
    {

        public RentedMinivanUserControl()
        {
            InitializeComponent();
        }
        public RentedMinivanUserControl(string vehicleName)
        {
            InitializeComponent();
            SetVehicleName(vehicleName);
            SetVehicleFuelPercentage(100);
            SetVehicleDamagePercentage(0);
        }
        public RentedMinivanUserControl(string vehicleName, short fuelPercent, short damagePercent)
        {
            InitializeComponent();
            SetVehicleName(vehicleName);
            SetVehicleFuelPercentage(fuelPercent);
            SetVehicleDamagePercentage(damagePercent);
        }
        #region Set and Get methods

        public void SetVehicleName(string vehicleName)
        {
            this.vehicleName = vehicleName;
            vehicleNameValueLabel.Text = vehicleName;
        }
        public void SetVehicleFuelPercentage(short fuelPercentage)
        {
            this.fuelPercentage = fuelPercentage;
        }
        public void SetVehicleDamagePercentage(short damagePercentage)
        {
            this.damagePercent = damagePercentage;
        }

        #endregion

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
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
