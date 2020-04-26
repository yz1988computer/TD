using TD.Encode.Base;

namespace TD.Encode
{
    public class GuidCreater:GuidBase
    {
        /// <summary>
        /// 生成小写的id，但是对=(移除)、+(替换为P)、/(替换为X)特殊处理
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        public override string CreateSimplifyID(int length = 6)
        {
            var data = base.CreateSimplifyID(length);
            return data.TrimEnd('=').ToLower().Replace("+", "P").Replace("/", "X");
        }
    }
}
