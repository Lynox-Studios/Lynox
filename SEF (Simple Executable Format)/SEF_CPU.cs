using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lynox.SEF__Simple_Executable_Format_
{
    internal class SEF_CPU
    {
        public SEF_CPU() { }

        public enum InstructionSet
        {
            CONSOLE_OUTPUT = 1,
            CONSOLE_INPUT = 2,
            CONSOLE_CHANGECOLOR__FORE = 3,
            CONSOLE_CHANGECOLOR__BACK = 4,

            STANDARD_AUDIO_BEEP = 5,
            
            EXIT_EXECUTION = 0,
            SKIP
        }

        public static string INPUT = "_";

        public struct Instruction
        {
            public Instruction(InstructionSet inS, string val)
            {
                currentInstruction = inS;
                value = val;
            }
            public InstructionSet currentInstruction;
            public string value;
        }

        public void Apply(Instruction instruction)
        {
            switch (instruction.currentInstruction)
            {
                case InstructionSet.CONSOLE_OUTPUT:
                    Console.Write(instruction.value.Replace("\\n", "\n").Replace("$(RECIEVED_INPUT)", INPUT) + " ");
                    break;
                case InstructionSet.CONSOLE_INPUT:
                    INPUT = Console.ReadLine();
                    break;
                default:
                    break;
            }
        }

        public static InstructionSet ConvertStringToInstruction(string _instruction_)
        {
            switch (_instruction_)
            {
                case "STD_OUT":
                    return InstructionSet.CONSOLE_OUTPUT;
                case "STD_INP":
                    return InstructionSet.CONSOLE_INPUT;
                case "CH_FORE_C":
                    return InstructionSet.CONSOLE_CHANGECOLOR__FORE;
                case "CH_BACK_C":
                    return InstructionSet.CONSOLE_CHANGECOLOR__BACK;
                case "STD_BEEP":
                    return InstructionSet.STANDARD_AUDIO_BEEP;
                case "EXIT":
                    return InstructionSet.EXIT_EXECUTION;
                default:
                    return InstructionSet.SKIP;
            }
        }
    }
}
