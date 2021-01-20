using System;

namespace Miracle.Common.Utility.DateTimeExtension
{
    public static class DateTimeExtension
    {
        /// <summary>
        /// 获取某天的始末时间
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns>(Start, End)</returns>
        public static ValueTuple<DateTime, DateTime> DayStartEnd(this DateTime dateTime)
        {
            var Start = dateTime.Date;
            var End = Start.AddDays(1).AddMilliseconds(-1);
            return new ValueTuple<DateTime, DateTime>(Start, End);
        }

        /// <summary>
        /// 获取某月的始末时间
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns>(Start, End)</returns>
        public static ValueTuple<DateTime, DateTime> MonthStartEnd(DateTime dateTime)
        {
            var Start = dateTime.Date.AddDays(1 - dateTime.Day);
            var End = Start.AddMonths(1).AddMilliseconds(-1);
            return new ValueTuple<DateTime, DateTime>(Start, End);
        }

        /// <summary>
        /// 获取某年的始末时间
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns>(Start, End)</returns>
        public static ValueTuple<DateTime, DateTime> YearStartEnd(DateTime dateTime)
        {
            var Start = dateTime.Date.AddMonths(1 - dateTime.Month).AddDays(1 - dateTime.Day);
            var End = Start.AddYears(1).AddMilliseconds(-1);
            return new ValueTuple<DateTime, DateTime>(Start, End);
        }
    }
}
