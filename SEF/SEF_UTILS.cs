using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Lynox.SEF.CPU.SEF_CPU;

namespace Lynox.SEF.UTILS
{
    public class SEF_UTILS
    {

        public static string DecimalToString(decimal input)
        {
            StringBuilder sb = new StringBuilder();
            string inputStr = input.ToString();

            for (int i = 0; i < inputStr.Length; i += 2)
            {
                string numberStr = inputStr.Substring(i, 2);
                int number = int.Parse(numberStr);
                char c = (char)number;
                sb.Append(c);
            }

            return sb.ToString();
        }

        public static long StringToDecimal(string input)
        {
            StringBuilder sb = new StringBuilder();

            foreach (char c in input)
            {
                sb.Append((int)c);
            }

            return long.Parse(sb.ToString());
        }
        public static string Encrypt(string textToEncrypt, int shift = 3)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char c in textToEncrypt)
            {
                if (char.IsLetter(c))
                {
                    char offset = char.IsUpper(c) ? 'A' : 'a';
                    sb.Append((char)((c + shift - offset) % 26 + offset));
                }
                else
                {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }

        public static string Decrypt(string encryptedText, int shift = 3)
        {
            return Encrypt(encryptedText, 26 - shift);
        }

        public static string StringToHex(string input)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char c in input)
                sb.Append(Convert.ToInt32(c).ToString());
            return sb.ToString();
        }

        public static byte[] HexStringToBytes(string hex)
        {
            return Enumerable.Range(0, hex.Length)
                             .Where(x => x % 2 == 0)
                             .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                             .ToArray();
        }

        public static string HexStringToString(string hex)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hex.Length; i += 2)
            {
                string hexChar = hex.Substring(i, 2);
                sb.Append((char)Convert.ToInt32(hexChar, 16));
            }
            return sb.ToString();
        }

        public static string ToHexString(byte[] bytes)
        {
            StringBuilder sb = new StringBuilder();
            foreach (byte b in bytes)
                sb.Append(b.ToString());
            return sb.ToString();
        }

        public static decimal ParseArgs(string argument)
        {

            switch (argument)
            {

                case "AX":
                    return Regs.AX;
                    break;
                case "CX":
                    return Regs.CX;
                    break;
                case "BX":
                    return Regs.BX;
                    break;
                case "SP":
                    return Regs.SP;
                    break;
                case "BP":
                    return Regs.BP;
                    break;
                case "SI":
                    return Regs.SI;
                    break;
                case "DI":
                    return Regs.DI;
                    break;
                default:

                    decimal o;

                    if (decimal.TryParse(argument, out o))
                    {

                        return o;

                    }
                    else
                    {
                        Console.WriteLine($"{argument.ToUpper()} is not a recognized register");
                        return 0;
                    }

                    break;
            }

        }

    }
}
