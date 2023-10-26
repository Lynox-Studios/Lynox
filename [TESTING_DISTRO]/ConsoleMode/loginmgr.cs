using Lynox.SystemUtils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lynox;

namespace TestDistro.ConsoleMode
{
    internal class loginmgr
    {
        public static string login()
        {
            var rUsername = File.ReadAllText("0:\\system\\user.conf"); //real Username
            var rPassword = File.ReadAllText("0:\\system\\passwd.conf"); //real Password

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
            if (name != rUsername)
            {
                Console.WriteLine("Invalid username!");
                goto username;
            }

            password:
            Console.Write("Password: ");
            Console.ForegroundColor = ConsoleColor.Green;
            var passwd = Console.ReadLine();
            Console.ResetColor();
            if (passwd != rPassword)
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

            return name;
        }
    }
}
