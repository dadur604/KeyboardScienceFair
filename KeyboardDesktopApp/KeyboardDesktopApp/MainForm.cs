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
            this.checkedListBox_layoutsList.ItemCheck += (s, e) => { if (e.CurrentValue == CheckState.Indeterminate) e.NewValue = CheckState.Indeterminate; };
            //checkedListBox_layoutsList.Items.Add("English", CheckState.Indeterminate);
            //checkedListBox_layoutsList.Items.Add("Armenian");

            foreach (var item in Program.RefreshLayouts()) {
                checkedListBox_layoutsList.Items.Add(item.name);
            }

            buttonRefreshLayouts.Font = new Font("Wingdings 3", 10, FontStyle.Bold);
            buttonRefreshLayouts.Text = Char.ConvertFromUtf32(80); // or 80

            // Initialize contextMenu1
            contextMenu1.MenuItems.AddRange(
                        new System.Windows.Forms.MenuItem[] { menuItem1 });

            // Initialize menuItem1
            menuItem1.Index = 0;
            menuItem1.Text = "E&xit";

            _notifyicon.Icon = new Icon("appicon.ico");
            _notifyicon.ContextMenu = contextMenu1;

            Program.checkedItems = (checkedListBox_layoutsList.CheckedItems);
        }

        private NotifyIcon _notifyicon = new NotifyIcon();

        public void AppendTextDebug(string text) {
            if (this.InvokeRequired) {
                this.Invoke(new Action<string>(AppendTextDebug), new object[] { text });
                return;
            }
            this.richTextBox1.AppendText(text + "\n");
        }

        public void AppendTextStatus(string text) {
            if (this.InvokeRequired) {
                this.Invoke(new Action<string>(AppendTextStatus), new object[] { text });
                return;
            }
            this.toolStripStatusLabel1.Text = text;
        }

        // Minimize to System Tray
        private void Form1_Resize(object sender, EventArgs e) {
            if (FormWindowState.Minimized == this.WindowState) {
                _notifyicon.Visible = true;
                _notifyicon.Icon = new Icon("appicon.ico");
                _notifyicon.Text = "Multilingual Keyboard";
                this.Hide();
            } else if (FormWindowState.Normal == this.WindowState) {
                _notifyicon.Visible = false;
            }
        }

        // On double-click of icon, open form
        private void _notifyicon_DoubleClick(object Sender, EventArgs e) {
            // Show the form when the user double clicks on the notify icon.

            // Set the WindowState to normal if the form is minimized.
            this.Show();
            if (this.WindowState == FormWindowState.Minimized)
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
            if (Program.errorState) {
                Program.Restart();
            } else {
                Program.Start();
            }

            buttonStart_Update();

        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e) {
            if (Program.errorState) {
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
            if (Program.errorState) {
                buttonStart.Enabled = true;
                buttonStart.Text = "Restart";
            } else if (Program.threadSend.IsAlive && Program.threadRecieve.IsAlive) {
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
            if (checkedListBox_layoutsList.CheckedItems.Count > 2) {
                Program.ErrorHandle(new Exception("Please select no more than two layouts!"));
            }
            Program.checkedItems = (checkedListBox_layoutsList.CheckedItems);

            foreach (var item in Program.languageDictionary) {
                if (!checkedListBox_layoutsList.CheckedItems.Contains(item.name) && item.isDefault) {
                    pictureBoxDefaultCheck.Visible = false;
                    item.isDefault = false;
                }
            }

            //TODO: un default when unselect default
        }

        private void toolStripMenuItemSettings_Click(object sender, EventArgs e) {
            Form SettingsForm = new SettingsForm();
            SettingsForm.ShowDialog();
        }

        private void buttonRefreshLayouts_Click(object sender, EventArgs e) {
            checkedListBox_layoutsList.Items.Clear();
            foreach (var item in Program.RefreshLayouts()) {
                checkedListBox_layoutsList.Items.Add(item.name);
            }
        }

        private void toolStripMenuItemCreateLayout_Click(object sender, EventArgs e) {
            Form LayoutCreator = new LayoutCreator();
            LayoutCreator.Show();
        }

        private void checkedListBox_layoutsList_MouseClick(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Right) {
                var itemIndex = checkedListBox_layoutsList.IndexFromPoint(e.Location);
                var itemClicked = checkedListBox_layoutsList.Items[itemIndex];
                ContextMenu layoutRightClickMenu = new ContextMenu();
                layoutRightClickMenu.Tag = itemIndex;
                layoutRightClickMenu.MenuItems.Add(new MenuItem("Set Default", new EventHandler(layoutRightClickMenu_Click)));
                layoutRightClickMenu.MenuItems.Add(new MenuItem("Edit", new EventHandler(layoutRightClickMenu_Click)));
                layoutRightClickMenu.MenuItems.Add(new MenuItem("Delete", new EventHandler(layoutRightClickMenu_Click)));
                layoutRightClickMenu.Show(checkedListBox_layoutsList, e.Location);

            }
        }

        private void layoutRightClickMenu_Click(object sender, EventArgs e) {
            MenuItem senderm = (MenuItem)sender;
            switch (senderm.Text) {
                case ("Set Default"):
                    SetDefault(senderm.Parent.Tag);
                    checkedListBox_layoutsList.SetItemChecked((int)senderm.Parent.Tag, true);
                    break;
                case ("Edit"):
                    var lang = Program.languageDictionary[(int)senderm.Parent.Tag];
                    EditLayoutForm form = new EditLayoutForm(lang);
                    if (form.ShowDialog() == DialogResult.OK) {
                        Program.UpdateLayoutFromUser(lang: lang, name: form.textBoxName.Text, sid: (int)form.numericSerialID.Value, wid: (int)form.numericWindowsLayoutID.Value);
                    }
                    break;
                case ("Delete"):
                    int index = (int)senderm.Parent.Tag;
                    if (MessageBox.Show($"Are you sure you want to delete {Program.languageDictionary[index].name}?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes) {

                        if (Program.languageDictionary[index].isDefault) {
                            pictureBoxDefaultCheck.Visible = false;
                        }
                        Program.DeleteLayout(index);
                        buttonRefreshLayouts_Click(null, null);

                    }
                    break;
            }
        }

        private void SetDefault(object index) {
            var lang = checkedListBox_layoutsList.Items[(int)index];
            Program.languageDictionary.SetDefault(lang.ToString());
            pictureBoxDefaultCheck.Location = new Point(158, 36 + (int)index * 16);
            pictureBoxDefaultCheck.Visible = true;

        }

        public int GetNumberSelected() {
            return checkedListBox_layoutsList.SelectedItems.Count;
        }
    }
}