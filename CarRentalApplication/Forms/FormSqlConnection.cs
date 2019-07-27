using System;
using System.Data.SqlClient;
using System.Diagnostics.CodeAnalysis;
using System.Windows.Forms;
using CarRentalApplication.Classes;

namespace CarRentalApplication.Forms
{
    [ExcludeFromCodeCoverage]
    public partial class FormSqlConnection : Form
    {
        public string ConnectionString { get; private set; }

        public FormSqlConnection()
        {
            InitializeComponent();

            errorLabel.Text = string.Empty;

            radioButtonProvideFields.Checked = true;
            radioButtonProvideFields.Checked = false;
            radioButtonProvideConnectionString.Checked = true;

            radioButtonProvideFields.Text = Program.Language.Translate("Provide fields");
            radioButtonProvideConnectionString.Text = Program.Language.Translate("Provide connection string");

            labelDataSource.Text = Program.Language.Translate("Data source");
            labelUserID.Text = Program.Language.Translate("UserID");
            labelPassword.Text = Program.Language.Translate("Password");
            labelInitialCatalog.Text = Program.Language.Translate("Initial catalog");
            labelConnectionString.Text = Program.Language.Translate("Connection string");
        }

        private void Confirm(object sender, EventArgs e)
        {
            if (radioButtonProvideFields.Checked)
            {
                try
                {
                    ValidateFieldsInputs();
                }
                catch (ArgumentException exception)
                {
                    errorLabel.Text = exception.Message;
                    return;
                }
                

                var sqlConnectionStringBuilder = new SqlConnectionStringBuilder
                {
                    DataSource = textBoxDataSource.Text,
                    UserID = textBoxUserID.Text,
                    Password = textBoxPassword.Text,
                    InitialCatalog = textBoxInitialCatalog.Text
                };

                ConnectionString = sqlConnectionStringBuilder.ConnectionString;
            }

            if (radioButtonProvideConnectionString.Checked)
            {
                try
                {
                    ValidateConnectionFieldInput();
                }
                catch (ArgumentException exception)
                {
                    errorLabel.Text = exception.Message;
                    return;
                }

                ConnectionString = textBoxConnectionString.Text;
            }


            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void Cancel(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void ProvideFieldsChangedChecked(object sender, EventArgs e)
        {
            textBoxDataSource.Enabled = radioButtonProvideFields.Checked;
            textBoxUserID.Enabled = radioButtonProvideFields.Checked;
            textBoxPassword.Enabled = radioButtonProvideFields.Checked;
            textBoxInitialCatalog.Enabled = radioButtonProvideFields.Checked;
        }

        private void ProvideConnectionStringChangedChecked(object sender, EventArgs e)
        {
            textBoxConnectionString.Enabled = radioButtonProvideConnectionString.Checked;
        }

        private void ValidateFieldsInputs()
        {
            if (string.IsNullOrEmpty(textBoxDataSource.Text))
            {
                throw new ArgumentException(ErrorMessages.DataSourceNotProvided);
            }

            if (string.IsNullOrEmpty(textBoxUserID.Text))
            {
                throw new ArgumentException(ErrorMessages.UserIdNotProvided);
            }

            if (string.IsNullOrEmpty(textBoxPassword.Text))
            {
                throw new ArgumentException(ErrorMessages.PasswordNotProvided);
            }

            if (string.IsNullOrEmpty(textBoxInitialCatalog.Text))
            {
                throw new ArgumentException(ErrorMessages.InitialCatalogNotProvided);
            }
        }

        private void ValidateConnectionFieldInput()
        {
            if (string.IsNullOrEmpty(textBoxConnectionString.Text))
            {
                throw new ArgumentException(ErrorMessages.ConnectionStringNotProvided);
            }
        }
    }
}
