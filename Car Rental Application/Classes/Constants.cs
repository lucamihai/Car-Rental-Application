using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Car_Rental_Application.User_Controls;

namespace Car_Rental_Application.Classes
{
    static class Constants
    {
        public static int SORT_BY_VEHICLE_ID = 0;
        public static int SORT_BY_VEHICLE_NAME = 1;
        public static int SORT_BY_VEHICLE_TYPE = 2;
        public static int SORT_BY_VEHICLE_FUEL_PERCENTAGE = 3;
        public static int SORT_BY_VEHICLE_DAMAGE_PERCENTAGE = 4;

        public static int SORT_BY_VEHICLE_OWNER_NAME = 3;
        public static int SORT_BY_VEHICLE_OWNER_PHONE_NUMBER = 4;
        public static int SORT_BY_VEHICLE_RETURN_DATE = 5;

        public static Type TYPE_SEDAN = new SedanUserControl().GetType();
        public static Type TYPE_MINIVAN = new MinivanUserControl().GetType();

        public static Type TYPE_RENTED_SEDAN = new RentedSedanUserControl().GetType();
        public static Type TYPE_RENTED_MINIVAN = new RentedMinivanUserControl().GetType();
        public static Type TYPE_AVAILABLE_SEDAN = new AvailableSedanUserControl().GetType();
        public static Type TYPE_AVAILABLE_MINIVAN = new AvailableMinivanUserControl().GetType();
    }
}
