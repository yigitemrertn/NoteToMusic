using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace NoteToMusic
{
    public class ConvertExtension
    {
        public static void Convert(string mxlPath,string xmlPath)
        {

            string tempDir = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
            Directory.CreateDirectory(tempDir);

            ZipFile.ExtractToDirectory(mxlPath, tempDir);

            foreach (var file in Directory.GetFiles(tempDir, "*.xml", SearchOption.AllDirectories))
            {
                File.Copy(file, xmlPath, true);
                break;
            }

            Directory.Delete(tempDir, true);
        }
    }
}
