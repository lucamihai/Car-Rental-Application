using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Rental_Application.Classes
{
    class LogMaganer
    {
        int counter;
        string path;
        public LogMaganer() { counter = 0; }
        public void SetPath(string path) { this.path = path; }
        public string GetPath() { return path; }
        public void ReinitiateCounter() { counter = 0; }
        public void SetCounter(int counter) { this.counter = counter; }
        public void WriteToLog(string data)
        {
            using (StreamWriter w = File.AppendText(path))
            {
                w.WriteLine("Order " + counter + " : " + data);
            }
        }
    }
}
