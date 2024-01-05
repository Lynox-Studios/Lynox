using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lynox.OSDISTRIBUTION.BLTS
{
    public static class commands
    {

        //commands are declare as name and Action (example: help,() =>{//help code})
        public static Dictionary<string,Action> Commands = new Dictionary<string, Action>() 
        {
            {"help",() => 
            {

                Console.WriteLine("HELP LIST");

            } },
        };

    }
}
