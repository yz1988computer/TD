using System;
using System.Collections.Generic;
using TD.Encode.Base;

namespace TD.Encode
{
    public class UrlSafeBase64 : Base64Base
    {
        /// <summary>
        /// 默认替换项目，如何项目冲突，请自定义替换项
        /// 请注意：`符号为反引号，非单引号
        /// + => `P`
        /// = => `e`
        /// </summary>
        public Dictionary<string, string> ReplaceItems { get; set; }
            = new Dictionary<string, string>
            {
                {"+", "`p`"},
                {"=", "`e`"}
            };

        /// <summary>
        /// Base64字串中的+、=会导致Get/Post请求解析的时候出错
        /// 需要额外处理，解码需要用对应的Decode函数
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public override string Encode(string data)
        {
            var base64Str = base.Encode(data);
            foreach (var item in ReplaceItems)
                base64Str = base64Str.Replace(item.Key, item.Value);
            return base64Str;
        }

        /// <summary>
        /// UrlSafeBase64字串解码
        /// </summary>
        /// <param name="urlSafeBase64Str"></param>
        /// <returns></returns>
        public override string Decode(string urlSafeBase64Str)
        {
            var base64Str = base.Decode(urlSafeBase64Str);
            foreach (var item in ReplaceItems)
                base64Str = base64Str.Replace(item.Value, item.Key);
            return base64Str;
        }
    }
}
