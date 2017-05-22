using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Windows.Storage;
using XAMARIN.OverviewOfTasks.UWP;
using Xamarin.Forms;

[assembly: Dependency(typeof(FileHelper))]
namespace XAMARIN.OverviewOfTasks.UWP
{
    public class FileHelper : IFileHelper
    {
        public string GetLocalFilePath(string filename)
        {
            return Path.Combine(ApplicationData.Current.LocalFolder.Path, filename);
        }
    }
}
