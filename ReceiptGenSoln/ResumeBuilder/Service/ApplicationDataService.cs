using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ResumeBuilder.Service
{
    public class ApplicationDataService
    {

        public void CopyDBFileToAppData() {
            string executablePath = Application.ExecutablePath;
            string sourceFolder = Path.GetDirectoryName(executablePath);
            string fileName = "ResumeBuilderDB.db";
            string sourcePath = Path.Combine(sourceFolder, fileName);
            string appDataPath = Application.UserAppDataPath;
            string destinationFolder = Path.Combine(appDataPath, "DBase");
            string destinationPath = Path.Combine(destinationFolder, fileName);

            if (!File.Exists(destinationPath))
            {
                if (!Directory.Exists(destinationFolder))
                {
                    Directory.CreateDirectory(destinationFolder);
                }
                File.Copy(sourcePath, destinationPath);
            }
        }
}
}
