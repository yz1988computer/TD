using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace TD.Security.Base
{
    public abstract class RSABase
    {
        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="publicKey">公钥</param>
        /// <param name="data">要加密的字串</param>
        /// <returns></returns>
        public virtual string Encode(string publicKey, string data)
        {
            var rsa = new RSACryptoServiceProvider();
            rsa.FromXmlString(publicKey);
            var cipherbytes = rsa.Encrypt(Encoding.UTF8.GetBytes(data), false);
            return Convert.ToBase64String(cipherbytes);
        }

        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="privateKey">私钥</param>
        /// <param name="data">要解密的数据</param>
        /// <returns></returns>
        public virtual string Decode(string privateKey, string data)
        {
            var rsa = new RSACryptoServiceProvider();
            rsa.FromXmlString(privateKey);
            var cipherbytes = rsa.Decrypt(Convert.FromBase64String(data), false);
            return Encoding.UTF8.GetString(cipherbytes);
        }

        /// <summary>
        /// 生成公钥、密钥对
        /// </summary>
        /// <returns></returns>
        public RSAKey GenerateKey()
        {
            var rsa = new RSACryptoServiceProvider();
            return new RSAKey
            {
                PrivateKey = rsa.ToXmlString(true),
                PublicKey = rsa.ToXmlString(false)
            };
        }
    }
}
