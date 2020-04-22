using System;
namespace TD.Formatter
{
    public static class DateFormatter
    {
        public const string DateTimeFormat = "yyyy-MM-dd HH:mm:ss";
        public const string DateFormat = "yyyy-MM-dd";
        public const string TimeFormat = "HH:mm:ss";
        public const string YearMonthFormat = "yyyy-MM";
        public const string NoSplitFormat = "yyyyMMddHHmmss";

        /// <summary>
        /// 年-月-日 时:分:秒
        /// </summary>
        /// <param name="date"></param>
        /// <param name="formatter"></param>
        /// <returns></returns>
        public static string ToDateTimeString(this DateTime date, string formatter = DateTimeFormat)
        {
            return date.ToString(formatter);
        }

        /// <summary>
        /// 年月日时分秒
        /// </summary>
        /// <param name="date"></param>
        /// <param name="formatter"></param>
        /// <returns></returns>
        public static string ToDateTimeStringNoSplit(this DateTime date, string formatter = NoSplitFormat)
        {
            return date.ToString(formatter);
        }

        /// <summary>
        /// 年-月-日
        /// </summary>
        /// <param name="date"></param>
        /// <param name="formatter"></param>
        /// <returns></returns>
        public static string ToDateString(this DateTime date, string formatter = DateFormat)
        {
            return date.ToString(formatter);
        }

        /// <summary>
        /// 时:分:秒
        /// </summary>
        /// <param name="date"></param>
        /// <param name="formatter"></param>
        /// <returns></returns>
        public static string ToTimeString(this DateTime date, string formatter = TimeFormat)
        {
            return date.ToString(formatter);
        }

        /// <summary>
        /// 年-月
        /// </summary>
        /// <param name="date"></param>
        /// <param name="formatter"></param>
        /// <returns></returns>
        public static string ToYearMonthString(this DateTime date, string formatter = YearMonthFormat)
        {
            return date.ToDateTimeString(formatter);
        }
    }
}
