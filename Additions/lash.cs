using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lynox.Additions
{
    public class lash
    {
        public static string currentDir = SystemData.CurrentDrive;

        public static void runLash()
        {
            if (!File.Exists(SystemData.CurrentDrive + "config\\lash_profile"))
            {
                generateLashConfig();
            }
            var lashProfile = File.ReadAllText(SystemData.CurrentDrive + "config\\lash_profile");
            var lashStartup = File.ReadAllText(SystemData.CurrentDrive + "config\\lash_rc");
            while (true)
            {
                Console.Write(lashProfile.Replace("$USER", SystemData.currentUser).Replace("$CURRENT", currentDir));
                var command = "";
                var key = Console.ReadKey();
                while (key.Key != ConsoleKey.Enter)
                {
                    if (key.Key == ConsoleKey.Tab)
                    {
                        // autocomplete will come soon
                    } else
                    {
                        command += key.KeyChar;
                    }
                    key = Console.ReadKey();
                }
                currentDir = runLashCommand(command, currentDir);
            }
        }

        public static string runLashCommand(string command, string currentDir)
        {
            if (command.StartsWith("ls"))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                foreach (var dirs in Directory.GetDirectories(currentDir))
                {
                    if (dirs.Contains(" "))
                    {
                        Console.Write("\"" + dirs + "\" ");
                    }
                    else
                    {
                        Console.Write(dirs + " ");
                    }
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                Console.ForegroundColor = ConsoleColor.Yellow;
                foreach (var files in Directory.GetFiles(currentDir))
                {
                    if (files.Contains(" "))
                    {
                        Console.Write("\"" + files + "\" ");
                    }
                    else
                    {
                        Console.Write(files + " ");
                    }
                }
                Console.Write('\n');
            }

            return currentDir;
        }

        public static void generateLashConfig()
        {
            Directory.CreateDirectory(SystemData.CurrentDrive + "config");
            File.WriteAllText(SystemData.CurrentDrive + "config\\lash_profile", "($CURRENT) [$USER@lynox] $ ");
            File.WriteAllText(SystemData.CurrentDrive + "config\\lash_rc", "echo Lash started!");
        }
    }
}
