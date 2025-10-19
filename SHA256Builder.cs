using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
namespace WindowsFormsApp1
{
    internal class SHA256Builder
    {
        public static string ConvertToHash(string text)
        {
            SHA256 SHA256 = SHA256.Create();
            byte[] bytes = Encoding.ASCII.GetBytes(text);
            byte[] hash = SHA256.ComputeHash(bytes);
            StringBuilder sb = new StringBuilder();
            foreach (byte h in hash)
                sb.Append(h.ToString("X2"));
            return sb.ToString();
        }
    }
}
