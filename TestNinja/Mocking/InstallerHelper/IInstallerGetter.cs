using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestNinja.Mocking.InstallerHelper
{
    public interface IInstallerGetter
    {
            bool DownloadInstaller(string customerName, string installerName);
    }
}
