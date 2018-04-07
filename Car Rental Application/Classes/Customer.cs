using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Rental_Application.Classes
{
    public class Customer
    {
        string name;
        string phoneNumber;
        public Customer() { }
        public Customer(string name, string phoneNumber)
        {
            this.name = name;
            this.phoneNumber = phoneNumber;
        }

        #region Get and Set methods

        public void SetName(string name) { this.name = name; }
        public void SetPhoneNumber(string phoneNumber) { this.phoneNumber = phoneNumber; }
        public string GetName() { return name; }
        public string GetPhoneNumber() { return phoneNumber; }

        #endregion
    }
}
