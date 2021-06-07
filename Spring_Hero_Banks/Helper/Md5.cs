using System.Security.Cryptography;
using System.Text;

namespace Spring_Hero_Banks.helper
{
    public class Md5
    {
        public string PasswordHash(string password, string salt)
        {
            var passwordString = password + salt;

            var stringPasswordHash = new StringBuilder();
            var md5 = new MD5CryptoServiceProvider();
            var bytes = md5.ComputeHash(new UTF8Encoding().GetBytes(passwordString));
            foreach (var t in bytes)
            {
                stringPasswordHash.Append(t.ToString("x2"));
            }
            return stringPasswordHash.ToString();
        }
    }
}