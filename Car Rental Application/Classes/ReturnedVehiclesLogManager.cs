using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Rental_Application.Classes
{
    class ReturnedVehiclesLogManager
    {
        int entryNumber;
        public string Path
        {
            get; set;
        }

        public ReturnedVehiclesLogManager()
        {
            entryNumber = 1;
        }

        public void WriteToLog(string data)
        {
            using ( StreamWriter w = File.AppendText(Path) )
            {
                w.WriteLine("Order " + entryNumber + ": " + data);
                entryNumber++;
            }
        }
    }
}
