using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace TD.Security.Base
{
    public abstract class MD5Base
    {
        public virtual string Encode(string data)
        {
            var bytes = Encoding.Default.GetBytes(data);
            var md5 = new MD5CryptoServiceProvider();
            var hashValue = md5.ComputeHash(bytes);
            return BitConverter.ToString(hashValue).Replace("-", "");
        }
    }
}
