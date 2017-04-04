using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Form1 {

    public partial class Form1 : Form {

        public Form1() {
            
            ContextMenu contextMenu1 = new ContextMenu();
            MenuItem menuItem1 = new MenuItem();

            this.InitializeComponent();
            this.Resize += new System.EventHandler(this.Form1_Resize);
            _notifyicon.DoubleClick += new System.EventHandler(this._notifyicon_DoubleClick);
            menuItem1.Click += new System.EventHandler(menuItem1_Click);
            this.toolStripMenuItemExit.Click += new EventHandler(toolStripMenuItemExit_Click);
            this.toolStripMenuItemRestart.Click += new EventHandler(toolStripMenuItemRestart_Click);
            Application.ApplicationExit += new EventHandler(onApplicationExit);

            this.toolStripStatusLabel1.Text = "Keyboard Science Fair!";
            this.checkedListBox_layoutsList.ItemCheck += (s, e) => { if(e.CurrentValue == CheckState.Indeterminate) e.NewValue = CheckState.Indeterminate; };

            // Initialize contextMenu1
            contextMenu1.MenuItems.AddRange(
                        new System.Windows.Forms.MenuItem[] { menuItem1 });

            // Initialize menuItem1
            menuItem1.Index = 0;
            menuItem1.Text = "E&xit";

            _notifyicon.Icon = new Icon("appicon.ico");
            _notifyicon.ContextMenu = contextMenu1;

            Program.updateLayouts(checkedListBox_layoutsList.CheckedItems);
        }

        private NotifyIcon _notifyicon = new NotifyIcon();

        public void AppendTextDebug(String text) {
            if(this.InvokeRequired) {
                this.Invoke(new Action<string>(AppendTextDebug), new object[] { text });
                return;
            }
            this.richTextBox1.AppendText(text + "\n");
        }

        public void AppendTextStatus(String text) {
            if(this.InvokeRequired) {
                this.Invoke(new Action<string>(AppendTextStatus), new object[] { text });
                return;
            }
            this.toolStripStatusLabel1.Text = text;
        }

        // Minimize to System Tray
        private void Form1_Resize(object sender, EventArgs e) {
            if(FormWindowState.Minimized == this.WindowState) {
                _notifyicon.Visible = true;
                _notifyicon.Icon = new Icon("appicon.ico");
                _notifyicon.Text = "Multilingual Keyboard";
                this.Hide();
            } else if(FormWindowState.Normal == this.WindowState) {
                _notifyicon.Visible = false;
            }
        }

        // On double-click of icon, open form
        private void _notifyicon_DoubleClick(object Sender, EventArgs e) {
            // Show the form when the user double clicks on the notify icon.

            // Set the WindowState to normal if the form is minimized.
            this.Show();
            if(this.WindowState == FormWindowState.Minimized)
                this.WindowState = FormWindowState.Normal;

            // Activate the form.
            this.Activate();
        }

        // On click of 'exit', exit the form
        private void menuItem1_Click(object Sender, EventArgs e) {
            this.Close();
            Application.Exit();
            Environment.Exit(0);
        }

        // On click of 'exit', exit the form
        private void toolStripMenuItemExit_Click(object Sender, EventArgs e) {
            this.Close();
            Application.Exit();
            Environment.Exit(0);
        }

        // On click of 'restart', restart threads
        private void toolStripMenuItemRestart_Click(object Sender, EventArgs e) {
            this.toolStripStatusLabel1.Text = "Restarting...";
            Program.Restart();
        }

        // On exit, close threads.
        private void onApplicationExit(object Sender, EventArgs e) {
            Program.ser.Close();
            Application.Exit();
            Environment.Exit(0);
        }

        private void buttonStart_Click(object sender, EventArgs e) {
            if(Program.errorState) {
                Program.Restart();
            }
            toolStripStatusLabel1.Text = "Running!";
            Program.Start();
            buttonStart_Update();
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e) {
            if(Program.errorState) {
                MessageBox.Show(
                    string.Format("Error Message {0}", Program.errorMsg),
                    "Error State",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void toolStripMenuItemAbout_Click(object sender, EventArgs e) {
            MessageBox.Show(
                "This software was made to accompany the Multilingual Keyboad science project. \n \nProject Developers: Narek Daduryan & Ethan Keshishian \nProject Github: github.com/dadur604/keyboardsciencefair \n \nReleased 2017",
                "Multilingual Keyboard");
        }

        public void buttonStart_Update() {
            if(Program.errorState) {
                buttonStart.Enabled = true;
                buttonStart.Text = "Restart";
            } else if(Program.threadSend.IsAlive && Program.threadRecieve.IsAlive) {
                buttonStart.Text = "Started";
                buttonStart.Enabled = false;
            } else {
                buttonStart.Text = "Start";
                buttonStart.Enabled = true;
            }
        }

        private void button_downloadMore_Click(object sender, EventArgs e) {
            System.Diagnostics.Process.Start("http://www.github.com/dadur604/keyboardsciencefair");
        }

        private void checkedListBox_layoutsList_SelectedIndexChanged(object sender, EventArgs e) {
            Program.updateLayouts(checkedListBox_layoutsList.CheckedItems);
        }
    }
}