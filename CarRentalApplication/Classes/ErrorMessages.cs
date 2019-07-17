using System.Diagnostics.CodeAnalysis;
using CarRentalApplication.Translating;

namespace CarRentalApplication.Classes
{
    [ExcludeFromCodeCoverage]
    internal static class ErrorMessages
    {
        // ----- MainWindow possible errors
        public static string NoVehiclesToSelect = Program.Language.Translate("There are no vehicles to select");
        public static string NoVehiclesToRemove = Program.Language.Translate("There are no vehicles to remove");
        public static string NoVehiclesSelected = Program.Language.Translate("No vehicles have been selected");
        public static string NoRentalsToSelect = Program.Language.Translate("There are no rentals to select");
        public static string NoRentalsToRemove = Program.Language.Translate("There are no rentals to remove");
        public static string NoRentalsSelected = Program.Language.Translate("No rentals have been selected");
        public static string NoLogCreated = Program.Language.Translate("Log file doesn't exist");
        // -----

        // ----- FormAddVehicle possible errors
        public static string VehicleNameNotProvided = Program.Language.Translate("Vehicle name must be provided");
        // -----

        // ----- FormRentVehicle possible errors
        public static string OwnerNameNotProvided = Program.Language.Translate("Owner's name must be provided");
        public static string OwnerPhoneNotProvided = Program.Language.Translate("Owner's phone must be provided");
        // -----

        // ----- FormSqlConnection possible errors
        public static string DataSourceNotProvided = Program.Language.Translate("Data source must be provided");
        public static string UserIdNotProvided = Program.Language.Translate("UserID must be provided");
        public static string PasswordNotProvided = Program.Language.Translate("Password must be provided");
        public static string InitialCatalogNotProvided = Program.Language.Translate("Initial catalog must be provided");
        // -----

        public static void UpdateLanguage(Language language)
        {
            NoVehiclesToSelect = language.Translate("There are no vehicles to select");
            NoVehiclesToRemove = language.Translate("There are no vehicles to remove");
            NoVehiclesSelected = language.Translate("No vehicles have been selected");
            NoRentalsToSelect = language.Translate("There are no rentals to select");
            NoRentalsToRemove = language.Translate("There are no rentals to remove");
            NoRentalsSelected = language.Translate("No rentals have been selected");
            NoLogCreated = language.Translate("Log file doesn't exist");

            VehicleNameNotProvided = language.Translate("Vehicle name must be provided");

            OwnerNameNotProvided = language.Translate("Owner's name must be provided");
            OwnerPhoneNotProvided = language.Translate("Owner's phone must be provided");

            DataSourceNotProvided = language.Translate("Data source must be provided");
            UserIdNotProvided = language.Translate("UserID must be provided");
            PasswordNotProvided = language.Translate("Password must be provided");
            InitialCatalogNotProvided = language.Translate("Initial catalog must be provided");
        }
    }
}