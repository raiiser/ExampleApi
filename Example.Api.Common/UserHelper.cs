using System;
using System.Security.Cryptography;
using System.Text;

namespace Example.Api.Common
{
    public static class UserHelper
    {
        /// <summary>
        /// Encode le mot de passe en MD5
        /// </summary>
        /// <param name="password">Mot de passe à encoder</param>
        /// <returns>Le mot de passe encodé</returns>
        public static string EncodeMD5(string password)
        {
            string key = "Firejak" + password + "ASP.NET CORE";
            return BitConverter.ToString(new MD5CryptoServiceProvider().ComputeHash(ASCIIEncoding.Default.GetBytes(key)));
        }
    }
}
