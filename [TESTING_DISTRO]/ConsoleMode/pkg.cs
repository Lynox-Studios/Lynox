using Lynox.net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDistro.ConsoleMode;

namespace Lynox._TESTING_DISTRO_.ConsoleMode
{
    internal class pkg
    {

        static Dictionary<string, Tuple<string, string>> Parse(string List)
        {

            Dictionary<string, Tuple<string, string>> tmp = new();
            string[] lines = List.Split('\n');
            foreach (var line in lines)
            {

                string[] keys = line.Split(':');
                tmp.Add(keys[0], new(keys[1],keys[2]));

            }
            return tmp;

        }

        public static bool Request(string PakageName)
        {

            var client = NET.CreateClient();
            var parse = Parse(client.GET("http://raw.githubusercontent.com/Lynox-Studios/PakageManager/main/HOLDER.list", 80));
            if (parse.ContainsKey(PakageName))
            {

                Console.WriteLine($"Pakage Found:\n name: {PakageName} version:{parse[PakageName].Item2}");
                return true;

            }
            Console.WriteLine($"no Pakages found with name: {PakageName}");
            return false;

        }
        public static void Download(string PakageName,string Version)
        {

            var client = NET.CreateClient();
            var parse = Parse(client.GET("http://raw.githubusercontent.com/Lynox-Studios/PakageManager/main/HOLDER.list", 80));
            if (parse.ContainsKey(PakageName))
            {

                try
                {
                    Console.WriteLine($"Downloading {PakageName}");
                    File.WriteAllText($@"0:\tmp\{PakageName}", client.GET(parse[PakageName].Item1, 80));
                }
                catch (Exception ex)
                {

                    Console.WriteLine($"error while downloading {ex.Message}");
                }

            }
            Console.WriteLine($"no Pakages found with name: {PakageName}");

        }

    }
}
