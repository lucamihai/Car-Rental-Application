using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Rental_Application.Classes
{
    public class Sedan : Vehicle
    {
        public Sedan() { }
        public Sedan(string vehicleName)
        {
            this.vehicleName = vehicleName;
            damagePercent = 0;
            gasFillPercent = 100;
        }
        public Sedan(string vehicleName, float damagePercent, float gasFillPercent)
        {
            this.vehicleName = vehicleName;
            this.damagePercent = damagePercent;
            this.gasFillPercent = gasFillPercent;
        }
    }
}
