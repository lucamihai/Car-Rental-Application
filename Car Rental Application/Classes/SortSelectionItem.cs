using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Rental_Application.Classes
{
    class SortSelectionItem
    {
        public SortSelectionItem(string name, int value)
        {
            Name = name;
            Value = value;
        }

        public string Name
        {
            get;
            private set;
        }

        public int Value
        {
            get;
            private set;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
