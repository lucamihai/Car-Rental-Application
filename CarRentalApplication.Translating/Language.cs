using System.Collections.Generic;

namespace CarRentalApplication.Translating
{
    public class Language
    {
        private Dictionary<string, string> dictionary;

        public Language(Dictionary<string, string> dictionary)
        {
            this.dictionary = dictionary;
        }

        public string Translate(string text)
        {
            if (dictionary.ContainsKey(text) && dictionary[text] != null)
            {
                return dictionary[text];
            }

            return text;
        }
    }
}
