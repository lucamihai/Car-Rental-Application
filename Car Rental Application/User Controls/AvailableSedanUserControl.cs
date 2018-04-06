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
            SetVehicleName(vehicleName);
            SetVehicleFuelPercentage(100);
            SetVehicleDamagePercentage(0);
        }
        public AvailableSedanUserControl(string vehicleName, short fuelPercent, short damagePercent)
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
            fuelPercentValueLabel.Text = fuelPercentage.ToString();
        }
        public void SetVehicleDamagePercentage(short damagePercentage)
        {
            this.damagePercent = damagePercentage;
            damagePercentValueLabel.Text = damagePercentage.ToString();
        }
        public string GetVehicleName() { return vehicleName; }
        public short GetFuelPercentage() { return fuelPercentage; }
        public short GetDamagePercentage() { return damagePercent; }

        #endregion
    }
}
