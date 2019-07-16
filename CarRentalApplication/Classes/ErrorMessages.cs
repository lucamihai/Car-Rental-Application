using CarRentalApplication.Translating;

namespace CarRentalApplication.Classes
{
    static class ErrorMessages
    {
        // ----- MainWindow possible errors
        public static string NO_VEHICLES_TO_SELECT = Program.Language.Translate("There are no vehicles to select");
        public static string NO_VEHICLES_TO_REMOVE = Program.Language.Translate("There are no vehicles to remove");
        public static string NO_VEHICLES_SELECTED = Program.Language.Translate("No vehicles have been selected");
        public static string NO_RENTALS_TO_SELECT = Program.Language.Translate("There are no rentals to select");
        public static string NO_RENTALS_TO_REMOVE = Program.Language.Translate("There are no rentals to remove");
        public static string NO_RENTALS_SELECTED = Program.Language.Translate("No rentals have been selected");
        public static string NO_LOG_CREATED = Program.Language.Translate("Log file doesn't exist");
        // -----

        // ----- FormAddVehicle possible errors
        public static string VEHICLE_NAME_NOT_PROVIDED = Program.Language.Translate("Vehicle name must be provided");
        // -----

        // ----- FormRentVehicle possible errors
        public static string OWNER_NAME_NOT_PROVIDED = Program.Language.Translate("Owner's name must be provided");
        public static string OWNER_PHONE_NOT_PROVIDED = Program.Language.Translate("Owner's phone must be provided");
        // -----

        // ----- FormSqlConnection possible errors
        public static string DATA_SOURCE_NOT_PROVIDED = Program.Language.Translate("Data source must be provided");
        public static string USER_ID_NOT_PROVIDED = Program.Language.Translate("UserID must be provided");
        public static string PASSWORD_NOT_PROVIDED = Program.Language.Translate("Password must be provided");
        public static string INITIAL_CATALOG_NOT_PROVIDED = Program.Language.Translate("Initial catalog must be provided");
        // -----

        public static void UpdateLanguage(Language language)
        {
            NO_VEHICLES_TO_SELECT = language.Translate("There are no vehicles to select");
            NO_VEHICLES_TO_REMOVE = language.Translate("There are no vehicles to remove");
            NO_VEHICLES_SELECTED = language.Translate("No vehicles have been selected");
            NO_RENTALS_TO_SELECT = language.Translate("There are no rentals to select");
            NO_RENTALS_TO_REMOVE = language.Translate("There are no rentals to remove");
            NO_RENTALS_SELECTED = language.Translate("No rentals have been selected");
            NO_LOG_CREATED = language.Translate("Log file doesn't exist");

            VEHICLE_NAME_NOT_PROVIDED = language.Translate("Vehicle name must be provided");

            OWNER_NAME_NOT_PROVIDED = language.Translate("Owner's name must be provided");
            OWNER_PHONE_NOT_PROVIDED = language.Translate("Owner's phone must be provided");

            DATA_SOURCE_NOT_PROVIDED = language.Translate("Data source must be provided");
            USER_ID_NOT_PROVIDED = language.Translate("UserID must be provided");
            PASSWORD_NOT_PROVIDED = language.Translate("Password must be provided");
            INITIAL_CATALOG_NOT_PROVIDED = language.Translate("Initial catalog must be provided");
        }
    }
}
