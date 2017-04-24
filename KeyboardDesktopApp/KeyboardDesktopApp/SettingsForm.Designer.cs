namespace Form1 {
    partial class SettingsForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.labelArduinoPath = new System.Windows.Forms.Label();
            this.folderBrowserDialogInstallLocation = new System.Windows.Forms.FolderBrowserDialog();
            this.textBoxInstalLocation = new System.Windows.Forms.TextBox();
            this.buttonBrowseInstallLocation = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelArduinoPath
            // 
            this.labelArduinoPath.AutoSize = true;
            this.labelArduinoPath.Location = new System.Drawing.Point(12, 50);
            this.labelArduinoPath.Name = "labelArduinoPath";
            this.labelArduinoPath.Size = new System.Drawing.Size(78, 13);
            this.labelArduinoPath.TabIndex = 0;
            this.labelArduinoPath.Text = "Install Location";
            // 
            // folderBrowserDialogInstallLocation
            // 
            this.folderBrowserDialogInstallLocation.ShowNewFolderButton = false;
            // 
            // textBoxInstalLocation
            // 
            this.textBoxInstalLocation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxInstalLocation.Location = new System.Drawing.Point(96, 47);
            this.textBoxInstalLocation.Name = "textBoxInstalLocation";
            this.textBoxInstalLocation.Size = new System.Drawing.Size(295, 20);
            this.textBoxInstalLocation.TabIndex = 1;
            this.textBoxInstalLocation.Click += new System.EventHandler(this.textBoxInstallLocation_Click);
            // 
            // buttonBrowseInstallLocation
            // 
            this.buttonBrowseInstallLocation.Location = new System.Drawing.Point(395, 46);
            this.buttonBrowseInstallLocation.Name = "buttonBrowseInstallLocation";
            this.buttonBrowseInstallLocation.Size = new System.Drawing.Size(75, 21);
            this.buttonBrowseInstallLocation.TabIndex = 2;
            this.buttonBrowseInstallLocation.Text = "Browse...";
            this.buttonBrowseInstallLocation.UseVisualStyleBackColor = true;
            this.buttonBrowseInstallLocation.Click += new System.EventHandler(this.buttonBrowseInstallLocation_Click);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 117);
            this.Controls.Add(this.buttonBrowseInstallLocation);
            this.Controls.Add(this.textBoxInstalLocation);
            this.Controls.Add(this.labelArduinoPath);
            this.Name = "SettingsForm";
            this.Text = "SettingsForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelArduinoPath;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialogInstallLocation;
        private System.Windows.Forms.TextBox textBoxInstalLocation;
        private System.Windows.Forms.Button buttonBrowseInstallLocation;
    }
}