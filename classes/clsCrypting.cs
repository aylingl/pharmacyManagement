using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;


namespace pharmacyManagement.classes
{
    public static class clsCrypting
    {
        public static string SHA256(string strInput) // this function result is same as javascript function.
        {
            byte[] bytes = Encoding.UTF8.GetBytes(strInput);
            SHA256Managed hashstring = new SHA256Managed();
            byte[] hash = hashstring.ComputeHash(bytes);
            string hashString = string.Empty;
            foreach (byte x in hash)
            {
                hashString += String.Format("{0:x2}", x);
            }
            return hashString;
        }
    }
}
