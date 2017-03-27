using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.IO.Ports;
using System.Windows.Forms;


namespace Form1
{
    class Program
    {

        static bool rrun;
        static bool srun;

        // Define all external functions
        [DllImport("user32.dll")]
        static extern IntPtr GetKeyboardLayout(uint idThread);
        [DllImport("user32.dll")]
        static extern IntPtr GetForegroundWindow();
        [DllImport("user32.dll")]
        static extern uint GetWindowThreadProcessId(IntPtr hWnd, IntPtr ProcessId);

        // Define a few constant variables
        public static int engLayout = 67699721;
        public static int armLayout = -266009557;
        public static byte[] bytes = {1, 2};

        // Start the Serial Communication Port
        public static SerialPort ser = new SerialPort("COM1");
        public static Thread SendThread = new Thread(new ThreadStart(SendSerial));
        public static Thread RecieveThread = new Thread(new ThreadStart(RecieveSerial));

        // Main Program
        static void Main(string[] args)
        {

            // Start the form
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

            ser.Open();

            
            SendThread.Start();
            RecieveThread.Start();
        }

        // Continuously checks for layout change, and sends serial
        public static void SendSerial()
        {
            int layout = (int)GetKeyboardLayout(0);
            //  Console.WriteLine(layout);
            srun = true;
            while (srun)
            {
                //Get the current window's thread id
                IntPtr w_handle = GetForegroundWindow();
                uint w_tid = GetWindowThreadProcessId(w_handle, IntPtr.Zero);

                int layout_b = layout;
                layout = (int)GetKeyboardLayout(w_tid);

                if (layout != layout_b)
                {
                    if (layout == engLayout)
                    {
                        ser.Write(bytes, 0, 1);
                        Console.WriteLine("English");
                    }
                    else if (layout == armLayout)
                    {
                        ser.Write(bytes, 1, 1);
                        Console.WriteLine("Armenian");
                    }
                    else
                    {
                        ser.Write(bytes, 0, 1);
                        Console.WriteLine("Unknown");
                    }
                }
            }
        }

        // Continuously checks for incoming serial
        public static void RecieveSerial()
        {
            rrun = true;
            while (rrun)
            {
                int inserial = ser.ReadByte();

                if (inserial == 1)
                {
                    SendKeys.Send("e");
                } else if (inserial == 2)
                {
                    SendKeys.Send("n");
                }
            }
        }

        public static void Restart()
        {
            srun = false;
            rrun = false;
            ser.Close();
            ser.Open();
            srun = true;
            rrun = true;
        }
    }
}

