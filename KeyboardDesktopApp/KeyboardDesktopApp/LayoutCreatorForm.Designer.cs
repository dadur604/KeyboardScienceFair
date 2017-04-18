namespace Form1
{
    partial class LayoutCreator
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
            this.openFileDialogPictureChoser = new System.Windows.Forms.OpenFileDialog();
            this.pictureBoxLeft = new System.Windows.Forms.PictureBox();
            this.pictureBoxRight = new System.Windows.Forms.PictureBox();
            this.buttonCreateLayout = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelLayoutCreator = new System.Windows.Forms.ToolStripStatusLabel();
            this.radioButtonExsisting = new System.Windows.Forms.RadioButton();
            this.radioButtonNew = new System.Windows.Forms.RadioButton();
            this.labelLayoutImages = new System.Windows.Forms.Label();
            this.comboBoxExistingLanguages = new System.Windows.Forms.ComboBox();
            this.labelExistingLanguageToUse = new System.Windows.Forms.Label();
            this.labelNewWindowsLayoutID = new System.Windows.Forms.Label();
            this.labelNewSerialID = new System.Windows.Forms.Label();
            this.numericUpDownNewSerialID = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownNewWindowsLayoutID = new System.Windows.Forms.NumericUpDown();
            this.labelNewName = new System.Windows.Forms.Label();
            this.textBoxNewName = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRight)).BeginInit();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNewSerialID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNewWindowsLayoutID)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxLeft
            // 
            this.pictureBoxLeft.Location = new System.Drawing.Point(39, 165);
            this.pictureBoxLeft.Name = "pictureBoxLeft";
            this.pictureBoxLeft.Size = new System.Drawing.Size(72, 48);
            this.pictureBoxLeft.TabIndex = 0;
            this.pictureBoxLeft.TabStop = false;
            this.pictureBoxLeft.Click += new System.EventHandler(this.pictureBoxLeft_Click);
            // 
            // pictureBoxRight
            // 
            this.pictureBoxRight.Location = new System.Drawing.Point(145, 165);
            this.pictureBoxRight.Name = "pictureBoxRight";
            this.pictureBoxRight.Size = new System.Drawing.Size(72, 48);
            this.pictureBoxRight.TabIndex = 1;
            this.pictureBoxRight.TabStop = false;
            this.pictureBoxRight.Click += new System.EventHandler(this.pictureBoxRight_Click);
            // 
            // buttonCreateLayout
            // 
            this.buttonCreateLayout.Location = new System.Drawing.Point(208, 219);
            this.buttonCreateLayout.Name = "buttonCreateLayout";
            this.buttonCreateLayout.Size = new System.Drawing.Size(104, 23);
            this.buttonCreateLayout.TabIndex = 2;
            this.buttonCreateLayout.Text = "Generate Layout!";
            this.buttonCreateLayout.UseVisualStyleBackColor = true;
            this.buttonCreateLayout.Click += new System.EventHandler(this.buttonCreateLayout_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelLayoutCreator});
            this.statusStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.statusStrip1.Location = new System.Drawing.Point(0, 284);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(342, 5);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabelLayoutCreator
            // 
            this.toolStripStatusLabelLayoutCreator.Name = "toolStripStatusLabelLayoutCreator";
            this.toolStripStatusLabelLayoutCreator.Size = new System.Drawing.Size(0, 17);
            // 
            // radioButtonExsisting
            // 
            this.radioButtonExsisting.AutoSize = true;
            this.radioButtonExsisting.Location = new System.Drawing.Point(28, 12);
            this.radioButtonExsisting.Name = "radioButtonExsisting";
            this.radioButtonExsisting.Size = new System.Drawing.Size(134, 17);
            this.radioButtonExsisting.TabIndex = 6;
            this.radioButtonExsisting.TabStop = true;
            this.radioButtonExsisting.Text = "Use Existing Language";
            this.radioButtonExsisting.UseVisualStyleBackColor = true;
            this.radioButtonExsisting.CheckedChanged += new System.EventHandler(this.radioButtonExsisting_CheckedChanged);
            // 
            // radioButtonNew
            // 
            this.radioButtonNew.AutoSize = true;
            this.radioButtonNew.Location = new System.Drawing.Point(168, 12);
            this.radioButtonNew.Name = "radioButtonNew";
            this.radioButtonNew.Size = new System.Drawing.Size(132, 17);
            this.radioButtonNew.TabIndex = 7;
            this.radioButtonNew.TabStop = true;
            this.radioButtonNew.Text = "Create New Language";
            this.radioButtonNew.UseVisualStyleBackColor = true;
            this.radioButtonNew.CheckedChanged += new System.EventHandler(this.radioButtonNew_CheckedChanged);
            // 
            // labelLayoutImages
            // 
            this.labelLayoutImages.AutoSize = true;
            this.labelLayoutImages.Location = new System.Drawing.Point(35, 138);
            this.labelLayoutImages.Name = "labelLayoutImages";
            this.labelLayoutImages.Size = new System.Drawing.Size(76, 13);
            this.labelLayoutImages.TabIndex = 8;
            this.labelLayoutImages.Text = "Layout Images";
            // 
            // comboBoxExistingLanguages
            // 
            this.comboBoxExistingLanguages.FormattingEnabled = true;
            this.comboBoxExistingLanguages.Location = new System.Drawing.Point(145, 48);
            this.comboBoxExistingLanguages.Name = "comboBoxExistingLanguages";
            this.comboBoxExistingLanguages.Size = new System.Drawing.Size(121, 21);
            this.comboBoxExistingLanguages.TabIndex = 9;
            this.comboBoxExistingLanguages.Visible = false;
            // 
            // labelExistingLanguageToUse
            // 
            this.labelExistingLanguageToUse.AutoSize = true;
            this.labelExistingLanguageToUse.Location = new System.Drawing.Point(39, 48);
            this.labelExistingLanguageToUse.Name = "labelExistingLanguageToUse";
            this.labelExistingLanguageToUse.Size = new System.Drawing.Size(93, 13);
            this.labelExistingLanguageToUse.TabIndex = 10;
            this.labelExistingLanguageToUse.Text = "Language To Use";
            this.labelExistingLanguageToUse.Visible = false;
            // 
            // labelNewWindowsLayoutID
            // 
            this.labelNewWindowsLayoutID.AutoSize = true;
            this.labelNewWindowsLayoutID.Location = new System.Drawing.Point(39, 72);
            this.labelNewWindowsLayoutID.Name = "labelNewWindowsLayoutID";
            this.labelNewWindowsLayoutID.Size = new System.Drawing.Size(100, 13);
            this.labelNewWindowsLayoutID.TabIndex = 11;
            this.labelNewWindowsLayoutID.Text = "Windows Layout ID";
            this.labelNewWindowsLayoutID.Visible = false;
            // 
            // labelNewSerialID
            // 
            this.labelNewSerialID.AutoSize = true;
            this.labelNewSerialID.Location = new System.Drawing.Point(205, 72);
            this.labelNewSerialID.Name = "labelNewSerialID";
            this.labelNewSerialID.Size = new System.Drawing.Size(47, 13);
            this.labelNewSerialID.TabIndex = 13;
            this.labelNewSerialID.Text = "Serial ID";
            this.labelNewSerialID.Visible = false;
            // 
            // numericUpDownNewSerialID
            // 
            this.numericUpDownNewSerialID.Location = new System.Drawing.Point(208, 88);
            this.numericUpDownNewSerialID.Name = "numericUpDownNewSerialID";
            this.numericUpDownNewSerialID.Size = new System.Drawing.Size(44, 20);
            this.numericUpDownNewSerialID.TabIndex = 15;
            this.numericUpDownNewSerialID.Visible = false;
            // 
            // numericUpDownNewWindowsLayoutID
            // 
            this.numericUpDownNewWindowsLayoutID.Location = new System.Drawing.Point(39, 88);
            this.numericUpDownNewWindowsLayoutID.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.numericUpDownNewWindowsLayoutID.Minimum = new decimal(new int[] {
            1000000000,
            0,
            0,
            -2147483648});
            this.numericUpDownNewWindowsLayoutID.Name = "numericUpDownNewWindowsLayoutID";
            this.numericUpDownNewWindowsLayoutID.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownNewWindowsLayoutID.TabIndex = 16;
            this.numericUpDownNewWindowsLayoutID.Visible = false;
            // 
            // labelNewName
            // 
            this.labelNewName.AutoSize = true;
            this.labelNewName.Location = new System.Drawing.Point(42, 48);
            this.labelNewName.Name = "labelNewName";
            this.labelNewName.Size = new System.Drawing.Size(35, 13);
            this.labelNewName.TabIndex = 17;
            this.labelNewName.Text = "Name";
            this.labelNewName.Visible = false;
            // 
            // textBoxNewName
            // 
            this.textBoxNewName.Location = new System.Drawing.Point(95, 45);
            this.textBoxNewName.Name = "textBoxNewName";
            this.textBoxNewName.Size = new System.Drawing.Size(100, 20);
            this.textBoxNewName.TabIndex = 18;
            this.textBoxNewName.Visible = false;
            // 
            // LayoutCreator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(342, 289);
            this.Controls.Add(this.textBoxNewName);
            this.Controls.Add(this.labelNewName);
            this.Controls.Add(this.numericUpDownNewWindowsLayoutID);
            this.Controls.Add(this.numericUpDownNewSerialID);
            this.Controls.Add(this.labelNewSerialID);
            this.Controls.Add(this.labelNewWindowsLayoutID);
            this.Controls.Add(this.labelExistingLanguageToUse);
            this.Controls.Add(this.comboBoxExistingLanguages);
            this.Controls.Add(this.labelLayoutImages);
            this.Controls.Add(this.radioButtonNew);
            this.Controls.Add(this.radioButtonExsisting);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.buttonCreateLayout);
            this.Controls.Add(this.pictureBoxRight);
            this.Controls.Add(this.pictureBoxLeft);
            this.Name = "LayoutCreator";
            this.Text = "LayoutCreator";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRight)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNewSerialID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNewWindowsLayoutID)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialogPictureChoser;
        private System.Windows.Forms.PictureBox pictureBoxLeft;
        private System.Windows.Forms.PictureBox pictureBoxRight;
        private System.Windows.Forms.Button buttonCreateLayout;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelLayoutCreator;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.RadioButton radioButtonExsisting;
        private System.Windows.Forms.RadioButton radioButtonNew;
        private System.Windows.Forms.Label labelLayoutImages;
        private System.Windows.Forms.ComboBox comboBoxExistingLanguages;
        private System.Windows.Forms.Label labelExistingLanguageToUse;
        private System.Windows.Forms.Label labelNewWindowsLayoutID;
        private System.Windows.Forms.Label labelNewSerialID;
        private System.Windows.Forms.NumericUpDown numericUpDownNewSerialID;
        private System.Windows.Forms.NumericUpDown numericUpDownNewWindowsLayoutID;
        private System.Windows.Forms.Label labelNewName;
        private System.Windows.Forms.TextBox textBoxNewName;
    }
}