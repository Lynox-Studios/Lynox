using Lynox.SEF.CPU;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lynox.SystemUtils;
using TestDistro.ConsoleMode.ConsoleUtils;

namespace Lynox.SystemUtils
{
    internal static class SystemCommands
    {
        public static string[] commandNames =
        {
            "?", "h", "help",
            "ls", "lyno", "cd", "rmdir", "mkdir", "rm", "touch", "cat",
            "cl", "clear",
            "pb", "gui", "sef"
        };

        public static void HandleSystemCommandsInConsoleMode(string[] paramArray, string currentDir, string command)
        {
            switch (paramArray[0].ToLower())
            {
                case "?":
                case "h":
                case "help":
                    Console.WriteLine("PAGE 1/1 -----------------------------------------------------\n");
                    Console.WriteLine("help/h/? - shows this menu");
                    Console.WriteLine("ls - shows every file/folder in the current/selected directory");
                    Console.WriteLine("lyno - a simple text editor");
                    Console.WriteLine("cd - goes to a specified directory");
                    Console.WriteLine("mkdir - creates a directory");
                    Console.WriteLine("rmdir - removes a directory");
                    Console.WriteLine("rm - deletes a file");
                    Console.WriteLine("touch - creates a file");
                    Console.WriteLine("cat - reads the content of a file");
                    Console.WriteLine("sef - assembles assembly code");
                    Console.WriteLine("\n--------------------------------------------------------------");

                    break;
                case "ls":
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
                    Console.ForegroundColor = ConsoleColor.Magenta;
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
                    break;
                case "lyno":
                    if (paramArray.Length == 2)
                    {
                        if (File.Exists(currentDir + paramArray[1]))
                        {
                            lyno.lynoStart(File.ReadAllText(currentDir + paramArray[1]), paramArray[1]);

                        }
                        else
                        {
                            File.Create(currentDir + paramArray[1]);
                            lyno.lynoStart(File.ReadAllText(currentDir + paramArray[1]), paramArray[1]);
                        }
                    }
                    else
                    {
                        lyno.lynoStart();
                    }
                    break;
                case "cd":
                    if (paramArray.Length > 1)
                    {
                        if (paramArray[1] == "...")
                        {
                            currentDir = "0:\\";
                        }
                        else if (paramArray[1] == ".." && currentDir.Split('\\').Length > 1)
                        {
                            currentDir = currentDir.TrimEnd(currentDir.Split('\\')[currentDir.Length - 1].ToCharArray());
                        }

                        if (Directory.Exists(command.Replace("cd ", currentDir)))
                        {
                            currentDir += command.Replace("cd ", "") + "\\";
                        }
                        else
                        {
                            Console.WriteLine("-lash: " + command + ": No such file or directory");
                        }
                    }
                    break;
                case "rmdir":
                    try
                    {
                        Directory.Delete(command.Replace("rmdir ", currentDir), true);
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Can't remove the directory.");
                    }
                    break;
                case "mkdir":
                    try
                    {
                        if (!Directory.Exists(command.Replace("mkdir ", currentDir)))
                        {
                            Directory.CreateDirectory(command.Replace("mkdir ", currentDir));
                        }
                        else
                        {
                            Console.WriteLine("ERROR: Can't make directory, (does it already exist?)");
                        }
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("ERROR: Can't make directory, (does it already exist?)");
                    }
                    break;
                case "rm":
                    try
                    {
                        File.Delete(command.Replace("rm ", currentDir));
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("rm", "Can't remove the file. Permission denied");
                    }
                    break;
                case "touch":
                    try
                    {
                        File.Create(command.Replace("touch ", currentDir));
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Can't make a file.");
                    }
                    break;
                case "cl":
                case "clear":
                    Console.Clear();
                    break;
                case "pb":
                    var pb = Booting.Progressbar(5, 10);
                    break;
                case "cat":
                    if (!(paramArray.Length > 1))
                        break;
                    if (!File.Exists(currentDir + paramArray[1]))
                        break;
                    Console.WriteLine(File.ReadAllText(currentDir + paramArray[1]));
                    break;
                case "gui":
                    TestDistro.GraphicMode.graphics.entry();
                    break;
                case "sef":

                    if ((paramArray.Length > 1))
                    {

                        if (paramArray[1].ToLower() == "assemble")
                        {
                            var sefexe = Console.ReadLine();

                            SEF_CPU.Assemble(sefexe);

                        }
                        else if (paramArray[1].ToLower() == "assemblef")
                        {

                            SEF_CPU.Assemble(currentDir + paramArray[2], true);

                        }
                        else if (paramArray[1].ToLower() == "mexe")
                        {

                            SEF_CPU.MakeExecutable(currentDir + paramArray[2], currentDir + paramArray[3]);

                        }
                        else if (paramArray[1].ToLower() == "run")
                        {

                            SEF_CPU.Execute(currentDir + paramArray[2]);

                        }
                        else if (paramArray[1].ToLower() == "showregs")
                        {

                            Console.WriteLine($"AX: {SEF_CPU.Regs.AX}");
                            Console.WriteLine($"BX: {SEF_CPU.Regs.BX}");
                            Console.WriteLine($"CX: {SEF_CPU.Regs.CX}");
                            Console.WriteLine($"DI: {SEF_CPU.Regs.DI}");
                            Console.WriteLine($"SI: {SEF_CPU.Regs.SI}");
                            Console.WriteLine($"SP: {SEF_CPU.Regs.SP}");

                        }

                    }
                    else
                    {
                        Console.WriteLine("SEF V0.1");
                    }
                    break;
                default:

                    if (File.Exists(currentDir + paramArray[0].Replace("./", "")) && paramArray[0].StartsWith("./"))
                    {
                        SEF_CPU.Execute(currentDir + paramArray[0].Replace("./", ""));
                        break;
                    }

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("lash");
                    Console.ResetColor();
                    Console.WriteLine(": Unrecognized command/file.");
                    break;
            }
        }
        public static bool IsSystemCommand(string command)
        {
            foreach (var cmd in commandNames) { if (cmd.ToLower() == command.ToLower()) { return true; } }
            return false;
        }
    }
}
