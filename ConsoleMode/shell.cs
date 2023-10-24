﻿using Lynox.ConsoleMode.ConsoleUtils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Cosmos.HAL.BlockDevice.ATA_PIO;

namespace Lynox.ConsoleMode
{
    internal class shell
    {
        public static string currentDir = "0:\\home\\";
        public static string shownCurrentDir = "~";

        public static void currentDirUpdater(string user)
        {
            if (currentDir.StartsWith("0:\\home\\" + user))
            {
                shownCurrentDir = currentDir.Replace("0:\\home\\" + user, "~");
            } else
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
                Console.Write("[" + user + "@Lynox " + shownCurrentDir + "]$ ");
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
                        } else
                        {
                            Console.CursorLeft++;
                            Console.CursorLeft--;
                        }
                    } else if (key.Key == ConsoleKey.Tab)
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
            if (command == null || command == "" || command == " " || command.Split(' ').Length <= 0)
                return;

            switch (command.Split(' ')[0])
            {
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
                    if (command.Split(' ').Length == 2)
                    {
                        if (File.Exists(currentDir + command.Split(' ')[1]))
                        {
                            lyno.lynoStart(File.ReadAllText(currentDir + command.Split(' ')[1]), command.Split(' ')[1]);
                        } else
                        {
                            File.Create(currentDir + command.Split(' ')[1]);
                            lyno.lynoStart(File.ReadAllText(currentDir + command.Split(' ')[1]), command.Split(' ')[1]);
                        }
                    } else
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
                        } else if (paramArray[1] == ".." && currentDir.Split('\\').Length > 1)
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
                case "cat":
                    if (!(command.Split(' ').Length > 1))
                        break;
                    Console.WriteLine(File.ReadAllText(currentDir + command.Split(' ')[1]));
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("lash");
                    Console.ResetColor();
                    Console.WriteLine(": Unrecognized command/file.");
                    break;
            }
            Console.ResetColor();
        }
    }
}
