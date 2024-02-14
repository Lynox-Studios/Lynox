using Lynox.SEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lynox.SEF
{
    public static class SEF
    {

        static Dictionary<string,Compiler> compilers = new Dictionary<string,Compiler>();

        public static void ExecuteInline(string compiler,string code)
        {

            compilers[compiler].Execute(code);

        }
        public static void AddCompiler(Compiler compiler)
        {

            compilers.Add(compiler.COMPILER_NAME,compiler);

        }

    }
}
