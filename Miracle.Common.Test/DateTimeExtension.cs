using Miracle.Common.Utility.DateTimeExtension;
using System;
using static System.Console;

namespace Miracle.Common.Test
{
    public static partial class Test
    {
        /// <summary>
        /// DateTime扩展函数测试
        /// </summary>
        public static void DateTimeExtensionTest()
        {
            WriteLine();
            WriteColorText("DateTimeExtensionTest", ConsoleColor.Green);
            WriteColorText($@"--------------------------------------------------------------------------------------------------------------------", ConsoleColor.Yellow);
            var now = DateTime.Now;
            var daystart = now.DayStart();
            var dayend = now.DayEnd();
            var (days, daye) = now.DayStartEnd();

            var monthstart = now.MonthStart();
            var monthend = now.MonthEnd();
            var (months, monthe) = now.MonthStartEnd();
            var yearstart = now.YearStart();
            var yearend = now.YearEnd();
            var (yesrs, yeare) = now.YearStartEnd();
            WriteLine();
            Write("测试时间:");
            WriteColorText($"{ now:yyyy-MM-dd HH:mm:ss}", ConsoleColor.Yellow);
            Write("某日的开始时间:");
            WriteColorText($"{daystart:yyyy-MM-dd HH:mm:ss}", ConsoleColor.Magenta);
            Write("某日的结束时间:");
            WriteColorText($"{dayend:yyyy-MM-dd HH:mm:ss}", ConsoleColor.Magenta);
            Write("某日的开始时间和结束时间:");
            WriteColorText($"{days:yyyy-MM-dd HH:mm:ss} - {daye:yyyy-MM-dd HH:mm:ss}", ConsoleColor.Magenta);
            Write("某周的开始时间:[周一为一周的第一天]");
            WriteColorText($"{now.WeekStart(DayOfWeek.Monday):yyyy-MM-dd HH:mm:ss}", ConsoleColor.Magenta);
            Write("某周的结束时间:");
            WriteColorText($"{now.WeekEnd(DayOfWeek.Monday):yyyy-MM-dd HH:mm:ss}", ConsoleColor.Magenta);
            Write("某周的开始时间和结束时间:");
            var (weeks0, weeke0) = now.WeekStartEnd(DayOfWeek.Monday);
            WriteColorText($"{weeks0:yyyy-MM-dd HH:mm:ss} - {weeke0:yyyy-MM-dd HH:mm:ss}", ConsoleColor.Magenta);
            Write("某周的开始时间:[周日为一周的第一天]");
            WriteColorText($"{now.WeekStart(DayOfWeek.Sunday):yyyy-MM-dd HH:mm:ss}", ConsoleColor.Magenta);
            Write("某周的结束时间:");
            WriteColorText($"{now.WeekEnd(DayOfWeek.Sunday):yyyy-MM-dd HH:mm:ss}", ConsoleColor.Magenta);
            Write("某周的开始时间和结束时间:");
            var (weeks1, weeke1) = now.WeekStartEnd(DayOfWeek.Sunday);
            WriteColorText($"{weeks1:yyyy-MM-dd HH:mm:ss} - {weeke1:yyyy-MM-dd HH:mm:ss}", ConsoleColor.Magenta);
            Write("某月的开始时间:");
            WriteColorText($"{monthstart:yyyy-MM-dd HH:mm:ss}", ConsoleColor.Magenta);
            Write("某月的结束时间:");
            WriteColorText($"{monthend:yyyy-MM-dd HH:mm:ss}", ConsoleColor.Magenta);
            Write("某月的开始时间和结束时间:");
            WriteColorText($"{months:yyyy-MM-dd HH:mm:ss} - {monthe:yyyy-MM-dd HH:mm:ss}", ConsoleColor.Magenta);
            Write("某年的开始时间:");
            WriteColorText($"{yearstart:yyyy-MM-dd HH:mm:ss}", ConsoleColor.Magenta);
            Write("某年的结束时间:");
            WriteColorText($"{yearend:yyyy-MM-dd HH:mm:ss}", ConsoleColor.Magenta);
            Write("某年的开始时间和结束时间:");
            WriteColorText($"{yesrs:yyyy-MM-dd HH:mm:ss} - {yeare:yyyy-MM-dd HH:mm:ss}", ConsoleColor.Magenta);
            WriteLine();
            WriteColorText($@"--------------------------------------------------------------------------------------------------------------------", ConsoleColor.Yellow);
            WriteColorText("DateTimeExtensionTest Complete", ConsoleColor.Green);
            WriteLine();
        }
    }
}
