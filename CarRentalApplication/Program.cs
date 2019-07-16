using System;
using System.Windows.Forms;
using CarRentalApplication.Translating;

namespace CarRentalApplication
{
    internal static class Program
    {
        public static Language Language { get; set; } = Language.FromCsvContents(Properties.Resources.English, '\\');

        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainWindow());
        }
    }
}
