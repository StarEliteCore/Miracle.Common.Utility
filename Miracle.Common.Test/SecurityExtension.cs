using Miracle.Common.Utility.Security;
using System;
using System.Text;
using static System.Console;

namespace Miracle.Common.Test
{
    public static partial class Test
    {
        /// <summary>
        /// 安全加密扩展
        /// </summary>
        public static void SecurityExtensionTest()
        {
            WriteLine();
            WriteColorText("SecurityExtensionTest", ConsoleColor.Green);
            WriteColorText("--------------------------------------------------------------------------------------------------------------------", ConsoleColor.Yellow);
            Write("使用加密服务提供程序(CSP)计算输入数据的MD5哈希值.测试值:microsoft,输出结果为:");
            WriteColorText("microsoft".ToMD5(), ConsoleColor.Magenta);
            WriteLine();
            Write("使用加密服务提供程序(CSP)计算输入数据的SHA1哈希值.测试值:microsoft,输出结果为:");
            WriteColorText("microsoft".ToSHA1(), ConsoleColor.Magenta);
            WriteLine();
            WriteLine("对字符串进行DES加密.测试字符串:'Microsoft love Linux'");
            string encryptstr = "Microsoft love Linux".DESEncrypt("Linux doesn't love Microsoft");
            Write("密匙为:'Linux doesn't love Microsoft'DES加密结果:");
            WriteColorText(encryptstr, ConsoleColor.Magenta);
            WriteLine();
            //WriteLine("大佬的加密算法:{0}", "Microsoft love Linux".Des("Linux doesn't love Microsoft", "Linux doesn't love Microsoft"));
            Write("密匙为:'Linux doesn't love Microsoft'DES解密结果:");
            WriteColorText(encryptstr.DESDecrypt("Linux doesn't love Microsoft"), ConsoleColor.Magenta);
            WriteLine();
            WriteLine("当密匙错误的时候的情况:");
            try
            {
                _ = encryptstr.DESDecrypt("Linux love Microsoft");
            }
            catch (Exception ex)
            {
                WriteColorText(ex);
            }
            WriteLine();
            WriteLine("测试将使用BitConverter转化的字节数组重新转为字节数组,所使用的字符串为上边加密后的字符串");
            byte[] bytes = encryptstr.StringToBit();
            WriteColorText(FormateByte(bytes), ConsoleColor.DarkYellow);
            WriteLine();
            Write("测试对字符串进行不可逆DES加密输出结果,测试字符串为:'Microsoft love Linux',输出结果如下:");
            WriteColorText("Microsoft love Linux".IrreversibleEncrypt(), ConsoleColor.Magenta);
            WriteLine();
            WriteLine("TripleDES 算法加密解密测试:");
            Write("对字符串进行加密,测试字符串为:Microsoft,密钥为:microsoft,加密后的内容:");
            string tripstr = "Microsoft".TripleDESEncrypt("microsoft");
            WriteColorText(tripstr, ConsoleColor.Magenta);
            WriteLine();
            Write("对加密后的字符串进行解密:");
            WriteColorText(tripstr.TripleDESDecrypt("microsoft"), ConsoleColor.Magenta);
            WriteLine();
            Write("按照指定字符集输出解密后的字符串:UTF-8字符集输出:");
            WriteColorText(tripstr.TripleDESDecrypt(Encoding.UTF8, "microsoft"), ConsoleColor.Magenta);
            WriteLine();
            Write("对字节数组进行加密:测试子节数组为:'[23,34,156,78]',密码为:Microsoft,加密结果:");
            byte[] bty = { 23, 34, 156, 78 };
            var value = bty.TripleDESEncrypt("Microsoft");
            WriteColorText(FormateByte(value), ConsoleColor.Magenta);
            WriteLine();
            Write("对上述加密后的字节数组进行解密,密码为:Microsoft,解密结果:");
            var back = value.TripleDESDecrypt("Microsoft");
            WriteColorText(FormateByte(back), ConsoleColor.Magenta);
            WriteLine();
            WriteLine("密码错误测试:");
            try
            {
                _ = tripstr.TripleDESDecrypt("TEST");
            }
            catch (Exception ex)
            {
                WriteColorText(ex);
            }
            WriteLine();
            try
            {
                _ = value.TripleDESDecrypt("TEST");
            }
            catch (Exception ex)
            {
                WriteColorText(ex);
            }
            WriteLine();
            WriteColorText("--------------------------------------------------------------------------------------------------------------------", ConsoleColor.Yellow);
            WriteColorText("SecurityExtensionTest Complete", ConsoleColor.Green);
            WriteLine();
        }
    }
}
