using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Car_Rental_Application.Classes
{
    // Still a lot to do, this is just a prototype
    class Translator
    {
        readonly Dictionary<string, string> dictionaryEnglish;

        public Translator()
        {
            dictionaryEnglish = GetTranslationsFromCSVFile("TBD", '~');
        }
        
        Dictionary<string, string> GetTranslationsFromCSVFile(string CSVFilePath, char separator = ',')
        {
            Dictionary<string, string> translations = new Dictionary<string, string>();

            using (StreamReader reader = new StreamReader(CSVFilePath))
            {
                int lineCounter = 1;

                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    string[] values = line.Split(separator);

                    if (values.Length > 2)
                    {
                        MessageBox.Show(string.Format("Line {0} is odd, expected 2 values, got instead {1}, while using '{2}' as a separator", lineCounter, values.Length, separator));
                        return null;
                    }

                    string text = values[0];
                    string translatedText = values[1];

                    lineCounter++;

                    translations[text] = translatedText;
                }
            }

            return translations;
        }
    }
}
