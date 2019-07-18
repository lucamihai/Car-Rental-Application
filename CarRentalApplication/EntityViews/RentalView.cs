using System;
using System.Diagnostics.CodeAnalysis;
using System.Windows.Forms;
using CarRentalApplication.Domain.Entities;
using CarRentalApplication.Translating;

namespace CarRentalApplication.EntityViews
{
    public partial class RentalView : UserControl
    {
        private MainWindow mainWindow;
        private readonly VehicleView rentedVehicleView;

        public Rental Rental { get; }

        public RentalView(Rental rental)
        {
            ValidateRental(rental);

            InitializeComponent();

            Rental = rental;

            labelIDValue.Text = rental.Id.ToString();
            labelOwnerNameValue.Text = rental.Owner.Name;
            labelOwnerPhoneValue.Text = rental.Owner.PhoneNumber;
            labelReturnDateValue.Text = rental.ReturnDate.ToShortDateString();

            rentedVehicleView = new VehicleView(Rental.Vehicle);
            rentedVehicleView.InputsEnabled = false;
            panelVehicle.Controls.Add(rentedVehicleView);
        }

        private void ValidateRental(Rental rental)
        {
            if (rental == null)
            {
                throw new ArgumentNullException($"{nameof(rental)} must be provided");
            }

            rental.ValidateAndThrow();
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
                    var rentalIndex = mainWindow.GetRentalIndex(this);

                    if (checkboxSelect.Checked)
                    {
                        mainWindow.SelectRental(rentalIndex);
                    }
                    else
                    {
                        mainWindow.DeselectRental(rentalIndex);
                    }
                }
            }
        }

        [ExcludeFromCodeCoverage]
        public void LinkToMainWindow(MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;
        }

        [ExcludeFromCodeCoverage]
        public void UpdateLanguage(Language language)
        {
            labelID.Text = language.Translate("ID");
            labelOwnerName.Text = language.Translate("Owner name");
            labelOwnerPhone.Text = language.Translate("Owner phone");
            labelReturnDate.Text = language.Translate("Return date");
            labelVehicle.Text = language.Translate("Vehicle");
            checkboxSelect.Text = language.Translate("Select");
            buttonReturn.Text = language.Translate("Return");

            rentedVehicleView.UpdateLanguage(language);
        }

        [ExcludeFromCodeCoverage]
        private void Return(object sender, EventArgs e)
        {
            mainWindow.ReturnForm(this.Rental);
        }

        [ExcludeFromCodeCoverage]
        private void Select(object sender, EventArgs e)
        {
            var rentalIndex = mainWindow.GetRentalIndex(this);

            if (checkboxSelect.Checked)
            {
                mainWindow.SelectRental(rentalIndex);
            }
            else
            {
                mainWindow.DeselectRental(rentalIndex);
            }
        }
    }
}
