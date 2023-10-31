using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Threading.Channels;
using Lynox;

namespace TestDistro.ConsoleMode.ConsoleUtils
{
    public static class lyno
    {
        public static string oldBuffer = "";
        public static string buffer = "";
        public static string fileName = "Untitled";

        public static Dictionary<string, string> toolBox = new Dictionary<string, string>();
        public static Dictionary<int, int> lineEnds = new Dictionary<int, int>();

        public static int prevPosX = 0;
        public static int prevPosY = 1;

        public const string version = "v0.2";

        public static void lynoStart(string textFromFile, string filename)
        {
            buffer = textFromFile;
            oldBuffer = buffer;
            fileName = filename;
            ToolboxInit();
            run();
            Console.ResetColor();
            Console.Clear();
            return;
        }

        public static void lynoStart()
        {
            ToolboxInit();
            run();
            Console.Clear();
            return;
        }

        public static void ToolboxInit()
        {
            toolBox.Add("^X", "Exit        ");
            toolBox.Add("^S", "Save        ");
        }

        public static void run()
        {
        goBackToLoop:
            var posX = prevPosX;
            var posY = prevPosY;
            var saved = false;
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.DarkYellow;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("  Lyno " + version + new string(' ', Console.WindowWidth - 1 - (("  Lyno" + version).Length + fileName.Length + " ".Length)) + fileName + " ");
            Console.ResetColor();
            Console.CursorLeft = 0;
            Console.CursorTop = Console.WindowHeight - 1;
            foreach (var item in toolBox)
            {
                Console.BackgroundColor = ConsoleColor.DarkYellow;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write(item.Key);
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write(" " + item.Value + " ");
            }

            Console.ResetColor();
            Console.CursorLeft = 0;
            Console.CursorTop = 1;

            foreach (var charb in buffer)
            {
                if (charb == '\n')
                {
                    lineEnds.Add(posY, posX);
                    posY++;
                    posX = 0;
                }
                else
                {
                    if (posX > Console.WindowWidth)
                    {
                        posY++;
                        posX = 0;
                    }
                    else
                    {
                        posX++;
                    }
                    Console.Write(charb);
                }
                Console.CursorLeft = posX;
                Console.CursorTop = posY;
            }

            var key = Console.ReadKey();
            var close = true;
            while (close)
            {
                if (key.Key == ConsoleKey.Enter)
                {
                    posY++;
                    if (!lineEnds.ContainsKey(posY - 1))
                    {
                        lineEnds.Add(posY - 1, posX);
                    }
                    posX = 0;
                    buffer += "\n";
                }
                else if (key.Key == ConsoleKey.Backspace)
                {
                    if (posX > 0)
                    {
                        Console.CursorLeft--;
                        Console.Write(' ');
                        posX--;
                        buffer = buffer.Remove(buffer.Length - 1, 1);
                    }
                    else
                    {
                        posX = 0;
                        if (posY > 1)
                        {
                            posY--;
                            posX = lineEnds[posY];
                            lineEnds.Remove(posY);
                        }
                    }
                }
                else if (key.Key == ConsoleKey.Tab)
                {
                    Console.Write("    ");
                    buffer += "    ";
                    posX += 4;
                }
                else
                {
                    posX++;
                    buffer += key.KeyChar;
                }

                if (key.Modifiers == ConsoleModifiers.Control && key.Key == ConsoleKey.S)
                {
                    saved = true;
                    if (fileName != "Untitled")
                    {
                        File.WriteAllText(shell.currentDir + (fileName.TrimEnd('*')), buffer.Remove(buffer.Length - 1, 1));
                    }
                    else
                    {
                        Console.Clear();
                        Console.Write("Enter filename (with extension): ");
                        fileName = Console.ReadLine();
                        File.WriteAllText(shell.currentDir + fileName, buffer.Remove(buffer.Length - 1, 1));
                        goto goBackToLoop;
                    }
                }
                else
                {
                    saved = false;
                }

                if (key.Modifiers == ConsoleModifiers.Control)
                {
                    if (key.Key == ConsoleKey.X)
                    {
                        if (!saved)
                        {
                            if (fileName.EndsWith('*'))
                                fileName = fileName.TrimEnd('*');
                            Console.Clear();
                            Console.Write("Do you want to save your changes? (y/n/c): ");
                            var keyYN = Console.ReadKey();
                            while (!(keyYN.Key == ConsoleKey.Y || keyYN.Key == ConsoleKey.N || keyYN.Key == ConsoleKey.C))
                            {
                                Console.CursorLeft--;
                                Console.Write(' ');
                                Console.CursorLeft--;
                                keyYN = Console.ReadKey();
                            }
                            if (keyYN.Key == ConsoleKey.Y)
                            {
                                if (fileName != "Untitled")
                                {
                                    File.WriteAllText(shell.currentDir + (fileName.TrimEnd('*')), buffer.Remove(buffer.Length - 1, 1));
                                }
                                else
                                {
                                    Console.Write("Enter filename (with extension): ");
                                    var name = Console.ReadLine();
                                    File.WriteAllText(shell.currentDir + name, buffer.Remove(buffer.Length - 1, 1));
                                }
                                return;
                            }
                            else if (keyYN.Key == ConsoleKey.N)
                            {
                                return;
                            }
                            else
                            {
                                prevPosX = posX - 1;
                                prevPosY = posY;
                                goto goBackToLoop;
                            }
                        }
                    }
                }

                if (!saved && !fileName.EndsWith('*'))
                {
                    fileName += "*";
                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.DarkYellow;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write("  Lyno " + version + new string(' ', Console.WindowWidth - 1 - (("  Lyno" + version).Length + fileName.Length + " ".Length)) + fileName + " ");
                    Console.ResetColor();
                    Console.Write(buffer);

                    Console.CursorLeft = 0;
                    Console.CursorTop = Console.WindowHeight - 1;
                    foreach (var item in toolBox)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkYellow;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write(item.Key);
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.Write(" " + item.Value + " ");
                    }
                    Console.ResetColor();
                }
                else if (saved && fileName.EndsWith('*'))
                {
                    fileName = fileName.TrimEnd('*');
                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.DarkYellow;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write("  Lyno " + version + new string(' ', Console.WindowWidth - 1 - (("  Lyno" + version).Length + fileName.Length + " ".Length)) + fileName + " ");
                    Console.ResetColor();
                    Console.Write(buffer);

                    Console.CursorLeft = 0;
                    Console.CursorTop = Console.WindowHeight - 1;
                    foreach (var item in toolBox)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkYellow;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write(item.Key);
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.Write(" " + item.Value + " ");
                    }
                    Console.ResetColor();
                }
                Console.CursorLeft = posX;
                Console.CursorTop = posY;
                key = Console.ReadKey();
            }
        }

    }
}