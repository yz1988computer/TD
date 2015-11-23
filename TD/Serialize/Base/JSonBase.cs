using System;
using Newtonsoft.Json;

namespace TD.Serialize.Base
{
	public abstract class JSonBase
	{
		/// <summary>
		/// 序列化
		/// </summary>
		/// <param name="data">需要序列化的对象</param>
		/// <returns>序列化后的字串</returns>
		public virtual string Serialize(object data)
		{
			return data == null ? string.Empty
					: JsonConvert.SerializeObject(data);
		}

		/// <summary>
		/// 反序列化
		/// </summary>
		/// <typeparam name="T">类型</typeparam>
		/// <param name="content">序列化后的字串</param>
		/// <returns>反序列化的对象</returns>
		public virtual T DeserializeObject<T>(string content)
		{
			return string.IsNullOrEmpty(content) ? Activator.CreateInstance<T>()
					 : JsonConvert.DeserializeObject<T>(content);
		}

		public virtual dynamic DeserializeObject(string content)
		{
			return "";
		}
	}
}
