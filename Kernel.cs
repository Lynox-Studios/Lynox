using Cosmos.HAL;
using Lynox.SystemUtils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Sys = Cosmos.System;

namespace Lynox
{
    public class Kernel : Sys.Kernel
    {
        protected override void BeforeRun() => Booting.Boot();

        protected override void Run()
        {

            if (!Directory.Exists("0:\\bin"))
            {
                Booting.diagPrint("FAILED", "Your system has invalid/broken binaries, you will be sent to mode config recovery.");
                Recovery.ConfigRecovery.START();
            }

            if (!File.Exists("0:\\system\\system_mode.conf"))
            {
                Booting.diagPrint("FAILED", "Your system has invalid/broken configs, you will be sent to mode config recovery.");
                Recovery.ConfigRecovery.START();
            }
            switch (File.ReadAllText("0:\\system\\system_mode.conf")) {
                case "CONSOLE":
                    ConsoleMode.console.entry();
                    break;
                case "GRAPHICAL":
                    GraphicMode.graphics.entry();
                    break;
                default:
                    Booting.diagPrint("FAILED", "Your system has invalid/broken configs, you will be sent to mode config recovery.");
                    Recovery.ConfigRecovery.START();
                    break;
            }
        }
    }
}
