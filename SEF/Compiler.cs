using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lynox.SEF.Additional_Compilers
{
    public class Compiler
    {

        public string COMPILER_NAME = "EXAMPLE";
        public string COMPILER_EXTENSION = ".asm";

        public virtual void Execute(string code)
        {
        }

    }
}
