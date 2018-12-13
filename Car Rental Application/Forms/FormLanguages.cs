using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Car_Rental_Application.Classes;

namespace Car_Rental_Application.Forms
{
    public partial class FormLanguages : Form
    {
        public Language ChosenLanguage { get; set; }

        Dictionary<string, Language> availableLanguages = new Dictionary<string, Language>();

        public FormLanguages()
        {
            InitializeComponent();

            Dictionary<string, string> englishDictionary = GetTranslationsFromCSVContents(Properties.Resources.English, '\\');
            Language english = new Language(englishDictionary);
            ChosenLanguage = english;

            LoadDefaultLanguage();
            SetAvailableLanguagesDictionary();
            SetLanguagesPanel();
        }

        void LoadDefaultLanguage()
        {
            if (!Directory.Exists("Languages"))
            {
                Directory.CreateDirectory("Languages");
            }

            if (!File.Exists(@"Languages\English.csv"))
            {
                File.WriteAllText(@"Languages\English.csv", Properties.Resources.English);
            }
        }

        void SetLanguagesPanel()
        {
            panelLanguages.Controls.Clear();

            int counterLanguages = 0;

            foreach(string languageName in availableLanguages.Keys)
            {
                RadioButton radioButtonLanguage = new RadioButton();

                radioButtonLanguage.Text = languageName;
                radioButtonLanguage.Location = new Point(10, counterLanguages++ * 20);
                panelLanguages.Controls.Add(radioButtonLanguage);
            }
        }

        void SetAvailableLanguagesDictionary()
        {
            if (Directory.Exists("Languages"))
            {
                availableLanguages = new Dictionary<string, Language>();
                string[] languageFiles = Directory.GetFiles("Languages");

                foreach (string languageFile in languageFiles)
                {
                    if (Path.GetExtension(languageFile) == ".csv")
                    {
                        string languageName = Path.GetFileNameWithoutExtension(languageFile);
                        Dictionary<string, string> languageDictionary = GetTranslationsFromCSVFile(languageFile, '\\');
                        Language language = new Language(languageDictionary);

                        availableLanguages[languageName] = language;
                    }
                }
            }
        }

        Dictionary<string, string> GetTranslationsFromCSVFile(string CSVFilePath, char separator = ',', int beginFrom = 2)
        {
            Dictionary<string, string> translations = new Dictionary<string, string>();

            using (StreamReader reader = new StreamReader(CSVFilePath))
            {
                int lineCounter = 1;

                while (!reader.EndOfStream)
                {
                    if (lineCounter < beginFrom)
                    {
                        lineCounter++;
                        continue;
                    }

                    string line = reader.ReadLine();
                    string[] values = line.Split(separator);

                    if (values.Length > 2)
                    {
                        string error = string.Format(
                            "File '{0}': Line {1} is odd, expected 2 values, got instead {2}, while using '{3}' as a separator",
                            CSVFilePath, lineCounter, values.Length, separator
                        );

                        MessageBox.Show(error);
                        return null;
                    }

                    string text = values[0];
                    string translatedText = values[1];
                    translations[text] = translatedText;

                    lineCounter++;
                }
            }

            return translations;
        }

        public static Dictionary<string, string> GetTranslationsFromCSVContents(string CSVContents, char separator = ',', int beginFrom = 2)
        {
            Dictionary<string, string> translations = new Dictionary<string, string>();

            string[] lines = CSVContents.Split(
                new[] { Environment.NewLine },
                StringSplitOptions.None
            );

            int lineCounter = 1;

            foreach (string line in lines)
            {
                if (lineCounter < beginFrom)
                {
                    lineCounter++;
                    continue;
                }

                string[] values = line.Split(separator);

                if (values.Length > 2)
                {
                    string error = string.Format(
                        "Line {0} is odd, expected 2 values, got instead {1}, while using '{2}' as a separator",
                        lineCounter, values.Length, separator
                    );

                    MessageBox.Show(error);
                    return null;
                }

                string text = values[0];
                string translatedText = values[1];
                translations[text] = translatedText;

                lineCounter++;
            }

            return translations;
        }

        private void AddLanguage(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if ( !Directory.Exists("Languages"))
                {
                    Directory.CreateDirectory("Languages");
                }

                string languageFile = openFileDialog.FileName;
                if (File.Exists(@"Languages\" + Path.GetFileName(languageFile)))
                {
                    MessageBox.Show( string.Format( "{0} language already added.", Path.GetFileNameWithoutExtension(languageFile) ) );
                    return;
                }

                File.Copy(languageFile, @"Languages\" + Path.GetFileName(languageFile));
            }

            SetAvailableLanguagesDictionary();
            SetLanguagesPanel();
        }

        private void RemoveLanguage(object sender, EventArgs e)
        {
            bool wasLanguageSelected = false;
            foreach (RadioButton languageRadioButton in panelLanguages.Controls.OfType<RadioButton>())
            {
                if (languageRadioButton.Checked)
                {
                    wasLanguageSelected = true;

                    string languageName = languageRadioButton.Text;
                    string action = string.Format("remove the {0} language", languageName);
                    FormConfirmation formConfirmation = new FormConfirmation(action);

                    var result = formConfirmation.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        File.Delete(@"Languages\" + languageName + ".csv");
                    }
                }
            }

            if (!wasLanguageSelected)
            {
                MessageBox.Show("You haven't selected any language to remove");
                return;
            }

            SetAvailableLanguagesDictionary();
            SetLanguagesPanel();
        }

        private void ChooseLanguage(object sender, EventArgs e)
        {
            bool wasLanguageSelected = false;
            foreach (RadioButton languageRadioButton in panelLanguages.Controls.OfType<RadioButton>())
            {
                if (languageRadioButton.Checked)
                {
                    wasLanguageSelected = true;

                    string languageName = languageRadioButton.Text;
                    ChosenLanguage = availableLanguages[languageName];

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }

            if (!wasLanguageSelected)
            {
                MessageBox.Show("You haven't selected any language");
                return;
            }
        }

        private void RenameLanguage(object sender, EventArgs e)
        {
            // TO-DO
        }
    }
}
