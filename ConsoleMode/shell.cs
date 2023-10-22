using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lynox.ConsoleMode
{
    internal class shell
    {
        public static string currentDir = "0:\\home\\";
        public static string shownCurrentDir = "~";
        public static void run(string user)
        {
            currentDir += user;
            while (true)
            {
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
            Console.WriteLine(command);
        }
    }
}
