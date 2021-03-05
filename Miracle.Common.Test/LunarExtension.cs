using Miracle.Common.Utility.ChineseLunar;
using System;
using static System.Console;

namespace Miracle.Common.Test
{
    public static partial class Test
    {
        /// <summary>
        /// 农历测试
        /// </summary>
        public static void LunarTest()
        {
            WriteLine();
            WriteColorText("LunarTest", ConsoleColor.Green);
            WriteColorText("--------------------------------------------------------------------------------------------------------------------", ConsoleColor.Yellow);
            WriteLine($"农历输出年月日.当前系统时间 {DateTime.Now}");
            Write("年:");
            WriteColorText($"{ToLunar.LunarYear}", ConsoleColor.Magenta, false);
            Write("月:");
            WriteColorText($"{ ToLunar.LunarMonth}", ConsoleColor.Magenta, false);
            Write("日:");
            WriteColorText($"{ ToLunar.LunarDay}", ConsoleColor.Magenta);
            WriteLine($"星座:当前系统时间 {DateTime.Now}");
            Write("星座:");
            WriteColorText($"{ToLunar.Constellation}", ConsoleColor.Magenta);
            Write("属相:");
            WriteColorText($"{ToLunar.Animal}", ConsoleColor.Magenta);
            ToLunar.Init(new DateTime(1994, 11, 15));
            Write($"农历输出年月日:1994-11-15");
            WriteColorText($" {ToLunar.ChineseLunar}", ConsoleColor.Magenta);
            Write("年:");
            WriteColorText($"{ToLunar.LunarYear}", ConsoleColor.Magenta, false);
            Write("月:");
            WriteColorText($"{ ToLunar.LunarMonth}", ConsoleColor.Magenta, false);
            Write("日:");
            WriteColorText($"{ ToLunar.LunarDay}", ConsoleColor.Magenta);
            WriteLine("星座:1994-11-15");
            Write("星座:");
            WriteColorText($"{ToLunar.Constellation}", ConsoleColor.Magenta);
            Write("属相:");
            WriteColorText($"{ToLunar.Animal}", ConsoleColor.Magenta);
            WriteLine("农历输出:当前系统时间");
            ToLunar.Init(DateTime.Now);
            WriteColorText(ToLunar.ChineseLunar, ConsoleColor.Magenta);
            WriteLine("农历输出:20181120");
            ToLunar.Init("20181120");
            WriteColorText(ToLunar.ChineseLunar, ConsoleColor.Magenta);
            WriteColorText("农历偏移:", ConsoleColor.Blue);
            _ = ToLunar.AddYear(20);
            Write("增加20年:");
            WriteColorText($"{ToLunar.ChineseLunar}", ConsoleColor.Magenta);
            _ = ToLunar.AddYear(-10);
            Write("减少10年:");
            WriteColorText($"{ToLunar.ChineseLunar}", ConsoleColor.Magenta);
            _ = ToLunar.AddMonth(13);
            Write("增加13月:");
            WriteColorText($"{ToLunar.ChineseLunar}", ConsoleColor.Magenta);
            _ = ToLunar.AddMonth(-12);
            Write("减少12月:");
            WriteColorText($"{ToLunar.ChineseLunar}", ConsoleColor.Magenta);
            _ = ToLunar.AddDay(15);
            Write("增加15天:");
            WriteColorText($"{ToLunar.ChineseLunar}", ConsoleColor.Magenta);
            _ = ToLunar.AddDay(-12);
            Write("减少12天:");
            WriteColorText($"{ToLunar.ChineseLunar}", ConsoleColor.Magenta);
            WriteColorText("--------------------------------------------------------------------------------------------------------------------", ConsoleColor.Yellow);
            WriteColorText("LunarTest Complete", ConsoleColor.Green);
            WriteLine();
        }
    }
}
