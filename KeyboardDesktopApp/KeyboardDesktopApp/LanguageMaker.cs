using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System;
using System.Configuration;
using System.Windows.Forms;


namespace Form1
{
    internal static class LanguageMaker
    {
        private static string inCode = ConfigurationManager.AppSettings["arduinoOutputTemplateLocation"] + @"\Arduino_Program\Arduino_Program.ino";
        public static List<string> outCode = new List<string>();

        public static string inFirstImage;
        public static string inSecondImage;
        private static Image imageFirstPath;
        private static Image imageSecondPath;

        private static Bitmap inFirstBitmap;
        private static Bitmap inSecondBitmap;

        private static void GetImages(List<string> imagePaths)
        {
            inFirstImage = imagePaths[0];
            inSecondImage = imagePaths[1];
            imageFirstPath = Image.FromFile(inFirstImage);
            imageSecondPath = Image.FromFile(inSecondImage);

            inFirstBitmap = new Bitmap(FixedSize(imageFirstPath, 36, 24));
            inSecondBitmap = new Bitmap(FixedSize(imageSecondPath, 36, 24));
        }

        public static string outFile = AppDomain.CurrentDomain.BaseDirectory + "outFile.cpp";
        private static List<string> outLines = new List<string>();

        public static bool continueReading;

        private static void OutputCode()
        {
            outCode.Clear();

            IEnumerable<string> inLines = File.ReadLines(inCode);
            continueReading = true;
            foreach (string line in inLines)
            {
                if (continueReading)
                {
                    outCode.Add(line);
                    if (line.Contains("//@#"))
                    {
                        continueReading = !continueReading;
                        outCode.AddRange(outLines);
                    }
                }
                else if (line.Contains("//@#"))
                {
                    outCode.Add(line);
                    continueReading = !continueReading;
                }
            }
        }

        private static int genCount;
        private static List<string> langs = new List<string>();

        public static void UpdateArduinoTemplatePath(string newTempPath)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
            config.AppSettings.Settings["arduinoOutputTemplateLocation"].Value = newTempPath;
            config.Save();
            inCode = newTempPath + @"\Arduino_Program\Arduino_Program.ino";
        }

        public static void GenerateArduinoCode()
        {
            langs.Clear();
            genCount = Program.enabledLayouts.Count;
            langs.AddRange(Program.enabledLayouts);
            outLines.Clear();

            for (int i = 0; i < genCount; i++)
            {
                if (!File.Exists(langs[i] + ".klayout"))
                {
                    throw new IOException($"Cannot find {langs[i]} code file. Try re-generating the layout.");
                    //outLines.AddRange(GenerateLayoutCode(langs[i]));
                }
                else if (File.Exists(langs[i] + ".klayout"))
                {
                    outLines.AddRange(File.ReadLines(langs[i] + ".klayout"));
                }
            }
            try
            {
                OutputCode();
            }
            catch (Exception)
            {
                throw;
            }

            File.Delete(outFile);

            File.WriteAllLines(outFile, outCode);
            UploadToArduino();
        }

        private static void UploadToArduino()
        {
            ArduinoCompileAndUpload.Run();
        }

        private static List<string> outLinesLang = new List<string>();

        public static List<string> GenerateLayoutCode(string lang, List<string> imagePaths, Language language)
        {
            outLinesLang.Clear();
            outLinesLang.Add("// Name: " + language.name);
            outLinesLang.Add("// SID: " + language.serialID);
            outLinesLang.Add("// WID: " + language.windowsID);

            GetImages(imagePaths);
            outLinesLang.Add("if (current == '" + language.serialID + "'){");
            for (int l = 0; l <= 23; l++)
            {
                NewLine(l);
            }
            outLinesLang.Add("}");
            File.WriteAllLines(lang + ".klayout", outLinesLang);
            return outLinesLang;
        }

        private static string last;
        private static string ifText;

