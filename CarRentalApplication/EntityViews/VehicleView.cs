using System;
using System.Windows.Forms;
using CarRentalApplication.Classes;
using CarRentalApplication.Domain.Entities;
using CarRentalApplication.Translating;

namespace CarRentalApplication.EntityViews
{
    public partial class VehicleView : UserControl
    {
        private MainWindow mainWindow;

        public Vehicle Vehicle { get; private set; }

        public VehicleView()
        {
            InitializeComponent();
        }

        public VehicleView(Vehicle vehicle)
        {
            InitializeComponent();

            Id = vehicle.Id;
            VehicleName = vehicle.Name;
            labelVehicleTypeValue.Text = vehicle.Type;
            FuelPercentage = vehicle.FuelPercentage;
            DamagePercentage = vehicle.DamagePercentage;

            Vehicle = vehicle;

            checkboxSelect.Click += Select;
            buttonRent.Click += Rent;
        }


        #region Properties

        public bool Selected
        {
            get => checkboxSelect.Checked;
            set
            {
                checkboxSelect.Checked = value;

                if (mainWindow != null)
                {
                    var indexOfCurrentVehicle = mainWindow.GetVehicleIndex(this);

                    if (checkboxSelect.Checked)
                    {
                        mainWindow.SelectVehicle(indexOfCurrentVehicle);
                    }
                    else
                    {
                        mainWindow.DeselectVehicle(indexOfCurrentVehicle);
                    }
                }
            }
        }

        public short Id
        {
            get => Convert.ToInt16(labelIdValue.Text);
            private set
            {
                labelIdValue.Text = value.ToString();
                IDManagement.MarkVehicleIDAsUnavailable(value);
            }
        }

        public string VehicleName
        {
            get => labelVehicleNameValue.Text;
            private set => labelVehicleNameValue.Text = value;
        }

        public short FuelPercentage
        {
            get => Convert.ToInt16(labelFuelPercentageValue.Text);
            set => labelFuelPercentageValue.Text = value.ToString();
        }

        public short DamagePercentage
        {
            get => Convert.ToInt16(labelDamagePercentageValue.Text);
            set => labelDamagePercentageValue.Text = value.ToString();
        }

        public bool InputsEnabled
        {
            set
            {
                checkboxSelect.Visible = value;
                buttonRent.Visible = value;
            }
        }

        #endregion


        public void LinkToMainWindow(MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;
        }

        private void Select(object sender, EventArgs e)
        {
            var indexOfCurrentVehicle = mainWindow.GetVehicleIndex(this);

            if (checkboxSelect.Checked)
            {
                mainWindow.SelectVehicle(indexOfCurrentVehicle);
                return;
            }

            mainWindow.DeselectVehicle(indexOfCurrentVehicle);
        }

        private void Rent(object sender, EventArgs e)
        {
            mainWindow.RentForm(this.Vehicle);
        }

        public virtual void UpdateLanguage(Language language)
        {
            labelId.Text = language.Translate("ID");
            labelVehicleName.Text = language.Translate("Vehicle name");
            labelVehicleType.Text = language.Translate("Vehicle type");
            labelVehicleTypeValue.Text = language.Translate(Name);
            labelDamagePercentage.Text = language.Translate("Damage percentage");
            labelFuelPercentage.Text = language.Translate("Fuel percentage");

            checkboxSelect.Text = language.Translate("Select");

            buttonRent.Text = language.Translate("Rent");
        }

    }
}
