using System.Web;

namespace TD.Encode.Base
{
	public abstract class UrlEncodeBase
	{
		/// <summary>
		/// 编码
		/// </summary>
		/// <param name="url">需编码的Url</param>
		/// <returns>编码结果</returns>
		public virtual string Encode(string url)
		{
			return string.IsNullOrEmpty(url) ? url :
					HttpUtility.UrlEncode(url);
		}

		/// <summary>
		/// 解码
		/// </summary>
		/// <param name="encodeUrl">进行Url编码的字串</param>
		/// <returns>解码结果</returns>
		public virtual string Decode(string encodeUrl)
		{
			return string.IsNullOrEmpty(encodeUrl) ? string.Empty
					: HttpUtility.UrlDecode(encodeUrl);
		}
	}
}
