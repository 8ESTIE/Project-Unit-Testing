using System.Net;
using TestNinja.Mocking.InstallerHelper;

namespace TestNinja.Mocking.InstallerHelper
{
    public class InstallerHelper
    {
        public bool DownloadInstallerHelper(string customerName, string installerName, IInstallerGetter installerGetter)
        {
            return installerGetter.DownloadInstaller(customerName, installerName);
        }
    }
}