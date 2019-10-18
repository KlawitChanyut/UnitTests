using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Threading.Tasks;

namespace TestNinja.Mocking
{
    public interface IRefactoring_InstallerHelper
    {
        void DownloadFile(string url, string path);
    }

    public class RefacInstallerHelper : IRefactoring_InstallerHelper
    {
        public void DownloadFile(string url, string path)
        {
            var client = new WebClient();
            client.DownloadFile(url, path);
        }
    }
}
