using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Rental_Application.Classes
{
    public class Minivan : Vehicle
    {
        public Minivan() { }
        public Minivan(string vehicleName)
        {
            this.vehicleName = vehicleName;
            damagePercent = 0;
            gasFillPercent = 100;
        }
        public Minivan(string vehicleName, float damagePercent, float gasFillPercent)
        {
            this.vehicleName = vehicleName;
            this.damagePercent = damagePercent;
            this.gasFillPercent = gasFillPercent;
        }
    }
}