        private static void NewLine(int line)
        {
            //ifText = string.Format("if (row == {0}){", line);
            ifText = "if (row == " + (line + 1) + "){";
            outLinesLang.Add(ifText);
            if (line == 0)
            {
                outLinesLang.Add("digitalWrite(flm, HIGH);");
            }
            outLinesLang.Add("digitalWrite(din, LOW);");
            for (int i = 0; i < 4; i++)
            {
                outLinesLang.Add("pulse();");
            }
            last = "LOW";
            for (int x = 35; x >= 0; x--)
            {
                //System.Console.WriteLine(inSecondBitmap.GetPixel(x, line));
                if (inSecondBitmap.GetPixel(x, line) == Color.FromArgb(255, 255, 255, 255))
                {
                    if (last == "HIGH")
                    {
                        outLinesLang.Add("digitalWrite(din, LOW);");
                        last = "LOW";
                    }
                }
                else {
                    if (last == "LOW")
                    {
                        outLinesLang.Add("digitalWrite(din, HIGH);");
                        last = "HIGH";
                    }
                }
                outLinesLang.Add("pulse();");
            }

            outLinesLang.Add("digitalWrite(din, LOW);");
            for (int i = 0; i < 4; i++)
            {
                outLinesLang.Add("pulse();");
            }
            // Second (First) Image
            for (int x = 35; x >= 0; x--)
            {
                //System.Console.WriteLine(inFirstBitmap.GetPixel(x, line));
                if (inFirstBitmap.GetPixel(x, line) == Color.FromArgb(255, 255, 255, 255))
                {
                    if (last == "HIGH")
                    {
                        outLinesLang.Add("digitalWrite(din, LOW);");
                        last = "LOW";
                    }
                }
                else {
                    if (last == "LOW")
                    {
                        outLinesLang.Add("digitalWrite(din, HIGH);");
                        last = "HIGH";
                    }
                }
                outLinesLang.Add("pulse();");
            }
            outLinesLang.Add("digitalWrite(lp, HIGH);");
            outLinesLang.Add("digitalWrite(lp, LOW);");
            if (line == 0)
            {
                outLinesLang.Add("digitalWrite(flm, LOW);");
            }
            outLinesLang.Add("}");
        }

        /// <summary>
        /// Image Resizer - http://stackoverflow.com/questions/1940581/
        /// </summary>
        /// <param name="imgPhoto"></param>
        /// <param name="Width"></param>
        /// <param name="Height"></param>
        /// <returns></returns>
        public static Image FixedSize(Image imgPhoto, int Width, int Height)
        {
            int sourceWidth = imgPhoto.Width;
            int sourceHeight = imgPhoto.Height;
            int sourceX = 0;
            int sourceY = 0;
            int destX = 0;
            int destY = 0;

            float nPercent = 0;
            float nPercentW = 0;
            float nPercentH = 0;

            nPercentW = ((float)Width / (float)sourceWidth);
            nPercentH = ((float)Height / (float)sourceHeight);
            if (nPercentH < nPercentW)
            {
                nPercent = nPercentH;
                destX = System.Convert.ToInt16((Width -
                              (sourceWidth * nPercent)) / 2);
            }
            else {
                nPercent = nPercentW;
                destY = System.Convert.ToInt16((Height -
                              (sourceHeight * nPercent)) / 2);
            }

            int destWidth = (int)(sourceWidth * nPercent);
            int destHeight = (int)(sourceHeight * nPercent);

            Bitmap bmPhoto = new Bitmap(Width, Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            bmPhoto.SetResolution(imgPhoto.HorizontalResolution,
                             imgPhoto.VerticalResolution);

            Graphics grPhoto = Graphics.FromImage(bmPhoto);
            grPhoto.Clear(Color.White);
            grPhoto.InterpolationMode = InterpolationMode.HighQualityBicubic;

            grPhoto.DrawImage(imgPhoto,
                new Rectangle(destX, destY, destWidth, destHeight),
                new Rectangle(sourceX, sourceY, sourceWidth, sourceHeight),
                GraphicsUnit.Pixel);

            grPhoto.Dispose();
            return bmPhoto;
        }
    }
}