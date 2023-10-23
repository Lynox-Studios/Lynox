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
        //assembly instructions and registers

        public enum Keys
        {

            ADD,
            CALL,
            AAA,
            AAD,
            AAM,
            AAS,
            ADC,
            AND,
            CBW,
            CLC,
            CLD,
            CLI,
            CMC,
            CMPSB,
            CMPSW,
            CWD,
            DAA,
            DAS,
            DEC,
            DIV,
            ESC,
            HLT,
            IDIV,
            IMULT,
            IN,
            INC,
            INT,
            INTO,
            IRET,
            Jcc,
            JCXZ,
            JMP,
            LAHF,
            LDS,
            LEA,
            LES,
            LOCK,
            LODSB,
            LODSW,
            LOOP,
            LOOPx,
            MOV,
            MOVSB,
            MOVSW,
            MUL,
            NEG,
            NOP,
            NOT,
            OR,
            OUT,
            POP,
            PUSH,
            PUSHF,
            RCL,
            RCR,
            REPxx,
            RET,
            RETN,
            RETF,
            ROL,
            ROR,
            SAHF,
            SAL,
            SAR,
            SBB,
            SCASB,
            SCASW,
            SHL,
            SHR,
            STC,
            STD,
            STI,
            STOSB,
            STOSW,
            SUB,
            TEST,
            WAIT,
            XCHG,
            ALAT,
            XOR

        }
        //16-bit registers for now
        public static class Regs
        {

            public static decimal AX, CX,BX,SP,BP,SI,DI;

        }

        public enum ERegs
        {

            AX, CX, BX, SP, BP, SI, DI

        }

        //test of assemblying, it just parses the code as keys, in the future it will convert the code into byte code
        public static void Assemble(string code)
        {

            string[] splittedcode = code.Split('\n');

            foreach (var item in splittedcode)
            {

                string[] args = item.Split(' ',',');

                switch (SEF_UTILS.ToEnum<Keys>(args[0]))
                {
                    case Keys.ADD:

                        decimal Addto;

                        switch (SEF_UTILS.ToEnum<ERegs>(args[2]))
                        {
                            case ERegs.AX:
                                Addto = Regs.AX;
                                break;
                            case ERegs.CX:
                                Addto = Regs.CX;
                                break;
                            case ERegs.BX:
                                Addto = Regs.BX;
                                break;
                            case ERegs.SP:
                                Addto = Regs.SP;
                                break;
                            case ERegs.BP:
                                Addto = Regs.BP;
                                break;
                            case ERegs.SI:
                                Addto = Regs.SI;
                                break;
                            case ERegs.DI:
                                Addto = Regs.DI;
                                break;
                            default:

                                if (decimal.TryParse(args[2],out Addto))
                                {}
                                else
                                {
                                    Console.WriteLine($"{args[2].ToUpper()} is not a recognized register");
                                }

                                break;
                        }

                        switch (SEF_UTILS.ToEnum<ERegs>(args[1].ToUpper()))
                        {
                            case ERegs.AX:
                                Regs.AX += Addto;
                                break;
                            case ERegs.CX:
                                Regs.CX += Addto;
                                break;
                            case ERegs.BX:
                                Regs.BX += Addto;
                                break;
                            case ERegs.SP:
                                Regs.SP += Addto;
                                break;
                            case ERegs.BP:
                                Regs.BP += Addto;
                                break;
                            case ERegs.SI:
                                Regs.SI += Addto;
                                break;
                            case ERegs.DI:
                                Regs.DI += Addto;
                                break;
                            default:
                                Console.WriteLine($"{args[1].ToUpper()} is not a recognized register");
                                break;
                        }

                        break;
                    case Keys.CALL:
                        break;
                    case Keys.AAA:
                        break;
                    case Keys.AAD:
                        break;
                    case Keys.AAM:
                        break;
                    case Keys.AAS:
                        break;
                    case Keys.ADC:
                        break;
                    case Keys.AND:
                        break;
                    case Keys.CBW:
                        break;
                    case Keys.CLC:
                        break;
                    case Keys.CLD:
                        break;
                    case Keys.CLI:
                        break;
                    case Keys.CMC:
                        break;
                    case Keys.CMPSB:
                        break;
                    case Keys.CMPSW:
                        break;
                    case Keys.CWD:
                        break;
                    case Keys.DAA:
                        break;
                    case Keys.DAS:
                        break;
                    case Keys.DEC:
                        break;
                    case Keys.DIV:
                        break;
                    case Keys.ESC:
                        break;
                    case Keys.HLT:
                        break;
                    case Keys.IDIV:
                        break;
                    case Keys.IMULT:
                        break;
                    case Keys.IN:
                        break;
                    case Keys.INC:
                        break;
                    case Keys.INT:
                        break;
                    case Keys.INTO:
                        break;
                    case Keys.IRET:
                        break;
                    case Keys.Jcc:
                        break;
                    case Keys.JCXZ:
                        break;
                    case Keys.JMP:
                        break;
                    case Keys.LAHF:
                        break;
                    case Keys.LDS:
                        break;
                    case Keys.LEA:
                        break;
                    case Keys.LES:
                        break;
                    case Keys.LOCK:
                        break;
                    case Keys.LODSB:
                        break;
                    case Keys.LODSW:
                        break;
                    case Keys.LOOP:
                        break;
                    case Keys.LOOPx:
                        break;
                    case Keys.MOV:
                        break;
                    case Keys.MOVSB:
                        break;
                    case Keys.MOVSW:
                        break;
                    case Keys.MUL:
                        break;
                    case Keys.NEG:
                        break;
                    case Keys.NOP:
                        break;
                    case Keys.NOT:
                        break;
                    case Keys.OR:
                        break;
                    case Keys.OUT:
                        break;
                    case Keys.POP:
                        break;
                    case Keys.PUSH:
                        break;
                    case Keys.PUSHF:
                        break;
                    case Keys.RCL:
                        break;
                    case Keys.RCR:
                        break;
                    case Keys.REPxx:
                        break;
                    case Keys.RET:
                        break;
                    case Keys.RETN:
                        break;
                    case Keys.RETF:
                        break;
                    case Keys.ROL:
                        break;
                    case Keys.ROR:
                        break;
                    case Keys.SAHF:
                        break;
                    case Keys.SAL:
                        break;
                    case Keys.SAR:
                        break;
                    case Keys.SBB:
                        break;
                    case Keys.SCASB:
                        break;
                    case Keys.SCASW:
                        break;
                    case Keys.SHL:
                        break;
                    case Keys.SHR:
                        break;
                    case Keys.STC:
                        break;
                    case Keys.STD:
                        break;
                    case Keys.STI:
                        break;
                    case Keys.STOSB:
                        break;
                    case Keys.STOSW:
                        break;
                    case Keys.SUB:
                        break;
                    case Keys.TEST:
                        break;
                    case Keys.WAIT:
                        break;
                    case Keys.XCHG:
                        break;
                    case Keys.ALAT:
                        break;
                    case Keys.XOR:
                        break;
                    default:
                        break;
                }

            }

        }

    }
}
