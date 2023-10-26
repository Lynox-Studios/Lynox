using Cosmos.System.FileSystem.VFS;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lynox.SystemUtils
{
    public static class Booting
    {

        public static void Boot()
        {
            VFSManager.RegisterVFS(SystemData.fs);
            diagPrint("OK", "Filesystem Initialization");
            if (!File.Exists("0:\\sys_config.conf"))
            {
                FirstTimeSetup.FreshSetup();
            }
            Console.Clear();
            diagPrint("OK", "Booter");
            diagPrint("OK", "LynoxSystem");
            SystemData.init();
        }

        public static void diagPrint(string status,  string proc)
        {
            Console.Write("[");
            if (status == "OK")
            {
                Console.Write("   ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(status);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("   ]");
            } else if (status == "FAILED")
            {
                Console.Write(" ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(status);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(" ]");
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" " + proc);
        }

        public static ProgressBar Progressbar(int percentage,int max)
        {

            var a = new ProgressBar() { max = max, percentage = percentage};

            a.Init(Console.GetCursorPosition().Left, Console.GetCursorPosition().Top);

            return a;

        }

    } 

}
