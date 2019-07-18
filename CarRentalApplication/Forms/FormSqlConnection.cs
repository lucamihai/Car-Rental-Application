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

            labelDataSource.Text = Program.Language.Translate("Data source");
            labelUserID.Text = Program.Language.Translate("UserID");
            labelPassword.Text = Program.Language.Translate("Password");
            labelInitialCatalog.Text = Program.Language.Translate("Initial catalog");
        }

        private void Confirm(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxDataSource.Text))
            {
                errorLabel.Text = ErrorMessages.DataSourceNotProvided;
                return;
            }

            if (string.IsNullOrEmpty(textBoxUserID.Text))
            {
                errorLabel.Text = ErrorMessages.UserIdNotProvided;
                return;
            }

            if (string.IsNullOrEmpty(textBoxPassword.Text))
            {
                errorLabel.Text = ErrorMessages.PasswordNotProvided;
                return;
            }

            if (string.IsNullOrEmpty(textBoxInitialCatalog.Text))
            {
                errorLabel.Text = ErrorMessages.InitialCatalogNotProvided;
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

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void Cancel(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
