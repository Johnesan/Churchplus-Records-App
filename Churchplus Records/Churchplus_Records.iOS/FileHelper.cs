using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xamarin.Forms;
using Churchplus_Records.iOS;


[assembly: Dependency(typeof(FileHelper))]
namespace Churchplus_Records.iOS
{
    public class FileHelper : IFileHelper
    {
        public string GetLocalFilePath(string filename)
        {
            string docFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libFolder = Path.Combine(docFolder, "..", "Library", "Databases");

            if (!Directory.Exists(libFolder))
            {
                Directory.CreateDirectory(libFolder);
            }

            return Path.Combine(libFolder, filename);
        }
    }
}
