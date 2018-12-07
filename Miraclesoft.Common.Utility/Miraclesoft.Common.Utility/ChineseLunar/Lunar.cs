﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Miraclesoft.Common.Utility.ChineseLunar
{
    /**
      * 该Lib参考GitHub大神的Java项目所改.链接如下:
      * https://github.com/iceenongli/nongli
      */
    /// <summary>
    /// 公历转农历类(1700年-3100年)这个时间应该够用好几代人了.
    /// </summary>
    public static class Lunar
    {
        //将月份第十三位规定为闰月大小
        private static int First_Year = -1;
        private static int Last_Year = -1;
        private static readonly string[] dataTopInit = Init();
        /// <summary>
        /// 农历年
        /// </summary>
        private static string _Year = "";
        /// <summary>
        /// 农历月
        /// </summary>
        private static string _Month = "";
        /// <summary>
        /// 农历天
        /// </summary>
        private static string _Day = "";
        /// <summary>
        /// 获取特定日期农历年份,若是未调用GetData传入特定日期,则返回当前日期的农历年份
        /// </summary>
        public static string LunarYear
        {
            get
            {
                if (!string.IsNullOrEmpty(_Year.Trim()))
                    return _Year;
                else
                {
                    GetDate(DateTime.Now);
                    return _Year;
                }
            }
            private set => _Year = value;
        }
        /// <summary>
        /// 获取特定日期农历月份,若是未调用GetData传入特定日期,则返回当前日期的农历月份
        /// </summary>
        public static string LunarMonth
        {
            get
            {
                if (!string.IsNullOrEmpty(_Month.Trim()))
                    return _Month;
                else
                {
                    GetDate(DateTime.Now);
                    return _Month;
                }
            }
            private set => _Month = value;
        }
        /// <summary>
        /// 获取特定日期农历天,若是未调用GetData传入特定日期,则返回当前日期的农历天
        /// </summary>
        public static string LunarDay
        {
            get
            {
                if (!string.IsNullOrEmpty(_Day.Trim()))
                    return _Day;
                else
                {
                    GetDate(DateTime.Now);
                    return _Day;
                }
            }
            private set => _Day = value;
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <returns></returns>
        private static string[] Init()
        {
            var dataTop = Configs.Config;
            var year = dataTop[1].Substring(0, 4);
            var lastYearStr = dataTop[dataTop.Length - 1].Substring(0, 4);
            First_Year = int.Parse(year);
            Last_Year = int.Parse(lastYearStr);
            return dataTop;
        }

        /// <summary>
        /// 判断是否为闰年
        /// </summary>
        /// <param name="year">年份</param>
        /// <returns>是闰年:true,不是闰年:false</returns>
        [Obsolete]
        private static bool IsLeapYear(int year) => year % 172800 == 0 || year % 400 == 0 && year % 3200 != 0 || year % 4 == 0 && year % 100 != 0;
        //DateTime.IsLeapYear(year);

        /// <summary>
        /// 字符串获取一年中的第几天---获取距离一年中的第一天的天数差
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        private static int GetDays(string date) => new DateTime(int.Parse(date.Substring(0, 4)), int.Parse(date.Substring(4, 2)), int.Parse(date.Substring(6, 2))).DayOfYear;

        /// <summary>
        /// 将数字转化为汉字的数字,适应任何长度
        /// </summary>
        /// <param name="year">年</param>
        /// <returns></returns>
        private static string FormatYear(int year)
        {
            var result = new StringBuilder();
            var year2 = year;
            while (year2 != 0)
            {
                result.Append("零一二三四五六七八九".Substring(year2 % 10, 1));
                year2 /= 10;
            }
            return ReverseByPointer(result.ToString());
        }

        /// <summary>
        /// 反转字符串,这里使用了指针,速度较快
        /// </summary>
        /// <param name="original"></param>
        /// <returns></returns>
        private static unsafe string ReverseByPointer(this string original)
        {
            fixed (char* pText = original)
            {
                var pStart = pText;
                var pEnd = pText + original.Length - 1;
                for (var i = original.Length / 2; i >= 0; i--)
                {
                    var temp = *pStart;
                    *pStart++ = *pEnd;
                    *pEnd-- = temp;
                }
                return original;
            }
        }

        /// <summary>
        /// 月份转化为汉字,不含"月"字. 1为正月,2为二月,13为闰正月,24为闰腊月
        /// </summary>
        /// <param name="month"></param>
        /// <returns></returns>
        private static string FormatMonth(int month)
        {
            const string table = "正二三四五六七八九十冬腊";
            if (month > 12)
                return "闰" + table.Substring(month - 13, 1);
            return table.Substring(month - 1, 1);
        }

        /// <summary>
        /// 天数转为农历汉字天数 1为初一 30为三十
        /// </summary>
        /// <param name="day"></param>
        /// <exception cref="Exception"></exception>
        /// <returns></returns>
        private static string FormatDay(int day)
        {
            var day1 = day / 10;
            var day2 = day % 10;
            day1 -= day2 == 0 ? 1 : 0;
            switch (day)
            {
                case 30:
                    return "三十";
                case 20:
                    return "二十";
                default:
                    switch (day1)
                    {
                        case 0:
                            return "初" + "十一二三四五六七八九".Substring(day2, 1);
                        case 1:
                            return "十" + "十一二三四五六七八九".Substring(day2, 1);
                        case 2:
                            return "廿" + "十一二三四五六七八九".Substring(day2, 1);
                        default:
                            throw new Exception("不存在的农历日期");
                    }
            }
        }

        private static void Load(IList<string> dataInit, string data, int startYear) => dataInit[int.Parse(data.Substring(0, 4)) - startYear] = data;

        private static string[] Load(IReadOnlyList<string> data)
        {
            var dataTemp = new string[data.Count - 1];
            for (var i = 1; i < data.Count; i++)
                dataTemp[i - 1] = AddLastMonth(data[i], data[i - 1]);
            return dataTemp;
        }

        /// <summary>
        /// 17000219_  1010010010110_00
        /// 17000219_101010010010110_00
        /// 在年后面的下划线处插入mid
        /// </summary>
        /// <param name="thisYear"></param>
        /// <param name="lastYear"></param>
        /// <returns></returns>
        private static string AddLastMonth(string thisYear, string lastYear)
        {
            var last = lastYear.Substring(19);//last=110_07
            var mid = GetNovemberAndDecember(last);//mid=10
            var sb = new StringBuilder(thisYear);
            return sb.Insert(9, mid).ToString();
        }

        private static int[] Cast(string start, string now, int[] bigOrLitter, int leap)
        {
            var numStart = GetDays(start);//新年的累计天数
            var numNow = GetDays(now);//当前日期的累计天数
            var dif = numNow - numStart;//当前日期相对天数,相对新年 新年为0天
            var bigOrLitterSort = ResetSort(bigOrLitter, leap);
            var sum = 0 - bigOrLitterSort[0] - bigOrLitterSort[1] - 29 - 29;//去年11月1日的相对天数,为负数
            var i = 0;//月份
            while (dif >= sum)
                sum += bigOrLitterSort[i++] + 29; // 加上每月的农历天数
            var year = int.Parse(now.Substring(0, 4));//获取年份
            var result = new int[3];// 数组分别存储年月日.
            result[0] = dif < 0 ? year - 1 : year;//在过年前 取去年,在过年后 年份取今年.
            result[1] = i - 2 <= 0 ? i + 10 : i - 2;//月份  去年的11月是第一个月
            if (dif >= 0)
            {//过年以后
                if (leap != 0)
                {
                    if (result[1] == leap + 1)//当前月就是闰月
                        result[1] += 11;//闰月加12,从0开始又减1
                    else if (result[1] > leap + 1)//当前位于闰月之后
                        result[1]--;//减去闰掉的那个月
                }
            }
            else
            {
                var numYear = year;
                var startYear = First_Year;
                var dataInit = dataTopInit;
                var data = dataInit[numYear - startYear];
                var leapStr = data.Substring(23, 2);
                var lastLeap = int.Parse(leapStr);
                if (lastLeap != 0)
                {
                    if (result[1] == lastLeap)
                    {
                        switch (lastLeap)
                        {
                            case 11:
                                result[1] = 23;
                                break;
                            case 12:
                                result[1] = 24;
                                break;
                            default:
                                throw new Exception("-闰年错误,请联系作者修正-");
                        }
                    }
                    else
                    {
                        if (lastLeap == 11 && result[1] == 12 || lastLeap == 12 && result[1] == 11)
                            result[1] = 12;
                    }
                }
            }
            result[2] = dif - sum + bigOrLitterSort[i - 1] + 29 + 1;//计算日期
            return result;
        }

        private static int[] ResetSort(int[] bigOrLitter, int leap)
        {
            var len = bigOrLitter.Length;//15
            var bigOrLitterSort = new int[len];
            if (leap == 0)//直接复制数组
            {
                for (var i = 0; i < len; i++)
                    bigOrLitterSort[i] = bigOrLitter[i];
            }
            else//插入闰月大小
            {
                for (var i = 0; i < len; i++)
                {
                    var index = i - 2;
                    if (index > leap)
                        bigOrLitterSort[i] = bigOrLitter[i - 1];
                    else if (index == leap)
                        bigOrLitterSort[i] = bigOrLitter[len - 1];// 14
                    else
                        bigOrLitterSort[i] = bigOrLitter[i];
                }
            }
            return bigOrLitterSort;
        }

        private static int[] Cast(string now, string data)
        {
            var start = data.Substring(0, 8);//春节年月日
            var bigOrLitterStr = data.Substring(9, 15);//15个月的大小月 包含去年的两个月与今年的闰月大小
            var leapStr = data.Substring(25, 2);//闰月闰的月份两位数
            var bigOrLitter = new int[15];//将15个月的大小转为数组
            for (var i = 0; i < bigOrLitter.Length; i++)
                bigOrLitter[i] = int.Parse(bigOrLitterStr.Substring(i, 1));
            var leap = int.Parse(leapStr);//闰月数转为数字,闰的月份
            return Cast(start, now, bigOrLitter, leap);
        }

        /// <summary>
        /// 取前两位(上一年的十一月和十二月)
        /// 确保每一行都包含前一年的信息.(前一年的11月和12月份)
        /// last="110_07"
        /// mid="10"
        /// </summary>
        /// <param name="last"></param>
        /// <returns></returns>
        private static string GetNovemberAndDecember(string last) => last.Substring(0, 2);

        private static int[] Cast(string now, IReadOnlyList<string> dataInit, int startYear)
        {
            var year = now.Substring(0, 4);
            var numYear = int.Parse(year);
            var data = dataInit[numYear - startYear];
            var dataLast = dataInit[numYear - startYear - 1];
            if (dataLast.EndsWith("_11"))
                data = ReplaceLastYearMonth(data, SubLeapNovember(dataLast));
            else if (dataLast.EndsWith("_12"))
                data = ReplaceLastYearMonth(data, SubLeapDecember(dataLast));
            return Cast(now, data);
        }

        /// <summary>
        /// 替换去年12月与11月部分，共15位月份
        /// </summary>
        /// <param name="str"></param>
        /// <param name="newStr"></param>
        /// <returns></returns>
        private static string ReplaceLastYearMonth(string str, string newStr) => str.Substring(0, 9) + newStr + str.Substring(11);

        /// <summary>
        /// 去年闰十一月
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private static string SubLeapNovember(string str) => str.Substring(23, 1) + str.Substring(22, 1);

        /// <summary>
        /// 去年闰十二月
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private static string SubLeapDecember(string str) => str.Substring(22, 2);

        /// <summary>
        /// 验证
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        private static int[] Judge(DateTime date)
        {
            var year = date.Year.ToString();
            var month = date.Month < 10 ? "0" + date.Month : date.Month.ToString();
            var day = date.Day < 10 ? "0" + date.Day : date.Day.ToString();
            return Judge(year + month + day);
        }
        /// <summary>
        /// 验证
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        private static int[] Judge(string date)
        {
            int year;
            int month;
            int day;
            if (new Regex(@"\d{8}").Match(date) != null && new Regex(@"\d{8}").Match(date).Success)
            {
                year = int.Parse(date.Substring(0, 4));
                month = int.Parse(date.Substring(4, 2));
                day = int.Parse(date.Substring(6, 2));
            }
            else if (new Regex(@"\d+-\\d{1,2}-\\d{1,2}").Match(date) != null && new Regex(@"\d+-\\d{1,2}-\\d{1,2}").Match(date).Success)
            {
                var dateArray = date.Split('-');
                year = int.Parse(dateArray[0]);
                month = int.Parse(dateArray[1]);
                day = int.Parse(dateArray[2]);
            }
            else if (new Regex(@"\d+\\.\\d{1,2}\\.\\d{1,2}").Match(date) != null && new Regex(@"\d+\\.\\d{1,2}\\.\\d{1,2}").Match(date).Success)
            {
                var dateArray = date.Split('.');
                year = int.Parse(dateArray[0]);
                month = int.Parse(dateArray[1]);
                day = int.Parse(dateArray[2]);
            }
            else if (new Regex(@"\d+/\\d{1,2}/\\d{1,2}").Match(date) != null && new Regex(@"\d+/\\d{1,2}/\\d{1,2}").Match(date).Success)
            {
                var dateArray = date.Split('/');
                year = int.Parse(dateArray[0]);
                month = int.Parse(dateArray[1]);
                day = int.Parse(dateArray[2]);
            }
            else if (new Regex(@"\d+年\\d{1,2}月\\d{1,2}日").Match(date) != null && new Regex(@"\d+年\\d{1,2}月\\d{1,2}日").Match(date).Success)
            {
                var dateArray = date.Split('年', '月', '日');
                year = int.Parse(dateArray[0]);
                month = int.Parse(dateArray[1]);
                day = int.Parse(dateArray[2]);
            }
            else
                return null;
            var result = new int[3];
            result[0] = year;
            result[1] = month;
            result[2] = day;
            return result;
        }

        /// <summary>
        /// 验证
        /// </summary>
        /// <param name="date">日期数组 年|月|日</param>
        /// <returns></returns>
        private static bool Judge(IReadOnlyList<int> date)
        {
            var year = date[0];
            var month = date[1];
            var day = date[2];
            if (month > 12 || month < 1)
                return false;
            if (day > 31 || day < 1)
                return false;
            if (day == 31 && (month == 2 || month == 4 || month == 6 || month == 9 || month == 11))
                return false;
            if (month != 2)
                return true;
            if (day > 29)
                return false;
            return DateTime.IsLeapYear(year) || day <= 28;
        }

        /// <summary>
        /// int数组转为字符串
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        private static string Cast(IReadOnlyList<int> date) => AddZero(date[0], 4) + AddZero(date[1], 2) + AddZero(date[2], 2);

        /// <summary>
        /// 加0
        /// </summary>
        /// <param name="num">数字</param>
        /// <param name="size">长度</param>
        /// <returns></returns>
        private static string AddZero(int num, int size)
        {
            var len = (num + "").Length;
            if (len >= size)
                return num + "";
            var chs = new char[size - len];
            for (var i = 0; i < chs.Length; i++)
                chs[i] = '0';
            return new string(chs) + num;
        }

        /// <summary>
        /// 将 公历日期字符串 转为农历数组,公历字符串 格式 为8个数字,例如20120909 数组下标为0的是年,为1的是月,为2的是日.
        /// </summary>
        /// <param name="now">公历日期字符串</param>
        /// <returns>农历日期数组</returns>
        private static int[] Cast2Array(string now)
        {
            var dataTop = dataTopInit;
            var year = dataTop[1].Substring(0, 4);
            var startYear = int.Parse(year);
            var data = new string[dataTop.Length];
            foreach (var t in dataTop)
                Load(data, t, startYear - 1);
            return Cast(now, Load(data), startYear);
        }

        /// <summary>
        /// 将公历字符串转为农历字符串 公历字符串 格式 为8个数字，例如20120909
        /// </summary>
        /// <param name="date">公历日期字符串</param>
        /// <returns>农历日期字符串</returns>
        private static string Cast(string date)
        {
            var sb = new StringBuilder("");
            var result = Cast2Array(date);
            sb.Append(FormatYear(result[0]));            
            sb.Append("年");
            sb.Append(FormatMonth(result[1]));            
            sb.Append("月");
            sb.Append(FormatDay(result[2]));
            LunarYear = FormatYear(result[0]);
            LunarMonth = FormatMonth(result[1]);
            LunarDay = FormatDay(result[2]);
            return sb.ToString();
        }

        /// <summary>
        /// 公历日期转农历日期,公历日期合法性经过检查. 推荐的调用方法
        /// </summary>
        /// <param name="date">公历日期</param>
        /// <exception cref="Exception"></exception>
        /// <returns>农历日期</returns>
        public static string GetDate(string date)
        {
            var dateArray = Judge(date);
            if (dateArray == null)
                throw new Exception("-输入的日期不合法-");
            if (!Judge(dateArray))
                throw new Exception("-输入的日期不合法-");
            var year = dateArray[0];
            if (year < First_Year || year > Last_Year)
                throw new Exception("-输入的日期年份超出范围,年份必须在" + First_Year + "与" + Last_Year + "之间-");
            return Cast(Cast(dateArray));
        }
        /// <summary>
        /// 公历日期转农历日期,公历日期合法性经过检查. 推荐的调用方法
        /// </summary>
        /// <param name="date">公历日期对象</param>
        /// <exception cref="Exception"></exception>
        /// <returns>农历日期</returns>
        public static string GetDate(DateTime date)
        {
            var dateArray = Judge(date);
            if (dateArray == null)
                throw new Exception("-输入的日期不合法-");
            if (!Judge(dateArray))
                throw new Exception("-输入的日期不合法-");
            var year = dateArray[0];
            if (year < First_Year || year > Last_Year)
                throw new Exception("-输入的日期年份超出范围,年份必须在" + First_Year + "与" + Last_Year + "之间-");
            return Cast(Cast(dateArray));
        }
    }
}
