using System;
using System.Drawing;
using System.Windows.Forms;


namespace Form1 {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemRestart = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tabPage_debug = new System.Windows.Forms.TabPage();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.tabPage_main = new System.Windows.Forms.TabPage();
            this.buttonStart = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage_layout = new System.Windows.Forms.TabPage();
            this.checkedListBox_layoutsList = new System.Windows.Forms.CheckedListBox();
            this.label_layoutsSelected = new System.Windows.Forms.Label();
            this.label_layoutNotFound = new System.Windows.Forms.Label();
            this.button_downloadMore = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.tabPage_debug.SuspendLayout();
            this.tabPage_main.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage_layout.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolStripMenuItemAbout});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(505, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemRestart,
            this.toolStripMenuItemExit});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // toolStripMenuItemRestart
            // 
            this.toolStripMenuItemRestart.Name = "toolStripMenuItemRestart";
            this.toolStripMenuItemRestart.Size = new System.Drawing.Size(110, 22);
            this.toolStripMenuItemRestart.Text = "Restart";
            // 
            // toolStripMenuItemExit
            // 
            this.toolStripMenuItemExit.Name = "toolStripMenuItemExit";
            this.toolStripMenuItemExit.Size = new System.Drawing.Size(110, 22);
            this.toolStripMenuItemExit.Text = "Exit";
            // 
            // toolStripMenuItemAbout
            // 
            this.toolStripMenuItemAbout.Name = "toolStripMenuItemAbout";
            this.toolStripMenuItemAbout.Size = new System.Drawing.Size(52, 20);
            this.toolStripMenuItemAbout.Text = "About";
            this.toolStripMenuItemAbout.Click += new System.EventHandler(this.toolStripMenuItemAbout_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 305);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(505, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Click += new System.EventHandler(this.toolStripStatusLabel1_Click);
            // 
            // tabPage_debug
            // 
            this.tabPage_debug.Controls.Add(this.richTextBox1);
            this.tabPage_debug.Location = new System.Drawing.Point(4, 22);
            this.tabPage_debug.Name = "tabPage_debug";
            this.tabPage_debug.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_debug.Size = new System.Drawing.Size(473, 249);
            this.tabPage_debug.TabIndex = 1;
            this.tabPage_debug.Text = "Debug";
            this.tabPage_debug.UseVisualStyleBackColor = true;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(3, 3);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(467, 246);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // tabPage_main
            // 
            this.tabPage_main.Controls.Add(this.buttonStart);
            this.tabPage_main.Location = new System.Drawing.Point(4, 22);
            this.tabPage_main.Name = "tabPage_main";
            this.tabPage_main.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_main.Size = new System.Drawing.Size(473, 249);
            this.tabPage_main.TabIndex = 0;
            this.tabPage_main.Text = "Main";
            this.tabPage_main.UseVisualStyleBackColor = true;
            // 
            // buttonStart
            // 
            this.buttonStart.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonStart.Location = new System.Drawing.Point(194, 111);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(75, 23);
            this.buttonStart.TabIndex = 0;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage_main);
            this.tabControl1.Controls.Add(this.tabPage_layout);
            this.tabControl1.Controls.Add(this.tabPage_debug);
            this.tabControl1.Location = new System.Drawing.Point(12, 27);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(481, 275);
            this.tabControl1.TabIndex = 4;
            // 
            // tabPage_layout
            // 
            this.tabPage_layout.Controls.Add(this.button_downloadMore);
            this.tabPage_layout.Controls.Add(this.label_layoutNotFound);
            this.tabPage_layout.Controls.Add(this.label_layoutsSelected);
            this.tabPage_layout.Controls.Add(this.checkedListBox_layoutsList);
            this.tabPage_layout.Location = new System.Drawing.Point(4, 22);
            this.tabPage_layout.Name = "tabPage_layout";
            this.tabPage_layout.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_layout.Size = new System.Drawing.Size(473, 249);
            this.tabPage_layout.TabIndex = 2;
            this.tabPage_layout.Text = "Layouts";
            this.tabPage_layout.UseVisualStyleBackColor = true;
            // 
            // checkedListBox_layoutsList
            // 
            this.checkedListBox_layoutsList.CheckOnClick = true;
            this.checkedListBox_layoutsList.FormattingEnabled = true;
            this.checkedListBox_layoutsList.Items.Add("English", CheckState.Indeterminate);
            this.checkedListBox_layoutsList.Items.Add("Armenian");
            this.checkedListBox_layoutsList.Location = new System.Drawing.Point(17, 36);
            this.checkedListBox_layoutsList.Name = "checkedListBox_layoutsList";
            this.checkedListBox_layoutsList.Size = new System.Drawing.Size(126, 199);
            this.checkedListBox_layoutsList.TabIndex = 0;
            this.checkedListBox_layoutsList.SelectedIndexChanged += new System.EventHandler(this.checkedListBox_layoutsList_SelectedIndexChanged);
            // 
            // label_layoutsSelected
            // 
            this.label_layoutsSelected.AutoSize = true;
            this.label_layoutsSelected.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_layoutsSelected.Location = new System.Drawing.Point(15, 14);
            this.label_layoutsSelected.Name = "label_layoutsSelected";
            this.label_layoutsSelected.Size = new System.Drawing.Size(105, 13);
            this.label_layoutsSelected.TabIndex = 1;
            this.label_layoutsSelected.Text = "Layouts Selected";
            // 
            // label_layoutNotFound
            // 
            this.label_layoutNotFound.AutoSize = true;
            this.label_layoutNotFound.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_layoutNotFound.Location = new System.Drawing.Point(226, 92);
            this.label_layoutNotFound.Name = "label_layoutNotFound";
            this.label_layoutNotFound.Size = new System.Drawing.Size(192, 26);
            this.label_layoutNotFound.TabIndex = 2;
            this.label_layoutNotFound.Text = "Your layout not found in the list?\r\nDownload more online!";
            // 
            // button_downloadMore
            // 
            this.button_downloadMore.Location = new System.Drawing.Point(266, 139);
            this.button_downloadMore.Name = "button_downloadMore";
            this.button_downloadMore.Size = new System.Drawing.Size(104, 23);
            this.button_downloadMore.TabIndex = 3;
            this.button_downloadMore.Text = "Download Layouts";
            this.button_downloadMore.UseVisualStyleBackColor = true;
            this.button_downloadMore.Click += new System.EventHandler(this.button_downloadMore_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(505, 327);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Multilingual Keyboard";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tabPage_debug.ResumeLayout(false);
            this.tabPage_main.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage_layout.ResumeLayout(false);
            this.tabPage_layout.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItemRestart;
        private ToolStripMenuItem toolStripMenuItemExit;
        private ToolStripMenuItem toolStripMenuItemAbout;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private TabPage tabPage_debug;
        public RichTextBox richTextBox1;
        private TabPage tabPage_main;
        private Button buttonStart;
        private TabControl tabControl1;
        private TabPage tabPage_layout;
        private CheckedListBox checkedListBox_layoutsList;
        private Button button_downloadMore;
        private Label label_layoutNotFound;
        private Label label_layoutsSelected;
    }
}