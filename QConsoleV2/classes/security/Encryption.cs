using System.Security.Cryptography;
using System.Text;

namespace QConsole.classes.security
{
    class Encryption
    { 
        public static string hashSHA256(string text)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(text);
            
            SHA256 sHA256 = SHA256.Create();
            byte[] hash = sHA256.ComputeHash(bytes);

            string hashString = string.Empty;
            
            foreach (byte x in hash)
            {
                hashString += string.Format("{0:x2}", x);
            }
            return hashString;
        }
    }
}
