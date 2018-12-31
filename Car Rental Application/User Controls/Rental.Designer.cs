namespace Car_Rental_Application.User_Controls
{
    partial class Rental
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelOwnerName = new System.Windows.Forms.Label();
            this.labelOwnerNameValue = new System.Windows.Forms.Label();
            this.labelOwnerPhone = new System.Windows.Forms.Label();
            this.labelOwnerPhoneValue = new System.Windows.Forms.Label();
            this.labelReturnDateValue = new System.Windows.Forms.Label();
            this.labelReturnDate = new System.Windows.Forms.Label();
            this.labelVehicle = new System.Windows.Forms.Label();
            this.checkboxSelect = new System.Windows.Forms.CheckBox();
            this.buttonReturn = new System.Windows.Forms.Button();
            this.labelID = new System.Windows.Forms.Label();
            this.labelIDValue = new System.Windows.Forms.Label();
            this.panelVehicle = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // labelOwnerName
            // 
            this.labelOwnerName.AutoSize = true;
            this.labelOwnerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelOwnerName.Location = new System.Drawing.Point(13, 11);
            this.labelOwnerName.Name = "labelOwnerName";
            this.labelOwnerName.Size = new System.Drawing.Size(77, 13);
            this.labelOwnerName.TabIndex = 1;
            this.labelOwnerName.Text = "Owner name";
            // 
            // labelOwnerNameValue
            // 
            this.labelOwnerNameValue.AutoSize = true;
            this.labelOwnerNameValue.Location = new System.Drawing.Point(13, 24);
            this.labelOwnerNameValue.Name = "labelOwnerNameValue";
            this.labelOwnerNameValue.Size = new System.Drawing.Size(59, 13);
            this.labelOwnerNameValue.TabIndex = 2;
            this.labelOwnerNameValue.Text = "John Smith";
            // 
            // labelOwnerPhone
            // 
            this.labelOwnerPhone.AutoSize = true;
            this.labelOwnerPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelOwnerPhone.Location = new System.Drawing.Point(13, 46);
            this.labelOwnerPhone.Name = "labelOwnerPhone";
            this.labelOwnerPhone.Size = new System.Drawing.Size(82, 13);
            this.labelOwnerPhone.TabIndex = 3;
            this.labelOwnerPhone.Text = "Owner phone";
            // 
            // labelOwnerPhoneValue
            // 
            this.labelOwnerPhoneValue.AutoSize = true;
            this.labelOwnerPhoneValue.Location = new System.Drawing.Point(13, 59);
            this.labelOwnerPhoneValue.Name = "labelOwnerPhoneValue";
            this.labelOwnerPhoneValue.Size = new System.Drawing.Size(67, 13);
            this.labelOwnerPhoneValue.TabIndex = 4;
            this.labelOwnerPhoneValue.Text = "0123456789";
            // 
            // labelReturnDateValue
            // 
            this.labelReturnDateValue.AutoSize = true;
            this.labelReturnDateValue.Location = new System.Drawing.Point(13, 95);
            this.labelReturnDateValue.Name = "labelReturnDateValue";
            this.labelReturnDateValue.Size = new System.Drawing.Size(65, 13);
            this.labelReturnDateValue.TabIndex = 6;
            this.labelReturnDateValue.Text = "31/12/2018";
            // 
            // labelReturnDate
            // 
            this.labelReturnDate.AutoSize = true;
            this.labelReturnDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelReturnDate.Location = new System.Drawing.Point(13, 82);
            this.labelReturnDate.Name = "labelReturnDate";
            this.labelReturnDate.Size = new System.Drawing.Size(74, 13);
            this.labelReturnDate.TabIndex = 5;
            this.labelReturnDate.Text = "Return date";
            // 
            // labelVehicle
            // 
            this.labelVehicle.AutoSize = true;
            this.labelVehicle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelVehicle.Location = new System.Drawing.Point(398, 8);
            this.labelVehicle.Name = "labelVehicle";
            this.labelVehicle.Size = new System.Drawing.Size(49, 13);
            this.labelVehicle.TabIndex = 7;
            this.labelVehicle.Text = "Vehicle";
            // 
            // checkboxSelect
            // 
            this.checkboxSelect.AutoSize = true;
            this.checkboxSelect.Location = new System.Drawing.Point(215, 105);
            this.checkboxSelect.Name = "checkboxSelect";
            this.checkboxSelect.Size = new System.Drawing.Size(56, 17);
            this.checkboxSelect.TabIndex = 8;
            this.checkboxSelect.Text = "Select";
            this.checkboxSelect.UseVisualStyleBackColor = true;
            // 
            // buttonReturn
            // 
            this.buttonReturn.Location = new System.Drawing.Point(528, 101);
            this.buttonReturn.Name = "buttonReturn";
            this.buttonReturn.Size = new System.Drawing.Size(75, 23);
            this.buttonReturn.TabIndex = 9;
            this.buttonReturn.Text = "Return";
            this.buttonReturn.UseVisualStyleBackColor = true;
            // 
            // labelID
            // 
            this.labelID.AutoSize = true;
            this.labelID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelID.Location = new System.Drawing.Point(147, 5);
            this.labelID.Name = "labelID";
            this.labelID.Size = new System.Drawing.Size(20, 13);
            this.labelID.TabIndex = 10;
            this.labelID.Text = "ID";
            // 
            // labelIDValue
            // 
            this.labelIDValue.AutoSize = true;
            this.labelIDValue.Location = new System.Drawing.Point(173, 5);
            this.labelIDValue.Name = "labelIDValue";
            this.labelIDValue.Size = new System.Drawing.Size(13, 13);
            this.labelIDValue.TabIndex = 11;
            this.labelIDValue.Text = "1";
            // 
            // panelVehicle
            // 
            this.panelVehicle.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.panelVehicle.Location = new System.Drawing.Point(147, 24);
            this.panelVehicle.Name = "panelVehicle";
            this.panelVehicle.Size = new System.Drawing.Size(550, 75);
            this.panelVehicle.TabIndex = 12;
            // 
            // Rental
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Controls.Add(this.panelVehicle);
            this.Controls.Add(this.labelIDValue);
            this.Controls.Add(this.labelID);
            this.Controls.Add(this.buttonReturn);
            this.Controls.Add(this.checkboxSelect);
            this.Controls.Add(this.labelVehicle);
            this.Controls.Add(this.labelReturnDateValue);
            this.Controls.Add(this.labelReturnDate);
            this.Controls.Add(this.labelOwnerPhoneValue);
            this.Controls.Add(this.labelOwnerPhone);
            this.Controls.Add(this.labelOwnerNameValue);
            this.Controls.Add(this.labelOwnerName);
            this.Name = "Rental";
            this.Size = new System.Drawing.Size(700, 125);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelOwnerName;
        private System.Windows.Forms.Label labelOwnerNameValue;
        private System.Windows.Forms.Label labelOwnerPhone;
        private System.Windows.Forms.Label labelOwnerPhoneValue;
        private System.Windows.Forms.Label labelReturnDateValue;
        private System.Windows.Forms.Label labelReturnDate;
        private System.Windows.Forms.Label labelVehicle;
        private System.Windows.Forms.CheckBox checkboxSelect;
        private System.Windows.Forms.Button buttonReturn;
        private System.Windows.Forms.Label labelID;
        private System.Windows.Forms.Label labelIDValue;
        private System.Windows.Forms.Panel panelVehicle;
    }
}
