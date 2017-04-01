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
        public static Form1 _Form1;

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

        // Start the Serial Communication Port

        public static SerialPort ser = new SerialPort("COM3");
        public static Thread SendThread = new Thread(new ThreadStart(SendSerial));
        public static Thread RecieveThread = new Thread(new ThreadStart(RecieveSerial));

        public static bool errorState = false;
        public static string errorMsg = null;

        public static int layout = (int)GetKeyboardLayout(0);

        public static ManualResetEvent _suspendEvent = new ManualResetEvent(true);

        // Main Program
        public static void Main(string[] args)
        {

            SerialPort ser = new SerialPort("COM3", 9600);
         
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            _Form1 = new Form1();
            Application.Run(_Form1);
            Start();


    }

        // Continuously checks for layout change, and sends serial
        public static void SendSerial()
        {
            
            //  Console.WriteLine(layout);
            srun = true;
            while (true)
            {
                _suspendEvent.WaitOne(Timeout.Infinite);

                //Get the current window's thread id
                IntPtr w_handle = GetForegroundWindow();
                uint w_tid = GetWindowThreadProcessId(w_handle, IntPtr.Zero);

                int layout_b = layout;
                layout = (int)GetKeyboardLayout(w_tid);

                if (layout != layout_b)
                {
                    if (layout == engLayout)
                    {
                        ser.Write("1");
                        Console.WriteLine("English");
                        //Form1.("English");
                        _Form1.AppendTextDebug("English");
                    }
                    else if (layout == armLayout)
                    {
                        ser.Write("2");
                        Console.WriteLine("Armenian");
                        _Form1.AppendTextDebug("Armenian");
                    }
                    else
                    {
                        ser.Write("1");
                        Console.WriteLine("Unknown");
                        _Form1.AppendTextDebug("Unknown");
                    }
                }
            }
        }

        // Continuously checks for incoming serial
        public static void RecieveSerial()
        {
            rrun = true;
            while (true)
            {
                _suspendEvent.WaitOne(Timeout.Infinite);

                int inserial;

                try
                {
                    inserial = ser.ReadByte();
                }
                catch (Exception)
                {
                    continue;
                }
                

                if (inserial == 49)
                {
                    if (layout == engLayout)
                    {
                        SendKeys.SendWait("e");
                    } else if (layout == armLayout) {
                        SendKeys.SendWait("ե");
                    }  else
                    {
                        SendKeys.SendWait("e");
                    }
                    
                } else if (inserial == 50)
                {
                    if (layout == engLayout)
                    {
                        SendKeys.SendWait("n");
                    }
                    else if (layout == armLayout)
                    {
                        SendKeys.SendWait("ն");
                    }
                    else
                    {
                        SendKeys.SendWait("n");
                    }
                }
                else
                {
                  //  Console.WriteLine(inserial);
                }
            }
        }

        public static void Restart()
        {
            try
            {
                _suspendEvent.Reset();
                Thread.Sleep(500);
                ser.Close();
                ser.Open();
                _suspendEvent.Set();

                if (!SendThread.IsAlive)
                {
                    SendThread.Start();
                }
                if (!RecieveThread.IsAlive)
                {
                    RecieveThread.Start();
                }
                
                _Form1.AppendTextStatus("Running!");
            }
            catch (Exception e)
            {
                errorHandle(e);
            }
            
        }

        public static void Start()
        {
            try
            {
                ser.Open();

                SendThread.Start();
                RecieveThread.Start();
            }
            catch (Exception e)
            {
                errorHandle(e);
            }
        }
        
        private static void errorHandle(Exception e)
        {
            errorState = true;
            errorMsg = e.ToString();
            _Form1.AppendTextStatus("Error has occured, please restart.");
        }
    }
}

