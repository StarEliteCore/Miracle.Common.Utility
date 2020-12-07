using System;

namespace Miracle.Common.Utility.DateTimeStamp
{
    /// <summary>
    /// 时间戳相关扩展
    /// </summary>
    public static class DateTimeStampExtension
    {
        /// <summary>
        /// 13位Unix时间戳转为DateTime
        /// </summary>
        /// <param name="timestamp">1970年到目标时间的毫秒数</param>
        /// <returns></returns>
        public static DateTime ToDateTime(this long timestamp)
        {
            return new DateTime(1970, 1, 1).ToLocalTime().AddSeconds(timestamp / 1000);
        }

        /// <summary>
        /// 10位Linux时间戳转为DateTime
        /// </summary>
        /// <param name="timestamp">1970年到目标时间的秒数</param>
        /// <returns></returns>
        public static DateTime ToDateTime(this int timestamp)
        {
            return new DateTime(1970, 1, 1).ToLocalTime().AddSeconds(timestamp);
        }

        /// <summary>
        /// DateTime时间格式转换为13位Unix时间戳 1970年1月1日到现在的毫秒数
        /// </summary>
        /// <param name="time">目标时间</param>
        /// <returns></returns>
        public static long ToUnixTimeStamp_13bit(this DateTime time)
        {
            return (long)((time - new DateTime(1970, 1, 1).ToLocalTime()).TotalSeconds * 1000);
        }

        /// <summary>
        /// DateTime时间格式转换为10位Linux时间戳 1970年1月1日到现在的秒数
        /// </summary>
        /// <param name="time">目标时间</param>
        /// <returns></returns>
        public static int ToLinuxTimeStamp_10bit(this DateTime time)
        {
            return (int)(time - (new DateTime(1970, 1, 1)).ToLocalTime()).TotalSeconds;
        }
    }
}
