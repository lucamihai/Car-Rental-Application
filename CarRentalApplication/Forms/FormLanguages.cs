using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using CarRentalApplication.Translating;

namespace CarRentalApplication.Forms
{
    [ExcludeFromCodeCoverage]
    public partial class FormLanguages : Form
    {
        public Language ChosenLanguage { get; set; }

        private Dictionary<string, Language> availableLanguages = new Dictionary<string, Language>();

        public FormLanguages()
        {
            InitializeComponent();

            this.Text = Program.Language.Translate("Languages");
            labelChooseLanguage.Text = Program.Language.Translate("Choose language");
            buttonAddLanguage.Text = Program.Language.Translate("Add language");
            buttonApplyLanguage.Text = Program.Language.Translate("Apply selected");
            buttonRenameSelected.Text = Program.Language.Translate("Rename selected");
            buttonRemoveLanguage.Text = Program.Language.Translate("Remove selected");

            var english = Language.FromCsvContents(Properties.Resources.English, '\\');
            ChosenLanguage = english;

            CreateDefaultLanguageFile();
            SetAvailableLanguagesDictionary();
            SetLanguagesPanel();
        }

        private void CreateDefaultLanguageFile()
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

        private void SetLanguagesPanel()
        {
            panelLanguages.Controls.Clear();

            var counterLanguages = 0;

            foreach(var languageName in availableLanguages.Keys)
            {
                var radioButtonLanguage = new RadioButton();
                radioButtonLanguage.Text = languageName;
                radioButtonLanguage.Location = new Point(10, counterLanguages++ * 20);

                panelLanguages.Controls.Add(radioButtonLanguage);
            }
        }

        private void SetAvailableLanguagesDictionary()
        {
            if (Directory.Exists("Languages"))
            {
                availableLanguages = new Dictionary<string, Language>();
                var languageFiles = Directory.GetFiles("Languages");

                foreach (var languageFile in languageFiles)
                {
                    if (Path.GetExtension(languageFile) != ".csv")
                        continue;

                    var languageName = Path.GetFileNameWithoutExtension(languageFile);
                    var language = Language.FromCsvFile(languageFile, '\\');

                    availableLanguages[languageName] = language;
                }
            }
        }

        private void AddLanguage(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (!Directory.Exists("Languages"))
                {
                    Directory.CreateDirectory("Languages");
                }

                var languageFile = openFileDialog.FileName;
                if (File.Exists(@"Languages\" + Path.GetFileName(languageFile)))
                {
                    var message = $"{Path.GetFileNameWithoutExtension(languageFile)} language already added.";
                    MessageBox.Show(message);

                    return;
                }

                File.Copy(languageFile, @"Languages\" + Path.GetFileName(languageFile));
            }

            SetAvailableLanguagesDictionary();
            SetLanguagesPanel();
        }

        private void RemoveLanguage(object sender, EventArgs e)
        {
            var wasLanguageSelected = false;
            foreach (var languageRadioButton in panelLanguages.Controls.OfType<RadioButton>())
            {
                if (languageRadioButton.Checked)
                {
                    wasLanguageSelected = true;

                    var languageName = languageRadioButton.Text;
                    var action = $"remove the {languageName} language";
                    var formConfirmation = new FormConfirmation(action);

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
            var wasLanguageSelected = false;
            foreach (var languageRadioButton in panelLanguages.Controls.OfType<RadioButton>())
            {
                if (languageRadioButton.Checked)
                {
                    wasLanguageSelected = true;

                    var languageName = languageRadioButton.Text;
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
