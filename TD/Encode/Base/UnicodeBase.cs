using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace TD.Encode.Base
{
    public class UnicodeBase
    {
        private readonly Regex r = new Regex(@"(?i)\\[uU]([0-9a-f]{4})");

        /// <summary>
        /// 将unicode字串转换为中文
        /// </summary>
        /// <param name="unicodeString"></param>
        /// <returns></returns>
        public virtual string Unicode2Ch(string unicodeString)
        {
            return r.Replace(unicodeString,
                m => ((char) (Convert.ToInt32(m.Groups[1].Value, 16))).ToString());
        }
    }
}
