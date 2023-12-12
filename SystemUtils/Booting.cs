using Cosmos.System.FileSystem.VFS;
using Lynox._TESTING_DISTRO_.ConsoleMode;
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

        public static void Login()
        {
            var attempts = 0;
            string[] users = File.ReadAllText("0:\\system\\user.list").Split('\n');
            string password = "";

            Booting.diagPrint("OK", "Launched console login manager");
            Console.Write("Welcome to ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(SystemData.OSName);
            Console.ResetColor();
            Console.WriteLine("!");
        username:
            Console.Write("Username: ");
            Console.ForegroundColor = ConsoleColor.Green;
            var name = Console.ReadLine();
            Console.ResetColor();
            foreach (var user in users) {
                if (name != user)
                {
                    Console.WriteLine("Invalid username!");
                    goto username;
                }
            }
            password = File.ReadAllText("0:\\system\\" + name + ".password");

        password:
            Console.Write("Password: ");
            Console.ForegroundColor = ConsoleColor.Green;
            var passwd = Console.ReadLine();
            Console.ResetColor();
            if (passwd != password)
            {
                Console.CursorTop--;
                Console.CursorLeft += ("Password: ").Length + passwd.Length;
                Console.CursorLeft -= passwd.Length;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(new String('*', passwd.Length));
                Console.ResetColor();
                Console.WriteLine("Invalid password!");
                goto password;
            }

            Console.CursorTop--;
            Console.CursorLeft += ("Password: ").Length + passwd.Length;
            Console.CursorLeft -= passwd.Length;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(new String('*', passwd.Length));
            Console.ResetColor();
            SystemData.currentUser = name;
        }

        public static void Boot()
        {
            VFSManager.RegisterVFS(SystemData.fs);
            diagPrint("OK", "Filesystem Initialization");

            if (!Directory.Exists(@"0:\tmp"))
            {
                Directory.CreateDirectory(@"0:\tmp");

            }

            pkg.Download("test","1");

            if (!File.Exists("0:\\sys_config.conf"))
            {
                FirstTimeSetup.FreshSetup();
            }
            Console.Clear();
            diagPrint("OK", "Booter");
            diagPrint("OK", "LynoxSystem");
            SystemData.init();

            diagPrint("OK", "System service(s) starting..");
            foreach (var serv in SystemData.procMgr.ServiceNames)
            {
                serv.ServiceStart();
            }

            Login();
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
