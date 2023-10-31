using Lynox.SystemUtils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lynox.Recovery
{
    internal class ConfigRecovery
    {
        public static int startPosX;
        public static int startPosY;
        public static bool optionConsole = true;
        public static void START()
        {

            Console.WriteLine("Please choose your preferred system mode:");
            startPosX = Console.CursorLeft;
            startPosY = Console.CursorTop;
        redraw:
            Console.CursorLeft = startPosX;
            Console.CursorTop = startPosY;
            if (optionConsole)
            {
                Console.BackgroundColor = ConsoleColor.Gray;
                Console.WriteLine(" >> Console ");
                Console.ResetColor();
                Console.WriteLine(" GUI        ");
            } else
            {
                Console.ResetColor();
                Console.WriteLine(" Console    ");
                Console.BackgroundColor = ConsoleColor.Gray;
                Console.WriteLine(" >> GUI     ");
            }

            Console.WriteLine("(Use up/down arrow keys and enter to navigate and select)");
            var getKey = Console.ReadKey();
            switch (getKey.Key)
            {
                case ConsoleKey.Enter:
                    var store = "CONSOLE";
                    switch (optionConsole)
                    {
                        case true:
                            store = "CONSOLE";
                            break;
                        case false:
                            store = "GRAPHICAL";
                            break;
                    }
                    File.WriteAllText("0:\\system\\system_mode.conf", store);
                    Console.WriteLine("Your system may reboot now to apply changes!");
                    Thread.Sleep(2000);
                    Cosmos.System.Power.Reboot();
                    break;
                case ConsoleKey.UpArrow:
                    if (!optionConsole)
                    {
                        optionConsole = true;
                    }
                    goto redraw;
                case ConsoleKey.DownArrow:
                    if (optionConsole)
                    {
                        optionConsole = false;
                    }
                    goto redraw;
                default:
                    break;
            }
        }
    }
}
