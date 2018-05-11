using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Crypt
{
    public static class CryptPass
    {
        public static string Md5Crypt(string pass)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            md5.ComputeHash(Encoding.UTF8.GetBytes(pass));

            byte[] hash = md5.Hash;
            var sb = new StringBuilder(hash.Length * 2);

            foreach(var i in hash)
            {
                sb.Append(i.ToString("X2"));
            }

            return sb.ToString();
        }

        public static string Sha1Crypt(string pass)
        {
            using(SHA1Managed sha1 = new SHA1Managed())
            {
                var hash = sha1.ComputeHash(Encoding.UTF8.GetBytes(pass));
                var sb = new  StringBuilder(hash.Length * 2);

                foreach(var i in hash)
                {
                    sb.Append(i.ToString("X2"));
                }

                return sb.ToString();
            }
        }

        public static string Base64Crypt(string pass)
        {
            byte[] base64 = Encoding.UTF8.GetBytes(pass);
            return Convert.ToBase64String(base64);
        }
    }
}
