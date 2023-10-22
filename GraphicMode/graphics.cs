using Lynox.ConsoleMode;
using Lynox.SystemUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lynox.GraphicMode
{
    internal class graphics
    {
        public static void entry()
        {
            Booting.diagPrint("OK", "Entered Graphical mode");
            Thread.Sleep(500);
        }
    }
}
