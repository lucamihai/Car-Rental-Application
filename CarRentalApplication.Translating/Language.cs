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
            ValidateCsvContents(csvContents);

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

                if (values.Length != 2)
                {
                    var message = $"Line {lineCounter} is odd, expected 2 values, got instead {values.Length}, while using '{separator}' as a separator";
                    throw new InvalidOperationException(message);
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
            ValidateCsvFilePath(csvFilePath);

            var csvContents = string.Empty;

            using (var streamReader = new StreamReader(csvFilePath))
            {
                while (!streamReader.EndOfStream)
                {
                    var line = streamReader.ReadLine();
                    csvContents += $"{line}{Environment.NewLine}";
                }
            }

            csvContents = csvContents.Remove(csvContents.LastIndexOf(Environment.NewLine));

            return Language.FromCsvContents(csvContents, separator);
        }

        private static void ValidateCsvContents(string csvContents)
        {
            if (string.IsNullOrEmpty(csvContents))
            {
                throw new ArgumentException();
            }
        }

        private static void ValidateCsvFilePath(string csvFilePath)
        {
            if (string.IsNullOrEmpty(csvFilePath))
            {
                throw new ArgumentException("CSV file path must be provided");
            }

            if (!File.Exists(csvFilePath))
            {
                throw new ArgumentException($"{csvFilePath} does not exist");
            }
        }
    }
}
