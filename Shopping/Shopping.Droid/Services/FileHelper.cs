using System;
using System.Collections.Generic;
using System.Linq;
using System;
using System.IO;
using Xamarin.Forms;
using Shopping.Core.Services;
using Shopping.Droid.Services;

[assembly: Dependency(typeof(FileHelper))]
namespace Shopping.Droid.Services
{
    public class FileHelper : IFileHelper
    {
        public string GetLocalFilePath(string filename)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            return Path.Combine(path, filename);
        }
    }
}