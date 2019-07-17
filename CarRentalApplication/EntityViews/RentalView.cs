using System;
using System.Windows.Forms;
using CarRentalApplication.Classes;
using CarRentalApplication.Domain.Entities;
using CarRentalApplication.Translating;

namespace CarRentalApplication.EntityViews
{
    public partial class RentalView : UserControl
    {
        private MainWindow mainWindow;
        private VehicleView rentedVehicleView;
        private Person owner;
        private DateTime returnDate;

        public Vehicle RentedVehicle { get; private set; }
        public Rental Rental { get; private set; }

        public RentalView()
        {
            InitializeComponent();
        }

        public RentalView(Rental rental)
        {
            InitializeComponent();

            Rental = rental;

            Id = rental.Id;
            RentedVehicle = rental.Vehicle;
            Owner = rental.Owner;
            ReturnDate = rental.ReturnDate;

            var rentedVehicleView = new VehicleView(RentedVehicle);
            rentedVehicleView.InputsEnabled = false;
            panelVehicle.Controls.Add(rentedVehicleView);
        }

        #region Properties

        public string Details
        {
            get
            {
                var details = string.Empty;
                details += "Sedan, id " + Id + ", ";
                details += "has " + rentedVehicleView.FuelPercentage + "% fuel, ";
                details += "is " + rentedVehicleView.DamagePercentage + " % damaged, ";
                details += "owned by: " + Owner.Name + ", ";
                details += "phone number: " + Owner.PhoneNumber + ", ";
                details += "return date: " + ReturnDate.ToShortDateString();

                return details;
            }
        }

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

        public short Id
        {
            get => Convert.ToInt16(labelIDValue.Text);
            private set
            {
                labelIDValue.Text = value.ToString();
                IDManagement.MarkVehicleIDAsUnavailable(value);
            }
        }

        public Person Owner
        {
            get => owner;
            private set
            {
                owner = value;
                labelOwnerNameValue.Text = owner.Name;
                labelOwnerPhoneValue.Text = owner.PhoneNumber;
            }
        }

        public DateTime ReturnDate
        {
            get => returnDate;
            private set
            {
                returnDate = value;
                labelReturnDateValue.Text = returnDate.ToShortDateString();
            }
        }

        #endregion

        public void LinkToMainWindow(MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;
        }

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

        private void Return(object sender, EventArgs e)
        {
            mainWindow.ReturnForm(this.Rental);
        }

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
