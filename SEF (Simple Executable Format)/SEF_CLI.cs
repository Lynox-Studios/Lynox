using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lynox.SEF__Simple_Executable_Format_
{
    internal static class SEF_CLI
    {
        public static void RunSEF(string code)
        {
            SEF_CPU vCPU = new();
            foreach (var line in code.Split('\n'))
            {
                var newInstruction = new SEF_CPU.Instruction(SEF_CPU.ConvertStringToInstruction(line.Split(' ')[0]), line.Split(' ')[1]);
                vCPU.Apply(newInstruction);
            }
        }
    }
}
