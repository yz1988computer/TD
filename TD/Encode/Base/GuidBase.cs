using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TD.Encode.Base
{
    /// <summary>
    /// 生成简化的base64字串
    /// </summary>
    public class GuidBase
    {
        /// <summary>
        /// 生成Guid字串
        /// </summary>
        /// <param name="format">一个单格式说明符，它指示如何格式化此 System.Guid 的值。 format 参数可以是“N”、“D”、“B”、“P”或“X”。 如果 format 为 null 或空字符串 ("")，则使用“D”。</param>
        /// <returns></returns>
        public virtual string CreateGuid(string format = "N")
        {
            return Guid.NewGuid().ToString(format);
        }

        /// <summary>
        /// 生成length长度的ID字串
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        public virtual string CreateSimplifyID(int length = 6)
        {
            var data = new byte[length];
            new Random().NextBytes(data);
            return Convert.ToBase64String(data);
        }
    }
}
