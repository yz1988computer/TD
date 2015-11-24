using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace TD.Security.Base
{
    public abstract class DESBase
    {
        /// <summary>
        /// DES编码
        /// </summary>
        /// <param name="key">密钥</param>
        /// <param name="iv">初始化向量</param>
        /// <param name="data">要加密的数据</param>
        /// <returns>编码结果</returns>
        public virtual string Encode(string key, string iv, string data)
        {
            return Coder(key, iv, data, false);
        }

        /// <summary>
        /// 解码
        /// </summary>
        /// <param name="key">密钥</param>
        /// <param name="iv">初始化向量</param>
        /// <param name="data">要解密的数据</param>
        /// <returns>解码结果</returns>
        public virtual string Decode(string key, string iv, string data)
        {
            return Coder(key, iv, data, true);
        }

        /// <summary>
        /// 编码器
        /// </summary>
        /// <param name="key">密钥</param>
        /// <param name="iv">初始化向量</param>
        /// <param name="data">要加密/解密的数据</param>
        /// <param name="decrypt">true:解密，false：加密</param>
        /// <returns>编码结果</returns>
        private string Coder(string key, string iv, string data, bool decrypt)
        {
            var des = new DESCryptoServiceProvider();
            var keyArray = Encoding.UTF8.GetBytes(key);
            var ivArray = Encoding.UTF8.GetBytes(iv);
            var dataArray = Encoding.UTF8.GetBytes(data);
            using (var memoryStream = new MemoryStream())
            {
                var encryptor = decrypt
                    ? des.CreateDecryptor(keyArray, ivArray)
                    : des.CreateEncryptor(keyArray, ivArray);
                using (var cryptStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                {
                    cryptStream.Write(dataArray, 0, data.Length);
                    cryptStream.FlushFinalBlock();
                    return Convert.ToBase64String(memoryStream.ToArray());
                }
            }
        }
    }
}
