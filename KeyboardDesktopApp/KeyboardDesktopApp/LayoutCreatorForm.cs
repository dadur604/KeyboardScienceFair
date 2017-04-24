using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Form1 {
    public partial class LayoutCreator : Form {
        public LayoutCreator() {
            InitializeComponent();
            foreach (var item in Program.languageDictionary) {
                comboBoxExistingLanguages.Items.Add(item.name);
            }
            pictureBoxLeft.BackColor = Color.AntiqueWhite;
            pictureBoxRight.BackColor = Color.AntiqueWhite;
        }

        private string picPathRight;

        private string picPathLeft;

        private void pictureBoxLeft_Click(object sender, EventArgs e) {
            openFileDialogPictureChoser.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.tif;";
            if (openFileDialogPictureChoser.ShowDialog() == DialogResult.OK) {
                picPathLeft = openFileDialogPictureChoser.FileName;
                pictureBoxLeft.Image = LanguageMaker.FixedSize(new Bitmap(picPathLeft), 72, 48);
            }
        }

        private void pictureBoxRight_Click(object sender, EventArgs e) {
            openFileDialogPictureChoser.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.tif;";
            if (openFileDialogPictureChoser.ShowDialog() == DialogResult.OK) {
                picPathRight = openFileDialogPictureChoser.FileName;
                pictureBoxRight.Image = LanguageMaker.FixedSize(new Bitmap(picPathRight), 72, 48);
            }
        }

        private void buttonCreateLayout_Click(object sender, EventArgs e) {
            if (picPathRight == null || picPathLeft == null) {
                toolStripStatusLabelLayoutCreator.Text = "Please chose an image for each key before continuing.";
            } else if (radioButtonExsisting.Checked) {
                if (comboBoxExistingLanguages.Text == "") {
                    toolStripStatusLabelLayoutCreator.Text = "Please chose an existing language from the list.";
                } else
                if (File.Exists(comboBoxExistingLanguages.Text + ".klayout")) {
                    if (MessageBox.Show(string.Format("Layout for {0} already exists. Do you want to overwrite?", comboBoxExistingLanguages.Text), "Layout already exists.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                        GenerateLayout(false);
                    }
                } else {
                    GenerateLayout(false);
                }
            } else if (radioButtonNew.Checked) {
                if (Program.languageDictionary.ContainsName(textBoxNewName.Text)) {
                    toolStripStatusLabelLayoutCreator.Text = "Language name already exists! Change name or chose existing language.";
                } else if (textBoxNewName.Text == "") {
                    toolStripStatusLabelLayoutCreator.Text = "Please enter a new name for the language.";
                } else if (Program.languageDictionary.ContainsSerialID((int)numericUpDownNewSerialID.Value)) {
                    toolStripStatusLabelLayoutCreator.Text = "Serial ID already in use! Please chose a new number.";
                } else {
                    toolStripStatusLabelLayoutCreator.Text = "Generating new layout...";
                    GenerateLayout(true);
                }
            }
        }

        private void GenerateLayout(bool isNew) {
            if (isNew) {
                Language language = new Language() {
                    name = textBoxNewName.Text,
                    serialID = (int)numericUpDownNewSerialID.Value,
                    windowsID = (int)numericUpDownNewWindowsLayoutID.Value,
                    isDefault = false
                };
                LanguageMaker.GenerateLayoutCode(textBoxNewName.Text, new List<string> { picPathLeft, picPathRight }, language);
            } else {
                LanguageMaker.GenerateLayoutCode(comboBoxExistingLanguages.Text, new List<string> { picPathLeft, picPathRight }, Program.languageDictionary.GetLanguageByName(comboBoxExistingLanguages.Text));
            }


            toolStripStatusLabelLayoutCreator.Text = "Layout file created successfully.";
            MessageBox.Show("Layout File Generated!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void radioButtonExsisting_CheckedChanged(object sender, EventArgs e) {
            if (radioButtonExsisting.Checked) {
                comboBoxExistingLanguages.Visible = true;
                labelExistingLanguageToUse.Visible = true;

                numericUpDownNewWindowsLayoutID.Visible = false;
                numericUpDownNewSerialID.Visible = false;
                textBoxNewName.Visible = false;
                labelNewSerialID.Visible = false;
                labelNewWindowsLayoutID.Visible = false;
                labelNewName.Visible = false;
            } else if (radioButtonNew.Checked) {
                comboBoxExistingLanguages.Visible = false;
                labelExistingLanguageToUse.Visible = false;

                numericUpDownNewWindowsLayoutID.Visible = true;
                numericUpDownNewSerialID.Visible = true;
                textBoxNewName.Visible = true;
                labelNewSerialID.Visible = true;
                labelNewWindowsLayoutID.Visible = true;
                labelNewName.Visible = true;
            }
        }

        private void radioButtonNew_CheckedChanged(object sender, EventArgs e) {
            radioButtonExsisting_CheckedChanged(null, null);
        }
    }
}