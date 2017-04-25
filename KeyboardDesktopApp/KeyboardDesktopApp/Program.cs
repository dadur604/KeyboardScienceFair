using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using WindowsInput;

namespace Form1 {
    /// <summary>
    /// Program Class
    /// Here is where the keyboard updating and functionality methods are found.
    /// </summary>
    internal class Program {
        public static Form1 _Form1;
        //public static LanguageMaker LanguageMaker = new LanguageMaker();

        //public static Dictionary<string, int> languageDictionary = new Dictionary<string, int>();
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

        /// <summary>
        /// Entry point for program. Starts Form1, and runs start method
        /// </summary>
        /// <param name="args"></param>
        [STAThread]
        public static void Main(string[] args) {
            // English: 67699721
            // Armenian: -266009557
            RefreshLayouts();
            try {
                Directory.Delete(AppDomain.CurrentDomain.BaseDirectory + "ArduinoOutput\\", true);
            } catch (Exception) {

            }
            Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "ArduinoOutput\\");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            _Form1 = new Form1();

            Application.Run(_Form1);
        }

        private string ans = File.ReadLines("a").Skip(1).Take(1).First();

        public static LanguageCollection RefreshLayouts() {
            //try {
            foreach (var item in languageDictionary.ToList<Language>()) {
                string path = AppDomain.CurrentDomain.BaseDirectory + item.name + ".klayout";

                if (!File.Exists(path)) {
                    languageDictionary.Remove(item);
                }
            }
            foreach (var path in Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, "*.klayout")) {

                string filename = Path.GetFileNameWithoutExtension(path);
                int serialID = int.Parse(File.ReadLines(path).Skip(1).Take(1).First().Trim(new char[] { '/', ' ', 'S', 'I', 'D', ':' }));
                int windowsID = int.Parse(File.ReadLines(path).Skip(2).Take(1).First().Trim(new char[] { '/', ' ', 'W', 'I', 'D', ':' }));

                if (languageDictionary.ContainsName(filename)) {
                    var language = languageDictionary.GetLanguageByName(filename);

                    language.serialID = serialID;
                    language.windowsID = windowsID;
                } else {
                    languageDictionary.Add(new Language() {
                        name = filename,
                        serialID = serialID,
                        windowsID = windowsID,
                        isDefault = false
                    });
                }
            }
            //} catch (Exception e) {
            //    ErrorHandle(e);
            //}

