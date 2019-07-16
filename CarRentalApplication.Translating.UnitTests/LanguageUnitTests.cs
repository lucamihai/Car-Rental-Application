using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CarRentalApplication.Translating.UnitTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class LanguageUnitTests
    {
        private Language language;

        [TestMethod]
        public void TranslateReturnsExpectedTranslationForTextIfThereIsATranslationForIt1()
        {
            language = new Language(Constants.LanguageName1, Constants.LanguageTranslations1);

            var translatedText = language.Translate(Constants.Text1);

            Assert.AreEqual(Constants.TranslatedText1, translatedText);
        }

        [TestMethod]
        public void TranslateReturnsExpectedTranslationForTextIfThereIsATranslationForIt2()
        {
            language = new Language(Constants.LanguageName1, Constants.LanguageTranslations1);

            var translatedText = language.Translate(Constants.Text2);

            Assert.AreEqual(Constants.TranslatedText2, translatedText);
        }

        [TestMethod]
        public void TranslateReturnsSameTextIfThereIsNotATranslationForIt()
        {
            language = new Language(Constants.LanguageName1, Constants.LanguageTranslations1);

            var translatedText = language.Translate(Constants.Text3);

            Assert.AreEqual(Constants.Text3, translatedText);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void FromCsvContentsThrowsArgumentExceptionForNullCsvContents()
        {
            language = Language.FromCsvContents(null, Constants.Separator1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void FromCsvContentsThrowsArgumentExceptionForEmptyCsvContents()
        {
            language = Language.FromCsvContents(string.Empty, Constants.Separator1);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void FromCsvContentsThrowsInvalidOperationForCsvContentsWithAnyLineThatContainsAnInvalidNumberOfValues()
        {
            language = Language.FromCsvContents(Constants.CsvContentsWithInvalidLine, Constants.Separator1);
        }

        [TestMethod]
        public void FromCsvContentsReturnsLanguageWithExpectedName()
        {
            language = Language.FromCsvContents(Constants.CsvContents1, Constants.Separator1);

            Assert.AreEqual(Constants.LanguageName1, language.Name);
        }

        [TestMethod]
        public void FromCsvContentsReturnsLanguageWithExpectedTranslateResults()
        {
            language = Language.FromCsvContents(Constants.CsvContents1, Constants.Separator1);

            Assert.AreEqual(Constants.TranslatedText1, language.Translate(Constants.Text1));
            Assert.AreEqual(Constants.TranslatedText2, language.Translate(Constants.Text2));
            Assert.AreEqual(Constants.Text3, language.Translate(Constants.Text3));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void FromCsvFileThrowsArgumentExceptionForNullCsvFilePath()
        {
            language = Language.FromCsvFile(null, Constants.Separator1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void FromCsvFileThrowsArgumentExceptionForEmptyCsvFilePath()
        {
            language = Language.FromCsvFile(string.Empty, Constants.Separator1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void FromCsvFileThrowsArgumentExceptionForUnexistingCsvFilePath()
        {
            language = Language.FromCsvFile("123456", Constants.Separator1);
        }

        [TestMethod]
        public void FromCsvFileReturnsLanguageResultedFromMethodFromCsvContents()
        {
            var path = $"{Environment.CurrentDirectory}\\test.csv";
            File.AppendAllText(path, Constants.CsvContents1);

            language = Language.FromCsvFile(path, Constants.Separator1);

            Assert.AreEqual(Constants.TranslatedText1, language.Translate(Constants.Text1));
            Assert.AreEqual(Constants.TranslatedText2, language.Translate(Constants.Text2));
            Assert.AreEqual(Constants.Text3, language.Translate(Constants.Text3));

            File.Delete(path);
        }
    }
}
