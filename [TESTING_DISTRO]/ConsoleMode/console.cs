using Lynox.SystemUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lynox;

namespace TestDistro.ConsoleMode
{
    internal class console
    {
        public static void entry()
        {
            Booting.diagPrint("OK", "Entered console mode!");
            var user = loginmgr.login();

            shell.run(user);
        }
    }
}
