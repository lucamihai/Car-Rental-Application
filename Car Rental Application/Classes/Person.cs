using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Rental_Application.Classes
{
    public class Person
    {
        public Person(string name, string phoneNumber)
        {
            Name = name;
            PhoneNumber = phoneNumber;
        }

        public string Name
        {
            get;
            private set;
        }

        public string PhoneNumber
        {
            get;
            private set;
        }
    }
}
