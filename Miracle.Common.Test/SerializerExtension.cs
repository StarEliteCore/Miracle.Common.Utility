using Miracle.Common.Utility.Serialization;
using System;
using static System.Console;

namespace Miracle.Common.Test
{
    public static partial class Test
    {
        [Serializable]
        public class Student
        {
            public string Name { get; set; }

            public string Sex { get; set; }

            public int Age { get; set; }
            /// <summary>
            /// 将对象的姓名,性别,年龄信息输出到控制台
            /// </summary>
            public void ToConsole()
            {
                Write("姓名:");
                WriteColorText(Name, ConsoleColor.Cyan, false);
                Write("性别:");
                WriteColorText(Sex, ConsoleColor.Cyan, false);
                Write("年龄:");
                WriteColorText(Age.ToString(), ConsoleColor.Cyan);
            }
            private static void WriteColorText(string ex, ConsoleColor color = ConsoleColor.Red, bool wrap = true)
            {
                ForegroundColor = color;
                if (wrap) WriteLine(ex);
                else Write(ex);
                ForegroundColor = ConsoleColor.White;
            }
        }

        /// <summary>
        /// 序列化测试
        /// </summary>
        public static void SerializerTest()
        {
            WriteLine();
            WriteColorText("SerializerTest", ConsoleColor.Green);
            WriteColorText("--------------------------------------------------------------------------------------------------------------------", ConsoleColor.Yellow);
            WriteLine($"Xml序列化:");
            Student z_san = new()
            {
                Name = "张三",
                Sex = "女",
                Age = 23
            };
            var z_san_str = XmlSerializerTool.ToXml(z_san);
            WriteColorText(XmlSerializerTool.FormatXML(z_san_str), ConsoleColor.Magenta);
            WriteLine("Binary序列化:");
            Student li_si = new()
            {
                Name = "李四",
                Sex = "男",
                Age = 25
            };
            var li_si_str = BinarySerializerTool.ToBinary(li_si);
            WriteColorText(li_si_str, ConsoleColor.Magenta);
            WriteLine($"Xml反序列化:");
            var z_s = XmlSerializerTool.FromXml<Student>(z_san_str);
            z_s.ToConsole();
            WriteLine("Binary反序列化:");
            var lis = BinarySerializerTool.FromBinary<Student>(li_si_str);
            lis.ToConsole();
            WriteColorText("--------------------------------------------------------------------------------------------------------------------", ConsoleColor.Yellow);
            WriteColorText("SerializerTest Complete", ConsoleColor.Green);
            WriteLine();
        }
    }
}
