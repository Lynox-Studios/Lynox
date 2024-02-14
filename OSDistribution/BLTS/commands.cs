using Lynox.Additions.LUA;
using Lynox.SEF;
using Lynox.SystemManager.ProcessManager;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lynox.OSDistribution.BLTS
{
    public static class commands
    {

        //commands are declare as name and Action (example: help,() =>{//help code})
        public static Dictionary<string, Action<string[]>> Commands = new Dictionary<string, Action<string[]>>() 
        {
            {"help",(args) => 
            {

                Console.WriteLine("HELP LIST");

            } },
            {"lua",(args) =>
            {

                if (File.Exists(args[1]))
                {
                    new LUA().Execute(File.ReadAllText(args[1]));
                }
                else
                {
                    if (File.Exists(Kernel.SystemPath+args[1]))
                    {
                        new LUA().Execute(File.ReadAllText(args[1]));
                    }
                    else
                    {
                        string code = "";
                        for (int i = 1; i < args.Length; i++)
                        {
                            code += args[i]+" ";
                        }
                        new LUA().Execute(code);
                    }
	            }

            } },
            {"cd",(args) =>
            {

                if (Directory.Exists(args[1]))
                {
                    Kernel.SystemPath = args[1];
                }
                else
                {
                    if (Directory.Exists(Kernel.SystemPath+args[1]))
                    {
                        Kernel.SystemPath = Kernel.SystemPath+args[1];
                    }
                    else
                    {
                        Console.WriteLine("Invalid path");
                    }
                }

            } },
            {"mkdir",(args) =>
            {

                Directory.CreateDirectory(Kernel.SystemPath+args[1]);

            } },
            {"ls",(args) =>
            {

                foreach (var item in Directory.GetDirectories(Kernel.SystemPath))
                {
                    Console.Write(item+" ");
	            }
                foreach (var item in Directory.GetFiles(Kernel.SystemPath))
                {
                    Console.Write(item+" ");
                }
                Console.WriteLine();

            } },
        };

    }
}
