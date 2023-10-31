using Cosmos.HAL;
using TestDistro.ConsoleMode.ConsoleUtils;
using Lynox.SEF.CPU;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using static Cosmos.HAL.BlockDevice.ATA_PIO;
using Lynox;
using TestDistro.GraphicMode;
using Lynox.SystemUtils;

namespace TestDistro.ConsoleMode
{
    internal class shell
    {

        //todelete
        public static ProgressBar pb;
        //end todelete
        public static string currentDir = "0:\\home\\";
        public static string shownCurrentDir = "~";

        public static void currentDirUpdater(string user)
        {
            if (currentDir.StartsWith("0:\\home\\" + user))
            {
                shownCurrentDir = currentDir.Replace("0:\\home\\" + user, "~");
            }
            else
            {
                shownCurrentDir = currentDir;
            }
        }

        public static void run(string user)
        {
            currentDir += user + "\\";
            while (true)
            {
                currentDirUpdater(user);
                Console.Write("[" + user + "@" + SystemData.OSName + " " + shownCurrentDir + "]$ ");
                var command = "";

                var prevKeyChar = '0';
                var key = Console.ReadKey();
                while (key.Key != ConsoleKey.Enter)
                {
                    if (key.Key == ConsoleKey.Backspace)
                    {
                        if (command.Length > 0)
                        {
                            Console.CursorLeft--;
                            Console.Write(' ');
                            Console.CursorLeft--;
                            command = command.Remove(command.Length - 1, 1);
                        }
                        else
                        {
                            Console.CursorLeft++;
                            Console.CursorLeft--;
                        }
                    }
                    else if (key.Key == ConsoleKey.Tab)
                    {
                        //change soon
                        command += "    ";
                        Console.Write("    ");
                    }
                    else
                    {
                        command += key.KeyChar;
                    }
                    prevKeyChar = key.KeyChar;
                    key = Console.ReadKey();
                }
                Console.Write('\n');
                exec(command);
            }
        }

        public static void exec(string command)
        {
            var paramArray = command.Split(' ');
            if (command == null || command == "" || command == " " || paramArray.Length <= 0)
                return;
            
            //please don't modify this, it's for basic access
            if (SystemCommands.IsSystemCommand(command)) { SystemCommands.HandleSystemCommandsInConsoleMode(paramArray, currentDir, command); }

            // for distro creators, use this space with the command variable to make your commands on the shell!


            //leave this below code alone
            Console.ResetColor();
        }
    }
}