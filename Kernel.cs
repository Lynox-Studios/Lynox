using Cosmos.HAL;
using Cosmos.System.FileSystem;
using Cosmos.System.FileSystem.VFS;
using Cosmos.System.Graphics;
using Cosmos.System.Graphics.Fonts;
using Lynox.OSDISTRIBUTION;
using Lynox.SEF;
using System;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading;
using Sys = Cosmos.System;

namespace Lynox
{
    public class Kernel : Sys.Kernel
    {
        private int startPosX;
        private int startPosY;
        private bool optionConsole = true;
        public static string SYSTEM_PATH = @"0:\";
        public static DistributionManager distributionManager;
        CosmosVFS vfs;

        protected override void BeforeRun()
        {

            vfs = new CosmosVFS();
            VFSManager.RegisterVFS(vfs);

            distributionManager = new DistributionManager();
            distributionManager.Start();
        }

        protected override void Run()
        {
            distributionManager.Update();
        }

        protected override void AfterRun()
        {
            var crash = FullScreenCanvas.GetCurrentFullScreenCanvas();
            crash.Clear(Color.Blue);
            crash.DrawString(info.DISTRO_NAME + " has crashed\n\n restarting in 10 seconds",PCScreenFont.Default,Color.White,10,10);
            crash.Display();
            Thread.Sleep(10000);
            Cosmos.System.Power.Reboot();
        }

    }
}
