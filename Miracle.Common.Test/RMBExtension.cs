using Miracle.Common.Utility.RMB;
using System;
using static System.Console;

namespace Miracle.Common.Test
{
    public static partial class Test
    {
        /// <summary>
        /// RMB工具类测试
        /// </summary>
        public static void RMBTest()
        {
            WriteColorText("RMB Test:", ConsoleColor.Green);
            WriteColorText("--------------------------------------------------------------------------------------------------------------------", ConsoleColor.Yellow);
            WriteLine("数字转中文大写:");
            var rmb_test_number = 1247823232352324312648.34m;
            Write($"{rmb_test_number}转为大写:");
            WriteColorText(RmbTools.ConvertToChinese(rmb_test_number), ConsoleColor.Magenta);

#pragma warning disable  //这个地方会报方法过时,使用这个东西忽略警告.
            Write("12648.34m转为大写:");
            WriteColorText(RmbTools.NumToChineseStr(12648.34m), ConsoleColor.Magenta);//这种方法当数据过大存在溢出风险
#pragma warning restore

            WriteLine("字符串转中文大写:");
            var rmb_test_string = "878343235234853234.56";
            Write($"{rmb_test_string}转为大写:");
            WriteColorText(RmbTools.ConvertToChinese(rmb_test_string), ConsoleColor.Magenta);
            try
            {
                WriteColorText("[异常测试:]");
                WriteLine(RmbTools.ConvertToChinese("测试"));
            }
            catch (Exception ex)
            {
                WriteColorText(ex);
                WriteColorText("--------------------------------------------------------------------------------------------------------------------", ConsoleColor.Yellow);
            }
            WriteColorText("RMBTest complete", ConsoleColor.Green);
        }
    }
}
