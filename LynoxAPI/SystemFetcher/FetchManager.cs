using Lynox.SystemUtils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lynox.LynoxAPI.SystemFetcher
{
    public static class FetchManager
    {
        public static string currentRunningSignal = "FINE";

        public static void FetchAll_STARTING()
        {
            Booting.diagPrint("OK", "SystemFetcher started!");
            var i = 0;
            foreach (var fetched in FetchService.SYSTEM_CONFIG_BUNDLE)
            {
                Booting.diagPrint("OK", "Fetching " + FetchService.SYSTEM_ABSOLUTE_BUNDLE[i]);
                FetchService.SYSTEM_CONFIG_BUNDLE.ToList()[i] = File.ReadAllText(FetchService.GiveAbsolutePath(fetched));
                if (!(FetchService.GiveAbsolutePath(fetched) == "ERROR"))
                    Booting.diagPrint("FAILED", "Unsuccessful fetching of " + fetched);
                else
                    Booting.diagPrint("OK", "Fetched " + fetched);
                i++;
            }
        }

        public static void FetchRunning()
        {
            if (currentRunningSignal == "FINE")
                return;
        }

    }
}
