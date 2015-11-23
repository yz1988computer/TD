using System;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace TD.Serialize.Base
{
	public abstract class FileSerializeBase
	{
		/// <summary>
		/// XML序列化
		/// </summary>
		/// <typeparam name="T">类型</typeparam>
		/// <param name="data">类型对象</param>
		/// <returns>XML字串</returns>
		public string XMLSerialize<T>(T data) where T : class
		{
			if (data == null) return string.Empty;
			using (var ms = new MemoryStream())
			{
				var serializer = new XmlSerializer(typeof(T));
				serializer.Serialize(ms, data);
				ms.Seek(0, SeekOrigin.Begin);
				using (var reader = new StreamReader(ms, Encoding.UTF8))
				{
					return reader.ReadToEnd();
				}
			}
		}

		/// <summary>
		/// XML反序列化
		/// </summary>
		/// <typeparam name="T">类型</typeparam>
		/// <param name="content">序列化后的XML字串</param>
		/// <returns>反序列化后的对象</returns>
		public T XMLDeSerialize<T>(string content) where T : class
		{
			if (string.IsNullOrEmpty(content)) 
				return Activator.CreateInstance<T>();
			using (var ms = new MemoryStream())
			{
				using (var sr = new StreamWriter(ms, Encoding.UTF8))
				{
					sr.Write(content);
					sr.Flush();
					ms.Seek(0, SeekOrigin.Begin);
					var serializer = new XmlSerializer(typeof(T));
					return serializer.Deserialize(ms) as T;
				}
			}
		}
	}
}
