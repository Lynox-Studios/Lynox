using Cosmos.HAL;
using Cosmos.System.Graphics;
using TestDistro.GraphicMode;
using Lynox.SEF.UTILS;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDistro;

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

        static bool IsFuction = false;
        static string FuncName = "";

        public static Dictionary<string, string> funcKeys = new Dictionary<string, string>();

        //test of assemblying, it just parses the code as keys, in the future it will convert the code into byte code
        
        public static void MakeExecutable(string code,string ExecutableNameWithExtension)
        {

            if (File.Exists(code))
            {
                code = File.ReadAllText(code);
            }
            else
            {
                Console.WriteLine("File not found");
                return;
            }

            code = code.Replace('\n', ';');

            Console.WriteLine(code);
            File.WriteAllText(ExecutableNameWithExtension, SEF_UTILS.Encrypt(code));
            Console.WriteLine("executable generated");
            Console.WriteLine(SEF_UTILS.Encrypt(code));
        }

        public static void Execute(string code)
        {

            if (File.Exists(code))
            {
                code = File.ReadAllText(code);
            }
            else
            {
                Console.WriteLine("File not found");
                return;
            }
            string deob = SEF_UTILS.Decrypt(code);
            deob = deob.Replace(";","\n");

            Assemble(deob);

        }

        public static void Assemble(string code,bool IsFile = false)
        {

            if (IsFile)
            {

                if (File.Exists(code))
                {
                    code = File.ReadAllText(code);
                }
                else
                {
                    Console.WriteLine("File not found");
                    return;
                }
            }

            string[] splittedcode = code.Split('\n');

            string Cfunction = "";

            foreach (var item in splittedcode)
            {

                if (IsFuction && !item.StartsWith("BREAK"))
                {
                    Cfunction += item + "\n";
                }
                else
                {
                    string[] args = item.Split(' ', ',');


                    //Console.WriteLine(args[0].ToUpper());

                    switch (args[0].ToUpper())
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
                            SEF_CPU.Assemble(funcKeys[args[1]]);
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
                        case "ESC":
                            break;
                        case "HLT":
                            break;
                        case "IDIV":
                        case "DIV":

                            decimal Divto = 0;

                            switch (args[2])
                            {
                                case "AX":
                                    Divto = Regs.AX;
                                    break;
                                case "CX":
                                    Divto = Regs.CX;
                                    break;
                                case "BX":
                                    Divto = Regs.BX;
                                    break;
                                case "SP":
                                    Divto = Regs.SP;
                                    break;
                                case "BP":
                                    Divto = Regs.BP;
                                    break;
                                case "SI":
                                    Divto = Regs.SI;
                                    break;
                                case "DI":
                                    Divto = Regs.DI;
                                    break;
                                default:

                                    if (decimal.TryParse(args[2], out Divto))
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
                                    Regs.AX /= Divto;
                                    break;
                                case "CX":
                                    Regs.CX /= Divto;
                                    break;
                                case "BX":
                                    Regs.BX /= Divto;
                                    break;
                                case "SP":
                                    Regs.SP /= Divto;
                                    break;
                                case "BP":
                                    Regs.BP /= Divto;
                                    break;
                                case "SI":
                                    Regs.SI /= Divto;
                                    break;
                                case "DI":
                                    Regs.DI /= Divto;
                                    break;
                                default:
                                    Console.WriteLine($"{args[1].ToUpper()} is not a recognized register");
                                    break;
                            }

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
                        case "IMUL":
                        case "MUL":

                            decimal Multo = 0;

                            switch (args[2])
                            {
                                case "AX":
                                    Multo = Regs.AX;
                                    break;
                                case "CX":
                                    Multo = Regs.CX;
                                    break;
                                case "BX":
                                    Multo = Regs.BX;
                                    break;
                                case "SP":
                                    Multo = Regs.SP;
                                    break;
                                case "BP":
                                    Multo = Regs.BP;
                                    break;
                                case "SI":
                                    Multo = Regs.SI;
                                    break;
                                case "DI":
                                    Multo = Regs.DI;
                                    break;
                                default:

                                    if (decimal.TryParse(args[2], out Multo))
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
                                    Regs.AX *= Multo;
                                    break;
                                case "CX":
                                    Regs.CX *= Multo;
                                    break;
                                case "BX":
                                    Regs.BX *= Multo;
                                    break;
                                case "SP":
                                    Regs.SP *= Multo;
                                    break;
                                case "BP":
                                    Regs.BP *= Multo;
                                    break;
                                case "SI":
                                    Regs.SI *= Multo;
                                    break;
                                case "DI":
                                    Regs.DI *= Multo;
                                    break;
                                default:
                                    Console.WriteLine($"{args[1].ToUpper()} is not a recognized register");
                                    break;
                            }

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
                        case "PRI":

                            string pr = "";

                            for (int i = 0; i < args.Length; i++)
                            {
                                if (i > 0)
                                {
                                    pr += $" {args[i]}";
                                }
                            }

                            Console.Write(pr);
                            break;
                        case "PRL":

                            string prl = "";

                            for (int i = 0; i < args.Length; i++)
                            {
                                if (i > 0)
                                {
                                    prl += $" {args[i]}";
                                }
                            }

                            Console.WriteLine(prl);
                            break;
                        case "DEF":
                        case "FUNCTION":

                            if (args.Length == 2)
                            {
                                IsFuction = true;
                                FuncName = args[1];
                            }
                            else
                            {
                                Console.WriteLine("Invalid arguments");
                            }

                            break;
                        case "BREAK":
                            if (Cfunction != "")
                            {

                                funcKeys.Add(FuncName,Cfunction);

                            }
                            IsFuction = false;
                            Cfunction = "";
                            break;
                        case "RECT":
                            if (graphics.isgui)
                                graphics.canvas.DrawFilledRectangle(Color.FromName(args[5]), (int)SEF_UTILS.ParseArgs(args[1]), (int)SEF_UTILS.ParseArgs(args[2]), (int)SEF_UTILS.ParseArgs(args[3]), (int)SEF_UTILS.ParseArgs(args[4]));
                            break;
                        case "INITGUI":

                            if (graphics.isgui == false)
                            {
                                graphics.entry();
                            }

                            break;
                        default:
                            break;
                    }
                }

            }

            return;

        }

    }
}
