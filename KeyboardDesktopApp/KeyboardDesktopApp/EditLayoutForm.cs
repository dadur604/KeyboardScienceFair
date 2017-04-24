using System.Windows.Forms;


namespace Form1 {
    public partial class EditLayoutForm : Form {

        Language lang;
        public EditLayoutForm(Language _lang) {
            InitializeComponent();
            lang = _lang;
            textBoxName.Text = lang.name;
            numericSerialID.Value = lang.serialID;
            numericWindowsLayoutID.Value = lang.windowsID;

            buttonCancel.DialogResult = DialogResult.Cancel;
        }

        private void buttonOK_Click(object sender, System.EventArgs e) {
            // validate
            
            if (lang.name != textBoxName.Text && Program.languageDictionary.ContainsName(textBoxName.Text)) {
                toolStripStatusLabelMessage.Text = "That name is already in use!";
                DialogResult = DialogResult.None;
            } else if (lang.serialID != numericSerialID.Value && Program.languageDictionary.ContainsSerialID((int)numericSerialID.Value)) {
                toolStripStatusLabelMessage.Text = "That SerialID is already in use!";
                DialogResult = DialogResult.None;
            } else {
                this.DialogResult = DialogResult.OK;
                toolStripStatusLabelMessage.Text = "Success!";
            }

        }
    }
}
