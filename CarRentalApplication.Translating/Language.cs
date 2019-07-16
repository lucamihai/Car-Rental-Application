using System;
using System.Collections.Generic;
using System.IO;

namespace CarRentalApplication.Translating
{
    public class Language
    {
        private readonly Dictionary<string, string> translations;

        public string Name { get; private set; }

        public Language(string languageName, Dictionary<string, string> translations)
        {
            Name = languageName;
            this.translations = translations;
        }

        public string Translate(string text)
        {
            if (translations.ContainsKey(text) && translations[text] != null)
            {
                return translations[text];
            }

            return text;
        }

        public static Language FromCsvContents(string csvContents, char separator)
        {
            var languageName = "Undefined";
            var translations = new Dictionary<string, string>();

            var lines = csvContents.Split(
                new[] {Environment.NewLine},
                StringSplitOptions.None
            );

            var lineCounter = 1;

            foreach (var line in lines)
            {
                if (lineCounter == 1)
                {
                    languageName = line.Split(separator)[1];
                }

                if (lineCounter < 3)
                {
                    lineCounter++;
                    continue;
                }

                var values = line.Split(separator);

                if (values.Length > 2)
                {
                    var error =
                        $"Line {lineCounter} is odd, expected 2 values, got instead {values.Length}, while using '{separator}' as a separator";

                    return null;
                }

                var text = values[0];
                var translatedText = values[1];
                translations[text] = translatedText;

                lineCounter++;
            }

            var language = new Language(languageName, translations);

            return language;
        }

        public static Language FromCsvFile(string csvFilePath, char separator)
        {
            var csvContents = string.Empty;

            using (var streamReader = new StreamReader(csvFilePath))
            {
                while (!streamReader.EndOfStream)
                {
                    var line = streamReader.ReadLine();
                    csvContents += line;
                }
            }

            return Language.FromCsvContents(csvContents, separator);
        }
    }
}
