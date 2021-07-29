using System;

namespace Miracle.Common.Utility.NumberToDateTime
{
    public static class NumberToDateTime
    {
        /// <summary>
        /// 年份👉DateTime(某年的初始时间)
        /// </summary>
        /// <param name="year">年份</param>
        /// <returns></returns>
        public static DateTime Year2DateTime(this short year) => YearToDateTime(year);
        /// <summary>
        /// 年份👉DateTime(某年的初始时间)
        /// </summary>
        /// <param name="year">年份</param>
        /// <returns></returns>
        public static DateTime Year2DateTime(this int year) => YearToDateTime(year);
        /// <summary>
        /// 年份👉DateTime(某年的初始时间)
        /// </summary>
        /// <param name="year">年份</param>
        /// <returns></returns>
        public static DateTime Year2DateTime(this long year) => YearToDateTime(year);
        /// <summary>
        /// 年份👉DateTime(某年的初始时间)
        /// </summary>
        /// <param name="year">年份</param>
        /// <returns></returns>
        public static DateTime Year2DateTime(this ushort year) => YearToDateTime(year);
        /// <summary>
        /// 年份👉DateTime(某年的初始时间)
        /// </summary>
        /// <param name="year">年份</param>
        /// <returns></returns>
        public static DateTime Year2DateTime(this uint year) => YearToDateTime(year);
        /// <summary>
        /// 年份👉DateTime(某年的初始时间)
        /// </summary>
        /// <param name="year">年份</param>
        /// <returns></returns>
        public static DateTime Year2DateTime(this ulong year) => YearToDateTime(year);
        /// <summary>
        /// 年份👉DateTime(某年的初始时间)
        /// </summary>
        /// <param name="year">年份</param>
        /// <returns></returns>
        public static DateTime Year2DateTime(this float year) => YearToDateTime(year);
        /// <summary>
        /// 年份👉DateTime(某年的初始时间)
        /// </summary>
        /// <param name="year">年份</param>
        /// <returns></returns>
        public static DateTime Year2DateTime(this double year) => YearToDateTime(year);
        /// <summary>
        /// 年份👉DateTime(某年的初始时间)
        /// </summary>
        /// <param name="year">年份</param>
        /// <returns></returns>
        public static DateTime Year2DateTime(this decimal year) => YearToDateTime(year);
        /// <summary>
        /// 获取某月某年的月份
        /// </summary>
        /// <param name="month"></param>
        /// <param name="year"></param>
        /// <returns></returns>
        public static DateTime Month2DateTime(this short month, int year) => MonthToDateTime(month, year);
        /// <summary>
        /// 获取某月某年的月份
        /// </summary>
        /// <param name="month"></param>
        /// <param name="year"></param>
        /// <returns></returns>
        public static DateTime Month2DateTime(this int month, int year) => MonthToDateTime(month, year);
        /// <summary>
        /// 获取某月某年的月份
        /// </summary>
        /// <param name="month"></param>
        /// <param name="year"></param>
        /// <returns></returns>
        public static DateTime Month2DateTime(this long month, int year) => MonthToDateTime(month, year);
        /// <summary>
        /// 获取某月某年的月份
        /// </summary>
        /// <param name="month"></param>
        /// <param name="year"></param>
        /// <returns></returns>
        public static DateTime Month2DateTime(this ushort month, int year) => MonthToDateTime(month, year);
        /// <summary>
        /// 获取某月某年的月份
        /// </summary>
        /// <param name="month"></param>
        /// <param name="year"></param>
        /// <returns></returns>
        public static DateTime Month2DateTime(this uint month, int year) => MonthToDateTime(month, year);
        /// <summary>
        /// 获取某月某年的月份
        /// </summary>
        /// <param name="month"></param>
        /// <param name="year"></param>
        /// <returns></returns>
        public static DateTime Month2DateTime(this ulong month, int year) => MonthToDateTime(month, year);
        /// <summary>
        /// 获取某月某年的月份
        /// </summary>
        /// <param name="month"></param>
        /// <param name="year"></param>
        /// <returns></returns>
        public static DateTime Month2DateTime(this float month, int year) => MonthToDateTime(month, year);
        /// <summary>
        /// 获取某月某年的月份
        /// </summary>
        /// <param name="month"></param>
        /// <param name="year"></param>
        /// <returns></returns>
        public static DateTime Month2DateTime(this double month, int year) => MonthToDateTime(month, year);
        /// <summary>
        /// 获取某月某年的月份
        /// </summary>
        /// <param name="month"></param>
        /// <param name="year"></param>
        /// <returns></returns>
        public static DateTime Month2DateTime(this decimal month, int year) => MonthToDateTime(month, year);
        /// <summary>
        /// 获取某年某月偏移N周的起始时间
        /// </summary>
        /// <param name="week">周数</param>
        /// <param name="year">年份</param>
        /// <param name="month">月份</param>
        /// <returns></returns>
        public static DateTime Week2DateTime(this short week, int month, int year) => WeekToDateTime(week, month, year);
        /// <summary>
        /// 获取某年某月偏移N周的起始时间
        /// </summary>
        /// <param name="week">周数</param>
        /// <param name="year">年份</param>
        /// <param name="month">月份</param>
        /// <returns></returns>
        public static DateTime Week2DateTime(this int week, int month, int year) => WeekToDateTime(week, month, year);
        /// <summary>
        /// 获取某年某月偏移N周的起始时间
        /// </summary>
        /// <param name="week">周数</param>
        /// <param name="year">年份</param>
        /// <param name="month">月份</param>
        /// <returns></returns>
        public static DateTime Week2DateTime(this long week, int month, int year) => WeekToDateTime(week, month, year);
        /// <summary>
        /// 获取某年某月偏移N周的起始时间
        /// </summary>
        /// <param name="week">周数</param>
        /// <param name="year">年份</param>
        /// <param name="month">月份</param>
        /// <returns></returns>
        public static DateTime Week2DateTime(this ushort week, int month, int year) => WeekToDateTime(week, month, year);
        /// <summary>
        /// 获取某年某月偏移N周的起始时间
        /// </summary>
        /// <param name="week">周数</param>
        /// <param name="year">年份</param>
        /// <param name="month">月份</param>
        /// <returns></returns>
        public static DateTime Week2DateTime(this uint week, int month, int year) => WeekToDateTime(week, month, year);
        /// <summary>
        /// 获取某年某月偏移N周的起始时间
        /// </summary>
        /// <param name="week">周数</param>
        /// <param name="year">年份</param>
        /// <param name="month">月份</param>
        /// <returns></returns>
        public static DateTime Week2DateTime(this ulong week, int month, int year) => WeekToDateTime(week, month, year);
        /// <summary>
        /// 获取某年某月偏移N周的起始时间
        /// </summary>
        /// <param name="week">周数</param>
        /// <param name="year">年份</param>
        /// <param name="month">月份</param>
        /// <returns></returns>
        public static DateTime Week2DateTime(this float week, int month, int year) => WeekToDateTime(week, month, year);
        /// <summary>
        /// 获取某年某月偏移N周的起始时间
        /// </summary>
        /// <param name="week">周数</param>
        /// <param name="year">年份</param>
        /// <param name="month">月份</param>
        /// <returns></returns>
        public static DateTime Week2DateTime(this double week, int month, int year) => WeekToDateTime(week, month, year);
        /// <summary>
        /// 获取某年某月偏移N周的起始时间
        /// </summary>
        /// <param name="week">周数</param>
        /// <param name="year">年份</param>
        /// <param name="month">月份</param>
        /// <returns></returns>
        public static DateTime Week2DateTime(this decimal week, int month, int year) => WeekToDateTime(week, month, year);



        /// <summary>
        /// 将对象转化为Int32
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        private static int ToInt32(object number) => Convert.ToInt32(number);
        /// <summary>
        /// 转化为年份
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        private static DateTime YearToDateTime(object year) => new(ToInt32(year), 1, 1);
        /// <summary>
        /// 转化为月份
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        private static DateTime MonthToDateTime(object month, int year) => new(year, ToInt32(month), 1);
        /// <summary>
        /// 获取某年某月偏移N周的起始时间
        /// </summary>
        /// <param name="week">周数</param>
        /// <param name="year">年份</param>
        /// <param name="month">月份</param>
        /// <returns></returns>
        private static DateTime WeekToDateTime(object week, int year, int month) => Month2DateTime(month, year).AddDays(ToInt32(week) * 7);
    }
}
