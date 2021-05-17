using System;

namespace Miracle.Common.Utility.DateTimeExtension
{
    public static class Tools
    {
        /// <summary>
        /// 获取整周的星期数字形式
        /// </summary>
        /// <param name="day"></param>
        /// <returns></returns>
        public static int DayNumber(this DayOfWeek day) => day switch
        {
            DayOfWeek.Friday => 5,
            DayOfWeek.Monday => 1,
            DayOfWeek.Saturday => 6,
            DayOfWeek.Thursday => 4,
            DayOfWeek.Tuesday => 2,
            DayOfWeek.Wednesday => 3,
            _ => 7,
        };

        /// <summary>
        /// 将0-7的数字转化成DayOfWeek类型
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static DayOfWeek ToDayOfWeek(this int number) => number > 7 | number < 0
                ? throw new("please input 0-7")
                : number switch
                {
                    0 => DayOfWeek.Sunday,
                    1 => DayOfWeek.Monday,
                    2 => DayOfWeek.Tuesday,
                    3 => DayOfWeek.Wednesday,
                    4 => DayOfWeek.Thursday,
                    5 => DayOfWeek.Friday,
                    6 => DayOfWeek.Saturday,
                    _ => DayOfWeek.Sunday
                };

        /// <summary>
        /// 验证时间段和另一个时间段的重合情况
        /// </summary>
        /// <param name="sub">需要验证的时间段</param>
        /// <param name="validate">所属源</param>
        /// <returns>ETimeOverlap</returns>
        public static ETimeOverlap TimeOverlap(Tuple<DateTime, DateTime> sub, Tuple<DateTime, DateTime> validate)
        {
            var (substart, subend) = sub;
            var (validatestart, validateend) = validate;
            return substart >= subend | validatestart >= validateend
                ? throw new("时间段不合法")
                : substart >= validatestart && substart < validateend && subend <= validateend && subend > validatestart
                ? ETimeOverlap.包含或等于
                : substart < validatestart && subend >= validatestart && subend < validateend
                ? ETimeOverlap.后段包含于
                : substart > validatestart && substart >= validateend && subend > validateend ? ETimeOverlap.前段包含于 : ETimeOverlap.不在范围内;
        }
    }
}
