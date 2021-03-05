using System;
using static System.Console;

namespace Miracle.Common.Test
{
    public static partial class Test
    {
        /// <summary>
        /// output text to console by color font,default red color.
        /// </summary>
        /// <param name="ex">异常对象</param>
        /// <param name="wrap">是否换行输出</param>
        public static void WriteColorText(Exception ex, ConsoleColor color = ConsoleColor.Red, bool wrap = true)
        {
            ForegroundColor = color;
            if (wrap) WriteLine(ex.ToString());
            else Write(ex.ToString());
            ForegroundColor = ConsoleColor.White;
        }
        /// <summary>
        /// output text to console by color font,default red color.
        /// </summary>
        /// <param name="ex">字符串类型</param>
        /// <param name="wrap">是否换行输出</param>
        public static void WriteColorText(string ex, ConsoleColor color = ConsoleColor.Red, bool wrap = true)
        {
            ForegroundColor = color;
            if (wrap) WriteLine(ex);
            else Write(ex);
            ForegroundColor = ConsoleColor.White;
        }
        /// <summary>
        /// 将Int数组按照{23,34,56}格式输出
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private static string FormateInt(int[] value)
        {
            var str = "{";
            for (var i = 0; i < value.Length; i++)
            {
                if (i < value.Length - 1)
                {
                    str += value[i];
                    str += ", ";
                }
                else
                    str += value[i];
            }
            str += "}";
            return str;
        }
        /// <summary>
        /// 将字节数组按照{23,34,56}格式输出
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private static string FormateByte(byte[] value)
        {
            var str = "{";
            for (var i = 0; i < value.Length; i++)
            {
                if (i < value.Length - 1)
                {
                    str += value[i];
                    str += ", ";
                }
                else
                    str += value[i];
            }
            str += "}";
            return str;
        }
    }
}
