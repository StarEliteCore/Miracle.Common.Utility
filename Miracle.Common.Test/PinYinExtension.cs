using Miracle.Common.Utility.PinYin;
using System;
using System.Text;
using static System.Console;

namespace Miracle.Common.Test
{
    public static partial class Test
    {
        /// <summary>
        /// PyToolsTest
        /// </summary>
        public static void PyToolsTest()
        {
            WriteLine();
            WriteColorText("PyToolsTest", ConsoleColor.Green);
            WriteColorText("--------------------------------------------------------------------------------------------------------------------", ConsoleColor.Yellow);
            string[] maxims = { "事常与人违，123456789", @"骏马是跑出来的，?|\!@$%^&*()_+=-,./';:{}[]<>", "深圳" };
            string[] medicines = { "聚维酮碘溶液", "开塞露", "输血记录", "深圳" };
            WriteLine("UTF8句子拼音：");
            foreach (var s in maxims)
            {
                Write("汉字：");
                WriteColorText($"{s}", ConsoleColor.DarkCyan, false);
                Write("\n拼音：");
                WriteColorText($"{PyTools.GetPinYin(s, '%')}\n", ConsoleColor.Magenta);
            }
            var GBK = Encoding.GetEncoding("GBK");
            WriteLine("GBK拼音简码：");
            WriteColorText("不支持汉字使用自定义符号'%'替代测试:", ConsoleColor.DarkYellow);
            Write("錒：\n简码：");
            WriteColorText($"{PyTools.GetInitials("錒", '%', GBK)}\n", ConsoleColor.Magenta);
            foreach (var m in medicines)
            {
                Write("药品：");
                WriteColorText($"{PyTools.ConvertEncoding(m, Encoding.UTF8, GBK)}\n", ConsoleColor.Magenta, false);
                Write("简码：");
                WriteColorText($"{ PyTools.GetInitials(PyTools.ConvertEncoding(m, Encoding.UTF8, GBK), '?', GBK)}\n", ConsoleColor.Magenta);
            }
            WriteColorText("--------------------------------------------------------------------------------------------------------------------", ConsoleColor.Yellow);
            WriteColorText("PyToolsTest Complete", ConsoleColor.Green);
            WriteLine();
        }
    }
}
