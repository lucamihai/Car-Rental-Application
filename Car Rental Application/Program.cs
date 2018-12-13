using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Car_Rental_Application.Classes;
using Car_Rental_Application.Forms;

namespace Car_Rental_Application
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Default language
            Dictionary<string, string> englishDictionary = FormLanguages.GetTranslationsFromCSVContents(Properties.Resources.English, '\\');
            Language = new Language(englishDictionary);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainWindow());
        }

        public static Language Language { get; set; }
    }
}
