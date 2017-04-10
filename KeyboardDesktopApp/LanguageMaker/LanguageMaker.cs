using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace LanguageMaker {

    internal class LanguageMaker {
        public static string inCode = @"C:\Users\dadur\Documents\_Narek\Programs\KeyboardScienceFair\Arduino_Program\Arduino_Program.ino";
        public static List<string> outCode = new List<string>();

        public static string inFirstImage = "engcImage.png";
        public static string inSecondImage = "engecImage.png";
        private static Image imageFirstPath = Image.FromFile(inFirstImage);
        private static Image imageSecondPath = Image.FromFile(inSecondImage);
        private static Size outSize = new Size(36, 24);

        private static Bitmap inFirstBitmap = new Bitmap(imageFirstPath, outSize);
        private static Bitmap inSecondBitmap = new Bitmap(imageSecondPath, outSize);

        public static string outFile = "outFile.txt";
        private static List<string> outLines = new List<string>();

        public static bool continueReading;

        private static void OutputCode() {
            IEnumerable<string> inLines = File.ReadLines(inCode);
            continueReading = true;
            foreach (string line in inLines) {
                if (continueReading) {
                    outCode.Add(line);
                    if (line.Contains("//@#")) {
                        continueReading = !continueReading;
                        outCode.AddRange(outLines);
                    }
                } else if (line.Contains("//@#")) {
                    outCode.Add(line);
                    continueReading = !continueReading;
                }
            }
        }

        //TODO Change current number index
        private static void GenerateArduinoCode(string[] args) {
            outLines.Add("if (current == '" + 1 + "'){");
            for (int l = 0; l <= 23; l++) {
                NewLine(l);
            }
            outLines.Add("}");
            OutputCode();
            try {
                File.Delete(outFile);
            } catch (System.Exception) {
            }
            File.AppendAllLines(outFile, outCode);
            System.Console.Read();
        }

        private static string last;
        private static string ifText;

        private static void NewLine(int line) {
            //ifText = string.Format("if (row == {0}){", line);
            ifText = "if (row == " + (line + 1) + "){";
            outLines.Add(ifText);
            if (line == 0) {
                outLines.Add("digitalWrite(flm, HIGH);");
            }
            outLines.Add("digitalWrite(din, LOW);");
            for (int i = 0; i < 4; i++) {
                outLines.Add("pulse();");
            }
            last = "LOW";
            for (int x = 35; x >= 0; x--) {
                System.Console.WriteLine(inSecondBitmap.GetPixel(x, line));
                if (inSecondBitmap.GetPixel(x, line) == Color.FromArgb(255, 255, 255, 255)) {
                    if (last == "HIGH") {
                        outLines.Add("digitalWrite(din, LOW);");
                        last = "LOW";
                    }
                } else {
                    if (last == "LOW") {
                        outLines.Add("digitalWrite(din, HIGH);");
                        last = "HIGH";
                    }
                }
                outLines.Add("pulse();");
            }

            outLines.Add("digitalWrite(din, LOW);");
            for (int i = 0; i < 4; i++) {
                outLines.Add("pulse();");
            }
            // Second (First) Image
            for (int x = 35; x >= 0; x--) {
                System.Console.WriteLine(inFirstBitmap.GetPixel(x, line));
                if (inFirstBitmap.GetPixel(x, line) == Color.FromArgb(255, 255, 255, 255)) {
                    if (last == "HIGH") {
                        outLines.Add("digitalWrite(din, LOW);");
                        last = "LOW";
                    }
                } else {
                    if (last == "LOW") {
                        outLines.Add("digitalWrite(din, HIGH);");
                        last = "HIGH";
                    }
                }
                outLines.Add("pulse();");
            }
            outLines.Add("digitalWrite(lp, HIGH);");
            outLines.Add("digitalWrite(lp, LOW);");
            if (line == 0) {
                outLines.Add("digitalWrite(flm, LOW);");
            }
            outLines.Add("}");
        }
    }
}