using System;
using System.Diagnostics.CodeAnalysis;
using System.Windows.Forms;
using CarRentalApplication.Domain.Entities;
using CarRentalApplication.Translating;

namespace CarRentalApplication.EntityViews
{
    public partial class VehicleView : UserControl
    {
        private MainWindow mainWindow;

        public Vehicle Vehicle { get; }

        public VehicleView(Vehicle vehicle)
        {
            ValidateVehicle(vehicle);

            InitializeComponent();

            labelIdValue.Text = vehicle.Id.ToString();
            labelVehicleNameValue.Text = vehicle.Name;
            labelVehicleTypeValue.Text = vehicle.Type.ToString();
            labelFuelPercentageValue.Text = vehicle.FuelPercentage.ToString();
            labelDamagePercentageValue.Text = vehicle.DamagePercentage.ToString();

            Vehicle = vehicle;

            checkboxSelect.Click += Select;
            buttonRent.Click += Rent;
        }

        private void ValidateVehicle(Vehicle vehicle)
        {
            if (vehicle == null)
            {
                throw new ArgumentNullException($"{nameof(vehicle)} must be provided");
            }

            vehicle.ValidateAndThrow();
        }

        [ExcludeFromCodeCoverage]
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

        [ExcludeFromCodeCoverage]
        public bool InputsEnabled
        {
            set
            {
                checkboxSelect.Visible = value;
                buttonRent.Visible = value;
            }
        }

        [ExcludeFromCodeCoverage]
        public void LinkToMainWindow(MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;
        }

        [ExcludeFromCodeCoverage]
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

        [ExcludeFromCodeCoverage]
        private void Rent(object sender, EventArgs e)
        {
            mainWindow.RentForm(this.Vehicle);
        }

        [ExcludeFromCodeCoverage]
        public void UpdateLanguage(Language language)
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
