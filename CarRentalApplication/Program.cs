using System;
using System.Diagnostics.CodeAnalysis;
using System.Windows.Forms;
using CarRentalApplication.Translating;

namespace CarRentalApplication
{
    [ExcludeFromCodeCoverage]
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
