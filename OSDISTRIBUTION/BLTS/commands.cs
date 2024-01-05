using Lynox.SEF;
using Lynox.SYSTEMMANAGER.PROCESSMANAGER;
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
        public static Dictionary<string, Action<string[]>> Commands = new Dictionary<string, Action<string[]>>() 
        {
            {"help",(args) => 
            {

                Console.WriteLine("HELP LIST");

            } },
            {"sef",(args) =>
            {

                string code = "";
                for (int i = 2; i < args.Length; i++)
                {
                    code += args[i]+" ";
			    }
                SEF.SEF.ExecuteInline(args[1],code);

            } },
        };

    }
}
