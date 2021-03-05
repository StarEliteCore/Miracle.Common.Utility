using Miracle.Common.Utility.DateTimeStamp;
using System;
using static System.Console;

namespace Miracle.Common.Test
{
    public static partial class Test
    {
        /// <summary>
        /// DateStampExtensionTest
        /// </summary>
        public static void DateStampExtensionTest()
        {
            WriteLine();
            WriteColorText("DateStampExtensionTest", ConsoleColor.Green);
            WriteColorText("--------------------------------------------------------------------------------------------------------------------", ConsoleColor.Yellow);
            WriteLine("DateTime转13位时间戳:");
            long timestamp_13bit = DateTime.Now.ToUnixTimeStamp_13bit();
            WriteLine($"DateTime:{DateTime.Now}");
            Write("13bit timestamp:");
            WriteColorText($"{timestamp_13bit}", ConsoleColor.Magenta);
            WriteLine("13位时间转DateTime:");
            Write("13bit timestamp:");
            WriteColorText($"{timestamp_13bit}", ConsoleColor.Magenta);
            Write("DateTime:");
            WriteColorText($"{ timestamp_13bit.ToDateTime()}", ConsoleColor.Magenta);
            WriteLine();
            WriteLine("DateTime转10位时间戳:");
            int timestamp_10bit = DateTime.Now.ToLinuxTimeStamp_10bit();
            WriteLine($"DateTime:{DateTime.Now}");
            Write("10bit timestamp:");
            WriteColorText($"{timestamp_10bit}", ConsoleColor.Magenta);
            WriteLine("10位时间戳转DateTime:");
            Write("10bit timestamp:");
            WriteColorText($"{timestamp_10bit}", ConsoleColor.Magenta);
            Write("DateTime:");
            WriteColorText($"{timestamp_10bit.ToDateTime()}", ConsoleColor.Magenta);
            WriteColorText("--------------------------------------------------------------------------------------------------------------------", ConsoleColor.Yellow);
            WriteColorText("DateStampExtensionTest Complete", ConsoleColor.Green);
            WriteLine();
        }
    }
}
