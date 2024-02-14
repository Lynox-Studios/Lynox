using Cosmos.System.FileSystem;
using Cosmos.System.FileSystem.VFS;
using Lynox.OSDISTRIBUTION;
using System;
using System.Threading;

namespace Lynox
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public class Kernel : Cosmos.System.Kernel
    {
        public static string SystemPath = @"0:\";
        private static DistributionManager _distributionManager;
        private static CosmosVFS _fileSystem;

        protected override void BeforeRun()
        {

            _fileSystem = new CosmosVFS();
            VFSManager.RegisterVFS(_fileSystem);

            _distributionManager = new DistributionManager();
            _distributionManager.Start();
        }

        protected override void Run()
        {
            _distributionManager.Update();
        }

        protected override void AfterRun()
        {
            // this is a case of crashing, as per your distribution setup,
            // you may let the code be (if you want console crash screen) or comment the current code
            // and uncomment the GUI code to satisfy your distro's needs.
            // OR BE A MANIAC AND WRITE YOUR OWN CRASH MESSAGE

            Console.BackgroundColor = ConsoleColor.Blue;
            Console.Clear();
            Console.WriteLine("LYNOX KERNEL FAULT HAS OCCURRED. SYSTEM WILL RESTART IN 10 SECONDS.");
            Console.WriteLine("ERROR: Crashed run function");
            Thread.Sleep(10000);
            Cosmos.System.Power.Reboot();

            // var crash = FullScreenCanvas.GetCurrentFullScreenCanvas();
            // crash.Clear(Color.Blue);
            // crash.DrawString(info.DISTRO_NAME + " has crashed\n\n restarting in 10 seconds",PCScreenFont.Default,Color.White,10,10);
            // crash.Display();
            // Thread.Sleep(10000);
            // Cosmos.System.Power.Reboot();
        }

    }
}
