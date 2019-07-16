using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace CarRentalApplication.Translating.UnitTests
{
    [ExcludeFromCodeCoverage]
    internal static class Constants
    {
        public const string LanguageName1 = "LanguageName1";

        public static Dictionary<string, string> LanguageTranslations1 = new Dictionary<string, string>
        {
            { Text1, TranslatedText1 },
            { Text2, TranslatedText2 }
        };

        public const string Text1 = "Text1";
        public const string Text2 = "Text2";
        public const string Text3 = "Text3";

        public const string TranslatedText1 = "TranslatedText1";
        public const string TranslatedText2 = "TranslatedText2";
        public const string TranslatedText3 = "TranslatedText3";

        public const string CsvContents1 = 
@"language name\LanguageName1
text\translated text
Text1\TranslatedText1
Text2\TranslatedText2";
        public const char Separator1 = '\\';

        public const string CsvContentsWithInvalidLine =
@"language name\LanguageName1
text\translated text
Text1\TranslatedText1\ExtraStuff
Text2\TranslatedText2";
    }
}
