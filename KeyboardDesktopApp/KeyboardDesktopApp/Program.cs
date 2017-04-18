using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace Form1
{
    /// <summary>
    /// Program Class
    /// Here is where the keyboard updating and functionality methods are found.
    /// </summary>
    internal class Program
    {
        public static Form1 _Form1;
        //public static LanguageMaker LanguageMaker = new LanguageMaker();

        //public static Dictionary<string, int> languageDictionary = new Dictionary<string, int>();
        // TODO: Create custom list class
        public static LanguageCollection languageDictionary = new LanguageCollection();

        // Define all external functions
        [DllImport("user32.dll")]
        private static extern IntPtr GetKeyboardLayout(uint idThread);

        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        private static extern uint GetWindowThreadProcessId(IntPtr hWnd, IntPtr ProcessId);

        // Start the Serial Communication Port
        public static SerialPort ser = new SerialPort("COM3", 9600);

        // Define Send and Receive threads
        public static Thread threadSend = new Thread(new ThreadStart(SendSerial));

        public static Thread threadRecieve = new Thread(new ThreadStart(RecieveSerial));

        // Initialize error-handling variables
        public static bool errorState;

        public static string errorMsg;
        public static ManualResetEvent _suspendEvent = new ManualResetEvent(true);

        public static int layout = (int)GetKeyboardLayout(0);

        public static CheckedListBox.CheckedItemCollection checkedItems;
        public static List<string> enabledLayouts = new List<string>();
        // TODO: Select DEfault language

        /// <summary>
        /// Entry point for program. Starts Form1, and runs start method
        /// </summary>
        /// <param name="args"></param>
        [STAThread]
        public static void Main(string[] args)
        {
            // English: 67699721
            // Armenian: -266009557
            languageDictionary.AddRange(RefreshLayouts());
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            _Form1 = new Form1();

            Application.Run(_Form1);
        }

        private string ans = File.ReadLines("a").Skip(1).Take(1).First();

        public static LanguageCollection RefreshLayouts()
        {
            try
            {
                languageDictionary.Clear();
                foreach (var item in Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, "*.klayout"))
                {
                    string name = File.ReadLines(item).Take(1).First().Trim(new char[] { '/', ' ', 'N', 'a', 'm', 'e', ':' });
                    int serialID = int.Parse(File.ReadLines(item).Skip(1).Take(1).First().Trim(new char[] { '/', ' ', 'S', 'I', 'D', ':' }));
                    int windowsID = int.Parse(File.ReadLines(item).Skip(2).Take(1).First().Trim(new char[] { '/', ' ', 'W', 'I', 'D', ':' }));
                    languageDictionary.Add(new Language()
                    {
                        name = name,
                        serialID = serialID,
                        windowsID = windowsID
                    });
                }
            }
            catch (Exception e)
            {
                ErrorHandle(e);
            }

            return languageDictionary;
        }

        /// <summary>
        /// Main method for checking keyboard layout, and updating keyboard via serial.
        /// </summary>
        private static void SendSerial()
        {
            //  Console.WriteLine(layout);
            while (true)
            {
                _suspendEvent.WaitOne(Timeout.Infinite);

                //Get the current window's thread id
                IntPtr w_handle = GetForegroundWindow();
                uint w_tid = GetWindowThreadProcessId(w_handle, IntPtr.Zero);

                int layout_b = layout;
                layout = (int)GetKeyboardLayout(w_tid);
                bool found;

                if (layout != layout_b)
                {
                    found = false;
                    foreach (var item in languageDictionary)
                    {
                        if (layout == item.windowsID)
                        {
                            if (enabledLayouts.Contains(item.name))
                            {
                                ser.Write(item.serialID.ToString());
                                found = true;
                            }
                            Console.WriteLine(item.name);
                            _Form1.AppendTextDebug(item.name);
                            break;
                        }
                    }
                    if (!found)
                    {
                        ser.Write("1");
                        Console.WriteLine("Unknown");
                        _Form1.AppendTextDebug(string.Format("Unknown : {0}", layout));
                    }
                }
            }
        }

        /// <summary>
        /// Main method for checking for serial input from keyboard, to type keys.
        /// </summary>
        private static void RecieveSerial()
        {
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
                    SendKeys.SendWait("e");
                }
                else if (inserial == 50)
                {
                    SendKeys.SendWait("n");
                }
                else {
                    //  Console.WriteLine(inserial);
                }
            }
        }

        /// <summary>
        /// Method restart will pause threads, re-open serial port, then resume threads.
        /// </summary>
        public static void Restart()
        {
            try
            {
                _suspendEvent.Reset();
                ser.Close();
                Start();
                _Form1.AppendTextStatus("Running!");
                errorState = false;
                _Form1.buttonStart_Update();
            }
            catch (Exception e)
            {
                ErrorHandle(e);
            }
        }

        /// <summary>
        /// Start method will open serial port, and start threads.
        /// </summary>
        public static void Start()
        {
            try
            {
                UpdateLayouts();
                LanguageMaker.GenerateArduinoCode();
            }
            catch (Exception e)
            {
                ErrorHandle(e);
            }

            try
            {
                if (ser.IsOpen)
                {
                    ser.Close();
                }
                ser.Open();

                if (!threadSend.IsAlive)
                {
                    threadSend.Start();
                }
                if (!threadRecieve.IsAlive)
                {
                    threadRecieve.Start();
                }
                _Form1.buttonStart_Update();
                _suspendEvent.Set();
            }
            catch (Exception e)
            {
                ErrorHandle(e);
            }
        }

        /// <summary>
        /// General ErrorHandle method will set the program into an error state, and display error in Form1
        /// </summary>
        /// <param name="e"></param>
        public static void ErrorHandle(Exception e)
        {
            errorState = true;
            errorMsg = e.ToString();
            _Form1.AppendTextStatus("Error has occurred. Message: " + e.Message);
            _Form1.AppendTextDebug(e.Message);
            _Form1.buttonStart_Update();
        }

        public static void UpdateLayouts()
        {
            
            enabledLayouts.Clear();
            try
            {
                foreach (var item in checkedItems)
                {
                    enabledLayouts.Add(item.ToString());
                }
            }
            catch (Exception e)
            {
                ErrorHandle(e);
            }
        }
    }
}