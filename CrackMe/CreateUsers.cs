using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Crypt;

namespace CrackMe
{
    public class CreateUsers
    {
        public CreateUsers()
        {
            User[] usuario =
            {
                new User
                {
                    Usuario = "usuario1",
                    Senha = "pass1",
                    IsHash = false,
                },
                new User
                {
                    Usuario = "usuario2",
                    Senha = CryptPass.Md5Crypt("pass2"),
                    IsHash = true,
                    Hash = "MD5",
                },
                new User
                {
                    Usuario = "usuario3",
                    Senha = CryptPass.Sha1Crypt("pass3"),
                    IsHash = true,
                    Hash = "SHA1",
                },
                new User
                {
                    Usuario = "usuario4",
                    Senha = CryptPass.Base64Crypt("pass4"),
                    IsHash = true,
                    Hash = "BASE64",
                },
            };

            using (CrackMeEntities context = new CrackMeEntities())
            {
                context.User.AddRange(usuario);
                context.SaveChanges();
            }
        }
    }
}
