using System;

namespace TD.Converter
{
    /// <summary>
    /// 非null数据转换类，转换为数据对应的默认值
    /// 主要用于项目数据显示，如果返回的默认值和项目有冲突，请自行处理
    /// </summary>
    public class NotNullConventer
    {
        /// <summary>
        /// 获取默认字串
        /// </summary>
        public string DefaultString => string.Empty;

        /// <summary>
        /// 获取默认int结果
        /// </summary>
        public int DefaultInt => int.MinValue;

        /// <summary>
        /// 默认bool值
        /// </summary>
        public bool DefaultBoolean => false;

        /// <summary>
        /// 默认日期
        /// </summary>
        public DateTime DefaultDateTime => DateTime.MinValue;

        /// <summary>
        /// 转换失败返回默认字串
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string ToString(object s)
        {
            return s?.ToString() ?? DefaultString;
        }

        /// <summary>
        /// 转换失败返回默认int值
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int ToInt(object s)
        {
            var result = DefaultInt;
            if (s == null) return result;
            int.TryParse(s.ToString(), out result);
            return result;
        }

        /// <summary>
        /// 转换失败返回默认bool值
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public bool ToBoolean(object s)
        {
            var result = DefaultBoolean;
            if (s == null) return result;
            bool.TryParse(s.ToString(), out result);
            return result;
        }

        /// <summary>
        /// 转换失败返回默认日期
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public DateTime ToDateTime(object s)
        {
            var result = DefaultDateTime;
            if (s == null) return result;
            DateTime.TryParse(s.ToString(), out result);
            return result;
        }
    }
}
