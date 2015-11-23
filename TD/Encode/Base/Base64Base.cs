using System;
using System.Text;

namespace TD.Encode.Base
{
    public abstract class Base64Base
    {
        /// <summary>
        /// 默认编码方式编制
        /// </summary>
        /// <param name="data">需编码的字串</param>
        /// <returns>base64值</returns>
        public virtual string Encode(string data)
        {
            return Encode(data, Encoding.Default);
        }

        /// <summary>
        /// 默认编码方式解码
        /// </summary>
        /// <param name="base64Data">需解码的base64字串</param>
        /// <returns>解码字串</returns>
        public virtual string Decode(string base64Data)
        {
            return Decode(base64Data, Encoding.Default);
        }

        /// <summary>
        /// 指定编码方式编制
        /// </summary>
        /// <param name="data">需编码的字串</param>
        /// <param name="encode">编码方式</param>
        /// <returns>base64值</returns>
        public virtual string Encode(string data, Encoding encode)
        {
            var bytes = encode.GetBytes(data);
            return Convert.ToBase64String(bytes);
        }

        /// <summary>
        /// 指定编码方式解码
        /// </summary>
        /// <param name="base64Data">需解码的base64字串</param>
        /// <param name="encode">编码方式</param>
        /// <returns>解码字串</returns>
        public virtual string Decode(string base64Data, Encoding encode)
        {
            var bytes = Convert.FromBase64String(base64Data);
            return encode.GetString(bytes);
        }

        public virtual string EncodeFromBytes(byte[] data)
        {
            return Convert.ToBase64String(data);
        }

        public virtual byte[] DecodeToBytes(string base64Data)
        {
            return Convert.FromBase64String(base64Data);
        }
    }
}
