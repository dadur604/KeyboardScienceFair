using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.IO.Ports;
using System.Windows.Forms;

namespace ConsoleApplication1
{
    class Program {

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
        
        // Main Program
        static void Main(string[] args)
        {
            ser.Open();

            Thread SendThread = new Thread(new ThreadStart(SendSerial));
            Thread RecieveThread = new Thread(new ThreadStart(RecieveSerial));
            SendThread.Start();
            RecieveThread.Start();
        }

        // Continuously checks for layout change, and sends serial
        static void SendSerial()
        {
            int layout = (int)GetKeyboardLayout(0);
            //  Console.WriteLine(layout);

            while (true)
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
        static void RecieveSerial()
        {
            while (true)
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
    }
}

