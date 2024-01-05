using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lynox.OSDISTRIBUTION.BLTS
{
    public static class shell
    {

        public static string[] command_args;

        public static void Start()
        {

            Console.WriteLine("Welcome to BLTS shell\n" + "you are currently using the version " + info.DISTRO_VERSION + " of the distro " + info.DISTRO_NAME);

        }

        public static void Update()
        {

            Console.Write("%PATH% > ");
            var input = Console.ReadLine().Split(' ');
            if (commands.Commands.ContainsKey(input[0]))
            {

                commands.Commands[input[0]].Invoke(input);

            }
            else
            {
                Console.WriteLine(input[0] +" is an invalid command");
            }

        }

    }
}
