using Lynox.SystemUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lynox.LynoxAPI.LynoxACPI
{
    internal static class Power
    {
        public static void Shutdown()
        {
            //add stuff to turn gui off
            Console.Clear();
            var i = 1;
            foreach (var proc in SystemData.procMgr.ProcessNames)
            {
                Booting.diagPrint("OK", "Closing " + proc + " [" + i + "/" + SystemData.procMgr.ProcessNames.Count + "]");
                SystemData.procMgr.ProcessNames.Remove(proc);
                i++;
            }
            Booting.diagPrint("OK", "Closed all processes! Powering off.");
            Power.Shutdown();
        }
    }
}
