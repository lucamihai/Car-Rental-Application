using System;
using System.IO;

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
                UpdateLogEntryNumberBasedOnFileContents(value);
                logPath = value;
            }
        }

        public int LogEntryNumber { get; private set; }

        public Logger(string logPath)
        {
            LogPath = logPath;
        }

        public void WriteToLog(string data)
        {
            using (var streamWriter = File.AppendText(LogPath) )
            {
                streamWriter.WriteLine($"{LogEntryNumber}: {data}");
                LogEntryNumber++;
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
                File.Create(logPath).Close();
            }
        }

        private void UpdateLogEntryNumberBasedOnFileContents(string logPath)
        {
            LogEntryNumber = 1;

            using (var streamReader = new StreamReader(logPath))
            {
                while (streamReader.ReadLine() != null)
                {
                    LogEntryNumber++;
                }
            }
        }
    }
}
