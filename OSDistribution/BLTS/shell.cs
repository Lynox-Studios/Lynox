using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lynox.OSDistribution.BLTS
{
    public static class shell
    {

        public static string[] command_args;

        public static void Start()
        {

            Console.WriteLine("Welcome to BLTS shell\n" + "You are currently using the version " + Info.DISTRO_VERSION + " of the distro " + Info.DISTRO_NAME);

        }

        public static void Update()
        {

            Console.Write(Kernel.SystemPath+" > ");
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
