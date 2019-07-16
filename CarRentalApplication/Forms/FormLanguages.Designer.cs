namespace CarRentalApplication.Forms
{
    partial class FormLanguages
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelLanguages = new System.Windows.Forms.Panel();
            this.labelChooseLanguage = new System.Windows.Forms.Label();
            this.buttonAddLanguage = new System.Windows.Forms.Button();
            this.buttonRemoveLanguage = new System.Windows.Forms.Button();
            this.buttonApplyLanguage = new System.Windows.Forms.Button();
            this.buttonRenameSelected = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // panelLanguages
            // 
            this.panelLanguages.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panelLanguages.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelLanguages.Location = new System.Drawing.Point(35, 54);
            this.panelLanguages.Name = "panelLanguages";
            this.panelLanguages.Size = new System.Drawing.Size(288, 241);
            this.panelLanguages.TabIndex = 0;
            // 
            // labelChooseLanguage
            // 
            this.labelChooseLanguage.AutoSize = true;
            this.labelChooseLanguage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelChooseLanguage.Location = new System.Drawing.Point(32, 35);
            this.labelChooseLanguage.Name = "labelChooseLanguage";
            this.labelChooseLanguage.Size = new System.Drawing.Size(181, 16);
            this.labelChooseLanguage.TabIndex = 1;
            this.labelChooseLanguage.Text = "Choose an existing language";
            // 
            // buttonAddLanguage
            // 
            this.buttonAddLanguage.Location = new System.Drawing.Point(344, 54);
            this.buttonAddLanguage.Name = "buttonAddLanguage";
            this.buttonAddLanguage.Size = new System.Drawing.Size(107, 23);
            this.buttonAddLanguage.TabIndex = 2;
            this.buttonAddLanguage.Text = "Add language";
            this.buttonAddLanguage.UseVisualStyleBackColor = true;
            this.buttonAddLanguage.Click += new System.EventHandler(this.AddLanguage);
            // 
            // buttonRemoveLanguage
            // 
            this.buttonRemoveLanguage.Location = new System.Drawing.Point(344, 195);
            this.buttonRemoveLanguage.Name = "buttonRemoveLanguage";
            this.buttonRemoveLanguage.Size = new System.Drawing.Size(107, 23);
            this.buttonRemoveLanguage.TabIndex = 3;
            this.buttonRemoveLanguage.Text = "Remove selected";
            this.buttonRemoveLanguage.UseVisualStyleBackColor = true;
            this.buttonRemoveLanguage.Click += new System.EventHandler(this.RemoveLanguage);
            // 
            // buttonChooseLanguage
            // 
            this.buttonApplyLanguage.Location = new System.Drawing.Point(344, 272);
            this.buttonApplyLanguage.Name = "buttonChooseLanguage";
            this.buttonApplyLanguage.Size = new System.Drawing.Size(107, 23);
            this.buttonApplyLanguage.TabIndex = 4;
            this.buttonApplyLanguage.Text = "Apply selected";
            this.buttonApplyLanguage.UseVisualStyleBackColor = true;
            this.buttonApplyLanguage.Click += new System.EventHandler(this.ChooseLanguage);
            // 
            // buttonRenameSelected
            // 
            this.buttonRenameSelected.Location = new System.Drawing.Point(344, 166);
            this.buttonRenameSelected.Name = "buttonRenameSelected";
            this.buttonRenameSelected.Size = new System.Drawing.Size(107, 23);
            this.buttonRenameSelected.TabIndex = 5;
            this.buttonRenameSelected.Text = "Rename selected";
            this.buttonRenameSelected.UseVisualStyleBackColor = true;
            this.buttonRenameSelected.Click += new System.EventHandler(this.RenameLanguage);
            // 
            // FormLanguages
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(484, 336);
            this.Controls.Add(this.buttonRenameSelected);
            this.Controls.Add(this.buttonApplyLanguage);
            this.Controls.Add(this.buttonRemoveLanguage);
            this.Controls.Add(this.buttonAddLanguage);
            this.Controls.Add(this.labelChooseLanguage);
            this.Controls.Add(this.panelLanguages);
            this.Name = "FormLanguages";
            this.Text = "Languages";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelLanguages;
        private System.Windows.Forms.Label labelChooseLanguage;
        private System.Windows.Forms.Button buttonAddLanguage;
        private System.Windows.Forms.Button buttonRemoveLanguage;
        private System.Windows.Forms.Button buttonApplyLanguage;
        private System.Windows.Forms.Button buttonRenameSelected;
    }
}