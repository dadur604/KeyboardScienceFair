using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using ArduinoUploader;
using System.IO;

namespace Form1 {
    class ArduinoCompileAndUpload {

        public static void Run() {
            Compile(AppDomain.CurrentDomain.BaseDirectory);
            Upload(AppDomain.CurrentDomain.BaseDirectory + "ArduinoOutput\\");
        }

        private static void Compile(string path) {
            List<string> cmdCommands = new List<string>();

            cmdCommands.Add(@"arduino-builder -compile");
            cmdCommands.Add("-logger=machine");
            cmdCommands.Add("-hardware \"C:\\Program Files (x86)\\Arduino\\hardware\"");
            cmdCommands.Add("-tools \"C:\\Program Files (x86)\\Arduino\\tools-builder\"");
            cmdCommands.Add("-tools \"C:\\Program Files (x86)\\Arduino\\hardware\\tools\\avr\"");
            cmdCommands.Add("-built-in-libraries \"C:\\Program Files (x86)\\Arduino\\libraries\"");
            //cmdCommands.Add("-libraries \"C:\\Users\\dadur\\Documents\\Arduino\\libraries\"");
            cmdCommands.Add("-fqbn=arduino:avr:uno");
            cmdCommands.Add("-vid-pid=0X2341_0X0043");
            cmdCommands.Add("-ide-version=10607");
            cmdCommands.Add("-build-path " + path + "ArduinoOutput\\");
            cmdCommands.Add("-warnings=none");
            cmdCommands.Add("-prefs=build.warn_data_percentage=75");
            cmdCommands.Add("-verbose");
            cmdCommands.Add(path + "outFile.cpp");
            string cmdInput = String.Join(" ", cmdCommands.ToArray<string>());

            Process cmd = new Process();
            cmd.StartInfo.FileName = "cmd.exe ";
            //cmd.StartInfo.Arguments = cmdInput;
            cmd.StartInfo.WorkingDirectory = @"C:\Program Files (x86)\Arduino\";
            cmd.StartInfo.RedirectStandardInput = true;
            cmd.StartInfo.RedirectStandardOutput = true;
            //cmd.StartInfo.CreateNoWindow = true;
            cmd.StartInfo.UseShellExecute = false;
            cmd.Start();

            //cmd.StandardInput.WriteLine(@"cd C:\Program Files (x86)\Arduino\");
            cmd.StandardInput.WriteLine(cmdInput);
            Console.WriteLine("wrote command");
            cmd.StandardInput.WriteLine("exit");
            Console.WriteLine("wrote exit");

            Console.WriteLine(cmd.StandardOutput.ReadToEnd());

            cmd.StandardInput.Flush();
            cmd.StandardInput.Close();

            cmd.WaitForExit();
        }

        private static void Upload(string path) {
            try {
                ArduinoSketchUploader uploader = new ArduinoSketchUploader(
                new ArduinoSketchUploaderOptions() {
                    FileName = path + "outFile.cpp.hex",
                    ArduinoModel = ArduinoUploader.Hardware.ArduinoModel.UnoR3,
                    PortName = "COM3"
                });
                bool good = true;
                try {
                    Program.ser.Open();
                } catch (Exception e) {
                    Program.ErrorHandle(e);
                    good = false;
                } finally {
                    Program.ser.Close();
                }
                if (good) {
                    uploader.UploadSketch();
                    Console.WriteLine("done");
                }
                
            } catch (Exception e) {
                Program.ErrorHandle(e);
            }
            
            try {
                Directory.Delete(path, true);
            } catch (Exception) {
            }

            Directory.CreateDirectory(path);
        }



    }
}
