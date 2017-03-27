using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Form1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            ContextMenu contextMenu1 = new ContextMenu();
            MenuItem menuItem1 = new MenuItem();

            this.InitializeComponent();
            this.Resize += new System.EventHandler(this.Form1_Resize);
            _notifyicon.DoubleClick += new System.EventHandler(this._notifyicon_DoubleClick);
            menuItem1.Click += new System.EventHandler(menuItem1_Click);
            this.exitToolStripMenuItem.Click += new EventHandler(exitToolStripMenuItem_Click);
            this.restartToolStripMenuItem.Click += new EventHandler(restartToolStripMenuItem_Click);
            Application.ApplicationExit += new EventHandler(onApplicationExit);

            this.toolStripStatusLabel1.Text = "Running!";



            // Initialize contextMenu1
            contextMenu1.MenuItems.AddRange(
                        new System.Windows.Forms.MenuItem[] { menuItem1 });

            // Initialize menuItem1
            menuItem1.Index = 0;
            menuItem1.Text = "E&xit";
            

            _notifyicon.Icon = new Icon("appicon.ico");
            _notifyicon.ContextMenu = contextMenu1;
        }

        NotifyIcon _notifyicon = new NotifyIcon();


        // Minimize to System Tray
        private void Form1_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == this.WindowState)
            {
                _notifyicon.Visible = true;
                _notifyicon.Icon = new Icon("appicon.ico");
                _notifyicon.Text = "Multilingual Keyboard";
                this.Hide();
            }
            else if (FormWindowState.Normal == this.WindowState)
            {
                _notifyicon.Visible = false;
            }
        }


        // On double-click of icon, open form
        private void _notifyicon_DoubleClick(object Sender, EventArgs e)
        {
            // Show the form when the user double clicks on the notify icon.

            // Set the WindowState to normal if the form is minimized.
            this.Show();
            if (this.WindowState == FormWindowState.Minimized)
                this.WindowState = FormWindowState.Normal;

            // Activate the form.       
            this.Activate();
        }

        // On click of 'exit', exit the form
        private void menuItem1_Click(object Sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
            Environment.Exit(0);
        }

        // On click of 'exit', exit the form
        private void exitToolStripMenuItem_Click(object Sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
            Environment.Exit(0);
        }

        // On click of 'restart', restart threads
        private void restartToolStripMenuItem_Click(object Sender, EventArgs e)
        {
            this.toolStripStatusLabel1.Text = "Restarting...";
            Program.Restart();
            this.toolStripStatusLabel1.Text = "Running!";
        }

        // On exit, close threads.
        private void onApplicationExit(object Sender, EventArgs e)
        {
            Application.Exit();
            Environment.Exit(0);
        }
    }
}
