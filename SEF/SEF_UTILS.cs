using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lynox.SEF.UTILS
{
    public class SEF_UTILS
    {

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
                sb.Append(Convert.ToInt32(c).ToString("x"));
            return sb.ToString();
        }

        public static byte[] HexStringToBytes(string hex)
        {
            return Enumerable.Range(0, hex.Length)
                             .Where(x => x % 2 == 0)
                             .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                             .ToArray();
        }

        public static string ToHexString(byte[] bytes)
        {
            StringBuilder sb = new StringBuilder();
            foreach (byte b in bytes)
                sb.Append(b.ToString("X2"));
            return sb.ToString();
        }

    }
}
