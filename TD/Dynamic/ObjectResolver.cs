using System;
using System.Collections;
using System.Diagnostics;
using System.Text;

namespace TD.Dynamic
{
	[DebuggerStepThrough]
	internal sealed class ObjectResolver
	{
		#region Entrance
		/// <summary>
		/// Initializes a new instance of the <see cref="ObjectResolver"/> class.
		/// </summary>
		public ObjectResolver() { }
		#endregion

		#region Business Methods
		/// <summary>
		/// Resolves the specified obj.
		/// </summary>
		/// <param name="obj">The obj.</param>
		/// <returns></returns>
		public string Resolve(object obj)
		{
			if (object.ReferenceEquals(null, obj))
				return "null";
			else if (obj is string || obj is DateTime)
				return string.Format("\"{0}\"", obj);
			else
			{
				var code = Convert.GetTypeCode(obj);
				if (code == TypeCode.Object)
				{
					if (obj is IEnumerable)
						return ResolveArray(obj);
					else
						return ResolveObject(obj);
				}
				else if (code == TypeCode.DBNull)
					return "null";
				else if (code == TypeCode.Boolean)
					return obj.ToString().ToLower();
				else
					return obj.ToString();
			}
		}
		#endregion

		#region Private Methods
		private string ResolveObject(object obj)
		{
			if (object.ReferenceEquals(null, obj))
				return "null";

			StringBuilder sbJson = new StringBuilder("{");
			Type type = obj.GetType();
			var properties = type.GetProperties();
			foreach (var item in properties)
				sbJson.AppendFormat("\"{0}\":{1},"
				, item.Name,
				Resolve(item.GetValue(obj, null)));
			if (sbJson.Length != 1)
				sbJson.Remove(sbJson.Length - 1, 1);
			sbJson.Append("}");
			return sbJson.ToString();
		}

		private string ResolveArray(object obj)
		{
			if (ReferenceEquals(null, obj))
				return "null"; 
			StringBuilder sbJson = new StringBuilder();
			if (obj is IDictionary)
			{
				var data = obj as IDictionary;
				sbJson.Append("{");
				foreach (DictionaryEntry item in data)
					sbJson.AppendFormat("\"{0}\":{1},", item.Key, Resolve(item.Value));
				if (sbJson.Length != 1)
					sbJson.Remove(sbJson.Length - 1, 1);
				sbJson.Append("}");
			}
			else if (obj is IEnumerable)
			{
				var data = obj as IEnumerable;
				sbJson.Append("[");
				foreach (var item in data)
					sbJson.Append(Resolve(item)).Append(",");
				if (sbJson.Length != 1)
					sbJson.Remove(sbJson.Length - 1, 1);
				sbJson.Append("]");
			}

			return sbJson.ToString();
		}
		#endregion
	}
}
