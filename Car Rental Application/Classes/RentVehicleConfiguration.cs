using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Rental_Application.Classes
{
    public static class RentVehicleConfiguration
    {
        static List<string> rentConfigurations = new List<string>();
        public static void AddRentConfiguration(string config) { rentConfigurations.Add(config); }
        public static string GetRentConfiguration()
        {
            string config = rentConfigurations.First();
            rentConfigurations.RemoveAt(0);
            return config;
        }
        public static void ClearRentConfiguration() { rentConfigurations.Clear(); }
    }
}
