using System;
using System.IO;
using System.Linq;

namespace CarRentalApplication.Logging
{
    public class Logger
    {
        private string logPath;
        public string LogPath
        {
            get => logPath;
            private set
            {
                ValidateLogPath(value);
                CreateFileIfNotExists(value);
                logPath = value;
            }
        }

        public int LogEntryNumber
        {
            get
            {
                var lineCount = 0;
                using (var streamReader = new StreamReader(logPath))
                {
                    while (streamReader.ReadLine() != null)
                    {
                        lineCount++;
                    }
                }

                return lineCount;
            }
        }

        public Logger(string logPath)
        {
            LogPath = logPath;
        }

        public void WriteToLog(string data)
        {
            using (var streamWriter = File.AppendText(LogPath) )
            {
                streamWriter.WriteLine($"{LogEntryNumber}: {data}");
            }
        }

        private void ValidateLogPath(string logPath)
        {
            if (string.IsNullOrEmpty(logPath))
            {
                throw new ArgumentException($"{logPath} must be provided");
            }
        }

        private void CreateFileIfNotExists(string logPath)
        {
            if (!File.Exists(logPath))
            {
                using (var fileStream = File.Create(logPath))
                {

                } 
                //var fileStream = File.Create(logPath);
                //fileStream.Close();
            }
        }
    }
}
