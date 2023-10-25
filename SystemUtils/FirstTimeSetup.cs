using cs = Cosmos.System;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lynox.SystemUtils
{
    internal static class FirstTimeSetup
    {
        public static void FreshSetup()
        {
            Console.Clear();
            Console.Write("Welcome to ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(SystemData.OSName);
            Console.ResetColor();
            Console.WriteLine("!");
            retry_user:
            Console.Write("Username: ");
            var username = Console.ReadLine();
            if (username == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("NULL USERNAME!");
                Console.ForegroundColor = ConsoleColor.White;
                goto retry_user;
            }
            retry:
            Console.Write("Password: ");
            var password = Console.ReadLine();
            Console.Write("Repeat your password: ");
            var checkPasswd = Console.ReadLine();
            if (checkPasswd != password || password == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Incorrect password/Null password, try again!");
                Console.ForegroundColor = ConsoleColor.White;
                goto retry;
            }

            Console.Clear();
            try
            {
                Directory.CreateDirectory("0:\\system");
                Booting.diagPrint("OK", "Generating system folder.");
            } catch (Exception)
            {
                Booting.diagPrint("FAILED", "Generating system folder.");
            }
            try
            {
                File.WriteAllText("0:\\system\\user.conf", username);
                Booting.diagPrint("OK", "Generating user configs. [1/2]");
                File.WriteAllText("0:\\system\\passwd.conf", password);
                Booting.diagPrint("OK", "Generating user configs. [2/2]");
            }
            catch (Exception)
            {
                Booting.diagPrint("FAILED", "Generating user configs.");
            }
            try
            {
                File.Create("0:\\sys_config.conf");
                Booting.diagPrint("OK", "System configs generated!");
            }
            catch (Exception)
            {
                Booting.diagPrint("FAILED", "Creating system config.");
            }

            try
            {
                File.Create("0:\\system\\system_mode.conf");
                Booting.diagPrint("OK", "System mode config generated!");
            }
            catch (Exception)
            {
                Booting.diagPrint("FAILED", "System mode config failed to generate.");
            }

            try
            {
                Booting.diagPrint("OK", "Creating user directories. [1/2]");
                Directory.CreateDirectory("0:\\home\\");
                Booting.diagPrint("OK", "Creating user directories. [2/2]");
                Directory.CreateDirectory("0:\\home\\" + username);
            }
            catch (Exception)
            {
                Booting.diagPrint("FAILED", "System cannot make user directories! [WARNING: This may break the system.]");
            }

            try
            {
                Booting.diagPrint("OK", "Creating bin directory. [1/3]");
                Directory.CreateDirectory("0:\\bin\\");
                Booting.diagPrint("OK", "Copyng binaries. [2/3]");
                File.WriteAllText("0:\\bin\\", "");
                Booting.diagPrint("OK", "Settings links for bin directory. [3/3]");
                File.WriteAllText("0:\\system\\bin_enabled.conf", "ENABLED");
            }
            catch (Exception)
            {
                Booting.diagPrint("FAILED", "System cannot generate bin directories. [WARNING: This will break the system.]");
            }
            cs.Power.Reboot();
        }
    }
}
