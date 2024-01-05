using Cosmos.HAL;
using Cosmos.System.Graphics;
using Cosmos.System.Graphics.Fonts;
using Lynox.OSDISTRIBUTION;
using Lynox.SEF;
using Lynox.SEF.Additional_Compilers.LUA;
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
        public static DistributionManager distributionManager;

        protected override void BeforeRun()
        {

            SEF.SEF.AddCompiler(new LUA());

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
