using Cosmos.Core.Memory;
using Cosmos.HAL;
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
        public static int cyclesAfterLastHeapCollect = 0;
        public const int framesRequiredToHeapCollect = 15;

        protected override void BeforeRun()
        {

        }

        protected override void Run()
        {

        }
    }
}
