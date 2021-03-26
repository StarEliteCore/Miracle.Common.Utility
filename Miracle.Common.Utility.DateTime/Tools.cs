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
    }
}
