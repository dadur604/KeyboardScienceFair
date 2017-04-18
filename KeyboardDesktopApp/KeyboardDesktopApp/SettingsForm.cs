using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Form1 {

    public partial class SettingsForm : Form {

        public SettingsForm() {
            InitializeComponent();
            textBoxInstalLocation.Text = ConfigurationManager.AppSettings["arduinoOutputTemplateLocation"];
        }

        private void textBoxInstallLocation_Click(object sender, EventArgs e) {
            folderBrowserDialogInstallLocation.RootFolder = Environment.SpecialFolder.MyComputer;
            if (folderBrowserDialogInstallLocation.ShowDialog() == DialogResult.OK) {
                textBoxInstalLocation.Text = folderBrowserDialogInstallLocation.SelectedPath;
                LanguageMaker.UpdateArduinoTemplatePath(textBoxInstalLocation.Text);
            }
        }

        private void buttonBrowseInstallLocation_Click(object sender, EventArgs e) {
            textBoxInstallLocation_Click(null, null);
        }
    }
}