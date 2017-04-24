namespace Form1 {
    partial class EditLayoutForm {
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
            this.labelSerialID = new System.Windows.Forms.Label();
            this.labelWindowsID = new System.Windows.Forms.Label();
            this.numericWindowsLayoutID = new System.Windows.Forms.NumericUpDown();
            this.numericSerialID = new System.Windows.Forms.NumericUpDown();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.labelName = new System.Windows.Forms.Label();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOK = new System.Windows.Forms.Button();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelMessage = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.numericWindowsLayoutID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericSerialID)).BeginInit();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelSerialID
            // 
            this.labelSerialID.AutoSize = true;
            this.labelSerialID.Location = new System.Drawing.Point(37, 117);
            this.labelSerialID.Name = "labelSerialID";
            this.labelSerialID.Size = new System.Drawing.Size(47, 13);
            this.labelSerialID.TabIndex = 0;
            this.labelSerialID.Text = "Serial ID";
            // 
            // labelWindowsID
            // 
            this.labelWindowsID.AutoSize = true;
            this.labelWindowsID.Location = new System.Drawing.Point(37, 169);
            this.labelWindowsID.Name = "labelWindowsID";
            this.labelWindowsID.Size = new System.Drawing.Size(65, 13);
            this.labelWindowsID.TabIndex = 1;
            this.labelWindowsID.Text = "Windows ID";
            // 
            // numericWindowsLayoutID
            // 
            this.numericWindowsLayoutID.Location = new System.Drawing.Point(40, 185);
            this.numericWindowsLayoutID.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.numericWindowsLayoutID.Minimum = new decimal(new int[] {
            1000000000,
            0,
            0,
            -2147483648});
            this.numericWindowsLayoutID.Name = "numericWindowsLayoutID";
            this.numericWindowsLayoutID.Size = new System.Drawing.Size(120, 20);
            this.numericWindowsLayoutID.TabIndex = 17;
            // 
            // numericSerialID
            // 
            this.numericSerialID.Location = new System.Drawing.Point(40, 133);
            this.numericSerialID.Name = "numericSerialID";
            this.numericSerialID.Size = new System.Drawing.Size(44, 20);
            this.numericSerialID.TabIndex = 18;
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(40, 58);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(100, 20);
            this.textBoxName.TabIndex = 19;
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(37, 42);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(35, 13);
            this.labelName.TabIndex = 20;
            this.labelName.Text = "Name";
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(14, 243);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 21;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(110, 243);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 22;
            this.buttonOK.Text = "Save";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelMessage});
            this.statusStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.statusStrip.Location = new System.Drawing.Point(0, 285);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(199, 19);
            this.statusStrip.TabIndex = 23;
            // 
            // toolStripStatusLabelMessage
            // 
            this.toolStripStatusLabelMessage.Name = "toolStripStatusLabelMessage";
            this.toolStripStatusLabelMessage.Size = new System.Drawing.Size(0, 17);
            // 
            // EditLayoutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(199, 304);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.numericSerialID);
            this.Controls.Add(this.numericWindowsLayoutID);
            this.Controls.Add(this.labelWindowsID);
            this.Controls.Add(this.labelSerialID);
            this.Name = "EditLayoutForm";
            this.Text = "EditLayoutForm";
            ((System.ComponentModel.ISupportInitialize)(this.numericWindowsLayoutID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericSerialID)).EndInit();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelSerialID;
        private System.Windows.Forms.Label labelWindowsID;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOK;
        public System.Windows.Forms.NumericUpDown numericWindowsLayoutID;
        public System.Windows.Forms.NumericUpDown numericSerialID;
        public System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelMessage;
    }
}