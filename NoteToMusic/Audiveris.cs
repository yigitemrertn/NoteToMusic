
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;


namespace NoteToMusic
{
    public class Audiveris
    {
        public static void ConvertToMusicXml(string inputImage, string outputXml)
        {
            string audiverisPath = @".\Audiveris\bin\Audiveris.bat";

            ProcessStartInfo psi = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                Arguments = $"/C \"\"{audiverisPath}\" -batch -export \"{inputImage}\" -output {outputXml}\"\"",
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using (Process process = new Process { StartInfo = psi })
            {
                process.Start();

                string output = process.StandardOutput.ReadToEnd();
                string error = process.StandardError.ReadToEnd();

                process.WaitForExit();

                MessageBox.Show("Hata: " + error);

         
            }
        }
    }
    
}
