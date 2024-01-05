using Cosmos.HAL;
using Lynox.OSDISTRIBUTION;
using System;
using System.IO;
using System.Text;
using Sys = Cosmos.System;

namespace Lynox
{
    public class Kernel : Sys.Kernel
    {
        private int startPosX;
        private int startPosY;
        private bool optionConsole = true;
        public static DistributionManager distributionManager;

        protected override void BeforeRun()
        {
            distributionManager = new DistributionManager();
            distributionManager.Start();
        }

        protected override void Run()
        {
            distributionManager.Update();
        }
    }
}