            return languageDictionary;
        }

        /// <summary>
        /// Main method for checking keyboard layout, and updating keyboard via serial.
        /// </summary>
        private static void SendSerial() {
            //  Console.WriteLine(layout);
            while (true) {
                _suspendEvent.WaitOne(Timeout.Infinite);

                //Get the current window's thread id
                IntPtr w_handle = GetForegroundWindow();
                uint w_tid = GetWindowThreadProcessId(w_handle, IntPtr.Zero);

                int layout_b = layout;
                layout = (int)GetKeyboardLayout(w_tid);
                bool found;

                if (layout != layout_b) {
                    found = false;
                    foreach (var item in languageDictionary) {
                        if (layout == item.windowsID) {
                            if (enabledLayouts.Contains(item.name)) {
                                ser.Write(item.serialID.ToString());
                                found = true;
                            }
                            Console.WriteLine(item.name);
                            _Form1.AppendTextDebug(item.name);
                            break;
                        }
                    }
                    if (!found) {
                        ser.Write(languageDictionary.GetDefaultSID().ToString());
                        Console.WriteLine("Unknown");
                        _Form1.AppendTextDebug(string.Format("Unknown : {0}", layout));
                    }
                }
            }
        }

        /// <summary>
        /// Main method for checking for serial input from keyboard, to type keys.
        /// </summary>
        private static void RecieveSerial() {
            InputSimulator keys = new InputSimulator();
            while (true) {
                _suspendEvent.WaitOne(Timeout.Infinite);

                int inserial;

                try {
                    inserial = ser.ReadByte();
                } catch (Exception) {
                    continue;
                }
                Console.WriteLine(inserial);
                if (inserial == 49) {
                    keys.Keyboard.KeyDown(WindowsInput.Native.VirtualKeyCode.VK_E);
                } else if (inserial == 50) {
                    keys.Keyboard.KeyDown(WindowsInput.Native.VirtualKeyCode.VK_N);
                } else if (inserial == 51) {
                    keys.Keyboard.KeyUp(WindowsInput.Native.VirtualKeyCode.VK_E);
                } else if (inserial == 52) {
                    keys.Keyboard.KeyUp(WindowsInput.Native.VirtualKeyCode.VK_N);
                } else {
                    Console.WriteLine(inserial);
                }
            }
        }

        /// <summary>
        /// Method restart will pause threads, re-open serial port, then resume threads.
        /// </summary>
        public static void Restart() {
            try {
                _suspendEvent.Reset();
                Start();
                errorState = false;

            } catch (Exception e) {
                ErrorHandle(e);
            }
        }

        /// <summary>
        /// Start method will open serial port, and start threads.
        /// </summary>
        public static void Start() {
            try {

                UpdateLayouts();

                if (!languageDictionary.ContainsDefault()) {
                    throw new Exception("No Default!");
                } else if (_Form1.GetNumberSelected() < 1) {
                    throw new Exception("Select at least one layout!");
                } else if (_Form1.GetNumberSelected() > 2) {
                    throw new Exception("Select no more than two layouts!");
                } else {
                    ser.Open();
                    if (ser.IsOpen) {
                        ser.Close();
                    }
                    LanguageMaker.GenerateArduinoCode();
                }



                ser.Open();

                if (!threadSend.IsAlive) {
                    threadSend.Start();
                }
                if (!threadRecieve.IsAlive) {
                    threadRecieve.Start();
                }
                _suspendEvent.Set();
                _Form1.AppendTextStatus("Running!");
            } catch (Exception e) {
                ErrorHandle(e);
            }
        }

        /// <summary>
        /// General ErrorHandle method will set the program into an error state, and display error in Form1
        /// </summary>
        /// <param name="e"></param>
        public static void ErrorHandle(Exception e) {
            errorState = true;
            errorMsg = e.ToString();
            _Form1.AppendTextStatus("Error has occurred. Message: " + e.Message);
            _Form1.AppendTextDebug(e.Message);
            _Form1.buttonStart_Update();
        }

        public static void UpdateLayouts() {

            enabledLayouts.Clear();

            if (checkedItems.Count == 0) {
                throw new Exception("Please select at least one layout!");
            } else if (checkedItems.Count > 2) {
                throw new Exception("Please select no more than two layouts!");
            } else if (!languageDictionary.ContainsDefault()) {
                ErrorHandle(new Exception("No Default!"));
            } else {

                foreach (var item in checkedItems) {
                    enabledLayouts.Add(item.ToString());
                }
            }

        }

        internal static void DeleteLayout(int index) {
            string lang = languageDictionary[index].name;
            File.Delete(lang + ".klayout");

            RefreshLayouts();
        }

        public static void UpdateLayoutFromUser(Language lang, string name, int sid, int wid) {

            string path = AppDomain.CurrentDomain.BaseDirectory + lang.name + ".klayout";

            lang.name = name;
            lang.serialID = sid;
            lang.windowsID = wid;

            // Write to file
            string[] lines = File.ReadAllLines(path);
            lines[0] = "// Name: " + lang.name;
            lines[1] = "// SID: " + lang.serialID;
            lines[2] = "// WID: " + lang.windowsID;
            File.Delete(path);

            path = AppDomain.CurrentDomain.BaseDirectory + lang.name + ".klayout";
            File.WriteAllLines(path, lines);

            RefreshLayouts();
        }
    }
}