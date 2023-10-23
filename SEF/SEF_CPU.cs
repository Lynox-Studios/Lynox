using Lynox.SEF.UTILS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lynox.SEF.CPU
{
    internal class SEF_CPU
    {
        public SEF_CPU() { }
        //registers
        //16-bit registers for now
        public static class Regs
        {

            public static decimal AX, CX,BX,SP,BP,SI,DI;

        }

        //test of assemblying, it just parses the code as keys, in the future it will convert the code into byte code
        public static void Assemble(string code)
        {

            string[] splittedcode = code.Split('\n');

            foreach (var item in splittedcode)
            {

                string[] args = item.Split(' ',',');

                switch (args[0])
                {
                    case "ADD":

                        decimal Addto = 0;

                        switch (args[2])
                        {
                            case "AX":
                                Addto = Regs.AX;
                                break;
                            case "CX":
                                Addto = Regs.CX;
                                break;
                            case "BX":
                                Addto = Regs.BX;
                                break;
                            case "SP":
                                Addto = Regs.SP;
                                break;
                            case "BP":
                                Addto = Regs.BP;
                                break;
                            case "SI":
                                Addto = Regs.SI;
                                break;
                            case "DI":
                                Addto = Regs.DI;
                                break;
                            default:

                                if (decimal.TryParse(args[2], out Addto))
                                { }
                                else
                                {
                                    Console.WriteLine($"{args[2].ToUpper()} is not a recognized register");
                                }

                                break;
                        }

                        switch (args[1].ToUpper())
                        {
                            case "AX":
                                Regs.AX += Addto;
                                break;
                            case "CX":
                                Regs.CX += Addto;
                                break;
                            case "BX":
                                Regs.BX += Addto;
                                break;
                            case "SP":
                                Regs.SP += Addto;
                                break;
                            case "BP":
                                Regs.BP += Addto;
                                break;
                            case "SI":
                                Regs.SI += Addto;
                                break;
                            case "DI":
                                Regs.DI += Addto;
                                break;
                            default:
                                Console.WriteLine($"{args[1].ToUpper()} is not a recognized register");
                                break;
                        }

                        break;
                    case "CALL":
                        break;
                    case "AAA":
                        break;
                    case "AAD":
                        break;
                    case "AAM":
                        break;
                    case "AAS":
                        break;
                    case "ADC":
                        break;
                    case "AND":
                        break;
                    case "CBW":
                        break;
                    case "CLC":
                        break;
                    case "CLD":
                        break;
                    case "CLI":
                        break;
                    case "CMC":
                        break;
                    case "CMPSB":
                        break;
                    case "CMPSW":
                        break;
                    case "CWD":
                        break;
                    case "DAA":
                        break;
                    case "DAS":
                        break;
                    case "DEC":
                        break;
                    case "DIV":
                        break;
                    case "ESC":
                        break;
                    case "HLT":
                        break;
                    case "IDIV":
                        break;
                    case "IMULT":
                        break;
                    case "IN":
                        break;
                    case "INC":
                        break;
                    case "INT":
                        break;
                    case "INTO":
                        break;
                    case "IRET":
                        break;
                    case "Jcc":
                        break;
                    case "JCXZ":
                        break;
                    case "JMP":
                        break;
                    case "LAHF":
                        break;
                    case "LDS":
                        break;
                    case "LEA":
                        break;
                    case "LES":
                        break;
                    case "LOCK":
                        break;
                    case "LODSB":
                        break;
                    case "LODSW":
                        break;
                    case "LOOP":
                        break;
                    case "LOOPx":
                        break;
                    case "MOV":
                        break;
                    case "MOVSB":
                        break;
                    case "MOVSW":
                        break;
                    case "MUL":
                        break;
                    case "NEG":
                        break;
                    case "NOP":
                        break;
                    case "NOT":
                        break;
                    case "OR":
                        break;
                    case "OUT":
                        break;
                    case "POP":
                        break;
                    case "PUSH":
                        break;
                    case "PUSHF":
                        break;
                    case "RCL":
                        break;
                    case "RCR":
                        break;
                    case "REPxx":
                        break;
                    case "RET":
                        break;
                    case "RETN":
                        break;
                    case "RETF":
                        break;
                    case "ROL":
                        break;
                    case "ROR":
                        break;
                    case "SAHF":
                        break;
                    case "SAL":
                        break;
                    case "SAR":
                        break;
                    case "SBB":
                        break;
                    case "SCASB":
                        break;
                    case "SCASW":
                        break;
                    case "SHL":
                        break;
                    case "SHR":
                        break;
                    case "STC":
                        break;
                    case "STD":
                        break;
                    case "STI":
                        break;
                    case "STOSB":
                        break;
                    case "STOSW":
                        break;
                    case "SUB":

                        decimal Subto = 0;

                        switch (args[2])
                        {
                            case "AX":
                                Subto = Regs.AX;
                                break;
                            case "CX":
                                Subto = Regs.CX;
                                break;
                            case "BX":
                                Subto = Regs.BX;
                                break;
                            case "SP":
                                Subto = Regs.SP;
                                break;
                            case "BP":
                                Subto = Regs.BP;
                                break;
                            case "SI":
                                Subto = Regs.SI;
                                break;
                            case "DI":
                                Subto = Regs.DI;
                                break;
                            default:

                                if (decimal.TryParse(args[2], out Subto))
                                { }
                                else
                                {
                                    Console.WriteLine($"{args[2].ToUpper()} is not a recognized register");
                                }

                                break;
                        }

                        switch (args[1].ToUpper())
                        {
                            case "AX":
                                Regs.AX -= Subto;
                                break;
                            case "CX":
                                Regs.CX -= Subto;
                                break;
                            case "BX":
                                Regs.BX -= Subto;
                                break;
                            case "SP":
                                Regs.SP -= Subto;
                                break;
                            case "BP":
                                Regs.BP -= Subto;
                                break;
                            case "SI":
                                Regs.SI -= Subto;
                                break;
                            case "DI":
                                Regs.DI -= Subto;
                                break;
                            default:
                                Console.WriteLine($"{args[1].ToUpper()} is not a recognized register");
                                break;
                        }

                        break;
                    case "TEST":
                        break;
                    case "WAIT":
                        break;
                    case "XCHG":
                        break;
                    case "ALAT":
                        break;
                    case "XOR":
                        break;
                    default:
                        break;
                }

            }

        }

    }
}
