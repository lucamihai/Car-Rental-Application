using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Rental_Application.Classes
{
    class Logger
    {
        string _Path;
        int logEntryNumber;
        public string Path
        {
            get
            {
                return _Path;
            }
            set
            {
                _Path = value;
                DetermineEntryNumber();
            }
        }

        public Logger(string path)
        {
            logEntryNumber = 1;
            Path = path;
        }

        public void WriteToLog(string data)
        {
            using ( StreamWriter streamWriter = File.AppendText(Path) )
            {
                streamWriter.WriteLine(string.Format("{0}: {1}", logEntryNumber, data));
                logEntryNumber++;
            }
        }

        void DetermineEntryNumber()
        {
            logEntryNumber = 1;

            if (File.Exists(Path))
            {
                int lineCount = File.ReadLines(Path).Count();
                logEntryNumber = lineCount + 1;
            }
        }
    }
}
