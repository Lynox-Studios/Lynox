using Cosmos.HAL;
using Lynox.SystemUtils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using TestDistro.ConsoleMode;
using TestDistro.GraphicMode;
using Sys = Cosmos.System;

namespace Lynox
{
    public class Kernel : Sys.Kernel
    {
        
        protected override void BeforeRun() => Booting.Boot();

        protected override void Run()
        {

            if (!File.Exists("0:\\system\\bin_enabled.conf"))
            {
                Booting.diagPrint("FAILED", "Your system has invalid/broken binaries, you will be sent to mode config recovery.");
                SystemUtils.FirstTimeSetup.FreshSetup();
            }
            else if (Directory.GetFiles("0:\\bin").Length != 1)
            {
                Booting.diagPrint("FAILED", "Your system has invalid/broken binaries, you will be sent to mode config recovery.");
                SystemUtils.FirstTimeSetup.FreshSetup();
            }
            if (!File.Exists("0:\\system\\system_mode.conf"))
            {
                Booting.diagPrint("FAILED", "Your system has invalid/broken configs, you will need to select a default boot mode before booting.");
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
                        Console.WriteLine("All done");
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
            
            switch (File.ReadAllText("0:\\system\\system_mode.conf")) {
                case "CONSOLE":
                    TestDistro.ConsoleMode.console.entry();
                    break;
                case "GRAPHICAL":
                    TestDistro.GraphicMode.graphics.entry();
                    break;
                default:
                    Booting.diagPrint("FAILED", "Your system has invalid/broken configs, you will be sent to mode config recovery.");
                    Recovery.ConfigRecovery.START();
                    break;
            }
        }
    }
}
