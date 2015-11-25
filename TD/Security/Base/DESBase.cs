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
        /// <param name="key">密钥(长度8)</param>
        /// <param name="iv">初始化向量(长度8)</param>
        /// <param name="data">要加密的数据</param>
        /// <returns>编码结果</returns>
        public virtual string Encode(byte[] key, byte[] iv, string data)
        {
            return Coder(key, iv, data, false);
        }

        /// <summary>
        /// 解码
        /// </summary>
        /// <param name="key">密钥(长度8)</param>
        /// <param name="iv">初始化向量(长度8)</param>
        /// <param name="data">要解密的数据</param>
        /// <returns>解码结果</returns>
        public virtual string Decode(byte[] key, byte[] iv, string data)
        {
            return Coder(key, iv, data, true);
        }

        /// <summary>
        /// 生成随机的Key和初始化向量
        /// </summary>
        /// <returns>随机的Key和初始化向量</returns>
        public virtual DESKey GenerateRandomKey()
        {
            var des = new DESCryptoServiceProvider();
            des.GenerateIV();
            des.GenerateKey();
            return new DESKey
            {
                IV = des.IV,
                Key = des.Key
            };
        }

        /// <summary>
        /// 编码器
        /// </summary>
        /// <param name="key">密钥</param>
        /// <param name="iv">初始化向量</param>
        /// <param name="data">要加密/解密的数据</param>
        /// <param name="decrypt">true:解密，false：加密</param>
        /// <returns>编码结果</returns>
        private string Coder(byte[] key, byte[] iv, string data, bool decrypt)
        {
            var des = new DESCryptoServiceProvider();
            var dataArray = decrypt ? Convert.FromBase64String(data)
                : Encoding.UTF8.GetBytes(data);
            using (var memoryStream = new MemoryStream())
            {
                var encryptor = decrypt
                    ? des.CreateDecryptor(key, iv)
                    : des.CreateEncryptor(key, iv);
                using (var cryptStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                {
                    cryptStream.Write(dataArray, 0, dataArray.Length);
                    cryptStream.FlushFinalBlock();
                    return decrypt ? Encoding.UTF8.GetString(memoryStream.ToArray())
                        : Convert.ToBase64String(memoryStream.ToArray());
                }
            }
        }
    }
}
