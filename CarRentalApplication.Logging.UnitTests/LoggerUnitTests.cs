using System;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CarRentalApplication.Logging.UnitTests
{
    [TestClass]
    public class LoggerUnitTests
    {
        private Logger logger;
        private string logPath;

        [TestInitialize]
        public void Setup()
        {
            logPath = $"{Environment.CurrentDirectory}\\log.txt";
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SettingLogPathToNullThrowsArgumentException()
        {
            logger = new Logger(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SettingLogPathToEmptyThrowsArgumentException()
        {
            logger = new Logger(string.Empty);
        }

        [TestMethod]
        public void SettingLogPathToUnexistingFileCreatesTheFile()
        {
            Assert.IsFalse(File.Exists(logPath));

            logger = new Logger(logPath);

            Assert.IsTrue(File.Exists(logPath));
        }

        [TestMethod]
        public void LogEntryNumberIsSetBasedOnLogFileLineNumber1()
        {
            logger = new Logger(logPath);

            var expectedLogEntryNumber = GetLineCountFromFile(logPath) + 1;
            Assert.AreEqual(expectedLogEntryNumber, logger.LogEntryNumber);
        }

        [TestMethod]
        public void LogEntryNumberIsSetBasedOnLogFileLineNumber2()
        {
            var fileStream = File.Create(logPath);
            using (var streamWriter = new StreamWriter(fileStream))
            {
                streamWriter.WriteLine("Line1");
                streamWriter.WriteLine("Line2");
            }
            fileStream.Close();

            logger = new Logger(logPath);

            var expectedLogEntryNumber = GetLineCountFromFile(logPath) + 1;
            Assert.AreEqual(expectedLogEntryNumber, logger.LogEntryNumber);
        }

        [TestMethod]
        public void WriteToLogIncreasesLogEntryNumber()
        {
            logger = new Logger(logPath);

            var logEntryNumberBeforeLogWriting = 1;

            logger.WriteToLog("something");

            var logEntryNumberAfterLogWriting = logger.LogEntryNumber;

            Assert.IsTrue(logEntryNumberAfterLogWriting == logEntryNumberBeforeLogWriting + 1);
        }

        private int GetLineCountFromFile(string filePath)
        {
            return File.ReadLines(filePath).Count();
        }

        [TestCleanup]
        public void Cleanup()
        {
            File.Delete(logPath);
        }
    }
}
