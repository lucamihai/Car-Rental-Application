using CarRentalApplication.Translating;

namespace CarRentalApplication.User_Controls
{
    public partial class Minivan : Vehicle
    {
        public Minivan()
        {
            InitializeComponent();
        }

        public Minivan(string vehicleName, short fuelPercent = 0, short damagePercent = 0) : base(vehicleName, fuelPercent, damagePercent)
        {

        }
        public Minivan(short id, string vehicleName, short fuelPercent = 0, short damagePercent = 0) : base(id, vehicleName, fuelPercent, damagePercent)
        {

        }


        public Minivan(Vehicle vehicle) : base(vehicle)
        {

        }

        public override void UpdateLanguage(Language language)
        {
            labelID.Text = language.Translate("ID");
            labelVehicleName.Text = language.Translate("Vehicle name");
            labelVehicleType.Text = language.Translate("Vehicle type");
            labelVehicleTypeValue.Text = language.Translate("Minivan");
            labelDamagePercentage.Text = language.Translate("Damage percentage");
            labelFuelPercentage.Text = language.Translate("Fuel percentage");

            checkboxSelect.Text = language.Translate("Select");

            buttonRent.Text = language.Translate("Rent");
        }

        public override object Clone()
        {
            return new Minivan(ID, VehicleName, FuelPercentage, DamagePercentage);
        }
    }
}
