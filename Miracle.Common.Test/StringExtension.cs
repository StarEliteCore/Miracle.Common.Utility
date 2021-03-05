using Miracle.Common.Utility.String;
using System;
using static System.Console;

namespace Miracle.Common.Test
{
    public static partial class Test
    {
        /// <summary>
        /// StringExtension测试
        /// </summary>
        public static void StringExtensionTest()
        {
            WriteLine();
            WriteColorText("StringExtensionTest", ConsoleColor.Green);
            WriteColorText("--------------------------------------------------------------------------------------------------------------------", ConsoleColor.Yellow);
            Write("将指定字符串,按照串联的方式重复一定次数.测试值:test,重复两次:");
            WriteColorText("test".ReplicateString(2), ConsoleColor.Magenta);
            WriteLine();
            Write("将指定字符,按照串联的方式重复一定次数.测试值:t,重复三次:");
            WriteColorText("t".ReplicateString(3), ConsoleColor.Magenta);
            WriteLine();
            Write("日期字符串转化为日期对象:");
            var time = "2019-01-01".ToDateTime();
            WriteColorText(time.ToLongDateString(), ConsoleColor.Magenta);
            WriteLine();
            WriteLine("字符串数组转换成字符串集合.测试数组:{'123sdf','dsgsdg','gf3rgt'}");
            string[] vs = { "123sdf", "dsgsdg", "gf3rgt" };
            WriteColorText(vs.ToStringCollection().GetType().ToString(), ConsoleColor.Magenta);
            WriteLine();
            WriteLine("以特定字符间隔的字符串转化为字符串集合.测试字符串:'dhgausdg,sudygfuasdg,3235sdg'");
            Write("以','为间隔符,输出转化后的字符串数量:");
            WriteColorText($"{"dhgausdg, sudygfuasdg, 3235sdg".ToStringCollection(',').Count}", ConsoleColor.Magenta);
            WriteLine();
            WriteLine("以特定字符间隔的字符串转化为字符串集合.测试字符串:'siuhgasidgh12sdgasdhafh12989878ajshgdasd12adgase'");
            Write("以'12'为间隔符,输出转化后的字符串数量:");
            WriteColorText($"{"siuhgasidgh12sdgasdhafh12989878ajshgdasd12adgase".ToStringCollection("12").Count}", ConsoleColor.Magenta);
            WriteLine();
            WriteLine("将字符串中的单词首字母大写,测试字符串:'game over'");
            var str = "game over".ToTitleUpperCase();
            WriteColorText(str, ConsoleColor.Magenta);
            WriteLine("将字符串中的单词首字母小写.测试字符串:为上函数转化后的字符串");
            WriteColorText(str.ToTitleLowerCase(), ConsoleColor.Magenta);
            Write("将字符串值'123'转换为整数:");
            WriteColorText($"{ "123".ToInt()}", ConsoleColor.Magenta);
            WriteLine();
            Write("将字符串转换为GUID:测试字符串:'936DA01F-9ABD-4d9d-80C7-02AF85C822A8',输出结果:");
            WriteColorText($"{"936DA01F-9ABD-4d9d-80C7-02AF85C822A8".ToGuid().GetType().ToString()}", ConsoleColor.Magenta);
            WriteLine();
            WriteLine("将字符串转换为GUID异常测试:测试字符串:'Microsoft'");
            try
            {
                WriteColorText($"{"Microsoft".ToGuid()}", ConsoleColor.Magenta);
            }
            catch (Exception ex)
            {
                WriteColorText(ex);
            }
            WriteLine();
            var base64str = "Microsoft".StringToBase64();
            Write("将字符串转换成Base64字符串:测试字符串:'Microsoft',输出结果:");
            WriteColorText(base64str, ConsoleColor.Magenta);
            WriteLine();
            Write($"将Base64字符转成String:测试字符串:'{base64str}',输出结果:");
            WriteColorText(base64str.Base64ToString(), ConsoleColor.Magenta);
            WriteLine();
            WriteLine("字符串插入指定分隔符,隔多少个字符插入分隔符.测试字符串为:'独立国家哈桑领导讲话稿按时鉴定会gals的机会格拉斯的结果'");
            Write("每隔4个字符插入一个逗号,输出结果为:");
            WriteColorText("独立国家哈桑领导讲话稿按时鉴定会gals的机会格拉斯的".Spacing(",", 3), ConsoleColor.Magenta);
            WriteLine();
            WriteLine("字符串的全角半角转换:测试字符串:'我是ABC,你是谁?'");
            var sbc = "我是ABC,你是谁?".ToSBC();
            Write("转化为全角:");
            WriteColorText(sbc, ConsoleColor.Magenta);
            Write("转化为半角:");
            WriteColorText(sbc.ToDBC(), ConsoleColor.Magenta);
            WriteLine();
            WriteLine("测试字符串是否为数字函数:测试字符串为:'3634635'和'767sf'");
            Write("3634635:", "3634635".IsNumber());
            WriteColorText($"{"3634635".IsNumber()}", ConsoleColor.Magenta);
            Write("767sf:");
            WriteColorText($"{"767sf".IsNumber()}", ConsoleColor.Magenta);
            WriteLine();
            WriteLine(@"验证某个字符串是否符合某个正则表达式:测试方式为电子邮件:test@qq.com和www.qq.com,正则为:'[\w]+(\.[\w]+)*@[\w]+(\.[\w])+'");
            Write("test@qq.com的结果:");
            WriteColorText($"{"test@qq.com".QuickValidate(@"[\w]+(\.[\w]+)*@[\w]+(\.[\w])+")}", ConsoleColor.Magenta);
            Write("www.qq.com的结果:");
            WriteColorText($"{"www.qq.com".QuickValidate(@"[\w]+(\.[\w]+)*@[\w]+(\.[\w])+")}", ConsoleColor.Magenta);
            WriteLine();
            Write("指针方式反转字符串:中文汉字反转测试:");
            WriteColorText($"{new string("中文汉字反转测试").ReverseByPointer()}", ConsoleColor.Magenta);
            WriteLine();
            // 由于使用指针反转后,会对内存数据进行修改,所以后边的函数再次使用相同的变量就会出现看起来没有反转一样,所以再反转一次
            Write("StringBuilder反转字符串:中文汉字反转测试:");
            WriteColorText($"{new string("中文汉字反转测试").ReverseByStringBuilder()}", ConsoleColor.Magenta);
            WriteLine();
            Write("ReverseByArray反转字符串:中文汉字反转测试:");
            WriteColorText($"{new string("中文汉字反转测试").ReverseByArray()}", ConsoleColor.Magenta);
            WriteLine();
            WriteColorText("--------------------------------------------------------------------------------------------------------------------", ConsoleColor.Yellow);
            WriteColorText("StringExtensionTest Complete", ConsoleColor.Green);
            WriteLine();
        }
    }
}
