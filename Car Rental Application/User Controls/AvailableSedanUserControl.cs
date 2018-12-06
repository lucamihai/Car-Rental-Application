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

            ID = id;
            vehicleNameValueLabel.Text = vehicleName;
            FuelPercentage = 100;
            DamagePercentage = 0;
            IDManagement.MarkIDAsUnavailable(id);
        }

        public AvailableSedanUserControl(VehicleUserControl sedan)
        {
            InitializeComponent();
            ID = sedan.ID;
            vehicleNameValueLabel.Text = sedan.VehicleName;
            FuelPercentage = sedan.FuelPercentage;
            DamagePercentage = sedan.DamagePercentage;
            IDManagement.MarkIDAsUnavailable(ID);
        }

        public AvailableSedanUserControl(string vehicleName, short fuelPercent, short damagePercent)
        {
            InitializeComponent();
            short id = (short)IDManagement.GetLowestAvailableID();

            ID = id;
            vehicleNameValueLabel.Text = vehicleName;
            FuelPercentage = fuelPercent;
            DamagePercentage = damagePercent;
            IDManagement.MarkIDAsUnavailable(id);
        }

        public AvailableSedanUserControl(RentedSedanUserControl sedan)
        {
            InitializeComponent();

            short returnedVehicleID = sedan.ID;
            string returnedVehicleName = sedan.VehicleName;
            short returnedVehicleFuelPercentage = sedan.FuelPercentage;
            short returnedVehicleDamagePercentage = sedan.DamagePercentage;

            ID = returnedVehicleID;
            vehicleNameValueLabel.Text = returnedVehicleName;
            FuelPercentage = returnedVehicleFuelPercentage;
            DamagePercentage = returnedVehicleDamagePercentage;
        }

        public override string Details
        {
            get
            {
                string details = "";
                details += "Sedan " + VehicleName + ", ";
                details += "registered with the id " + ID.ToString() + ", ";
                details += "has " + FuelPercentage.ToString() + " % fuel and ";
                details += "and is " + DamagePercentage.ToString() + " % damaged";

                return details;
            }
            
        }

        public void FromDatabase(short id, string name, short fuel, short damage)
        {
            ID = id;
            vehicleNameValueLabel.Text = VehicleName;
            FuelPercentage = fuel;
            DamagePercentage = damage;
        }

        public override bool Selected
        {
            get
            {
                return selectCheckBox.Checked;
            }
            set
            {
                selectCheckBox.Checked = value;
            }
        }

        #region Set methods

        public override short ID
        {
            get
            {
                return Convert.ToInt16(IDValueLabel.Text);
            }
            protected set
            {
                IDValueLabel.Text = value.ToString();
                IDManagement.MarkIDAsUnavailable(value);
            }
        }

        public override string VehicleName
        {
            get
            {
                return vehicleNameValueLabel.Text;
            }
            protected set
            {
                vehicleNameValueLabel.Text = value;
            }
        }

        public override short FuelPercentage
        {
            get
            {
                return Convert.ToInt16(fuelPercentValueLabel.Text);
            }
            set
            {
                fuelPercentValueLabel.Text = value.ToString();
            }
        }

        public override short DamagePercentage
        {
            get
            {
                return Convert.ToInt16(damagePercentValueLabel.Text);
            }
            set
            {
                damagePercentValueLabel.Text = value.ToString();
            }
        }

        #endregion

        private void selectCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            int indexOfCurrentVehicle = mainWindow.GetIndexOfAvailableVehicle(this);
            if (selectCheckBox.Checked == true)
            {
                mainWindow.indexesOfSelectedAvailableCars.Add(indexOfCurrentVehicle);
                return;
            }
            mainWindow.indexesOfSelectedAvailableCars.Remove(indexOfCurrentVehicle);
        }

        private void buttonRent_Click(object sender, EventArgs e)
        {
            mainWindow.RentForm(this);
        }
    }
}
