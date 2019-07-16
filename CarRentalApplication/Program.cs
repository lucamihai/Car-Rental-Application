using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CarRentalApplication.Forms;
using CarRentalApplication.Translating;

namespace CarRentalApplication
{
    internal static class Program
    {
        private static Dictionary<string, string> englishDictionary = FormLanguages.GetTranslationsFromCSVContents(Properties.Resources.English, '\\');
        public static Language Language { get; set; } = new Language(englishDictionary);

        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainWindow());
        }
    }
}
