using System;
using Miraclesoft.Common.Utility.RMB;
using Miraclesoft.Common.Utility.DateTimeStamp;
using Miraclesoft.Common.Utility.Exceptions;
using System.Text;
using Miraclesoft.Common.Utility.PinYin;
using Miraclesoft.Common.Utility.ChineseLunar;
using Miraclesoft.Common.Utility.Serialization;

namespace Miraclesoft.Common.Test
{
    /// <summary>
    /// 测试类
    /// </summary>
    public class Test
    {
        /// <summary>
        /// RMB工具类测试
        /// </summary>
        public void RMBTest()
        {
            Console.WriteLine("RMB Test:");
            Console.WriteLine("--------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("数字转中文大写:");
            var rmbtestnumber = 1247823234234312648.34m;
            Console.WriteLine($"原始文字:{rmbtestnumber}");
            Console.WriteLine(RmbTools.ConvertToChinese(rmbtestnumber));
            Console.WriteLine("字符串转中文大写:");
            var rmbteststring = "878343235234853234.56";
            Console.WriteLine($"原始文字:{rmbteststring}");
            Console.WriteLine(RmbTools.ConvertToChinese(rmbteststring));
            try
            {
                Console.WriteLine("异常:");
                Console.WriteLine(RmbTools.ConvertToChinese("测试"));
            }
            catch (RmbException ex)
            {
                Console.WriteLine(ex.ToString());
                Console.WriteLine("--------------------------------------------------------------------------------------------------------------------");
            }
            Console.WriteLine("RMBTest complete");
        }

        /// <summary>
        /// DateStampExtensionTest
        /// </summary>
        public void DateStampExtensionTest()
        {
            Console.WriteLine();
            Console.WriteLine("DateStampExtensionTest");
            Console.WriteLine("--------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("DateTime转13位时间戳:");
            long timestamp_13bit = DateTime.Now.ToUnixTimeStamp_13bit();
            Console.WriteLine($"DateTime:{DateTime.Now}       13bit timestamp:{timestamp_13bit}");
            Console.WriteLine("13位时间转DateTime:");
            Console.WriteLine($"13bit timestamp:{timestamp_13bit} DateTime:{timestamp_13bit.ToDateTime()}");
            Console.WriteLine();
            Console.WriteLine("DateTime转10位时间戳:");
            int timestamp_10bit = DateTime.Now.ToLinuxTimeStamp_10bit();
            Console.WriteLine($"DateTime:{DateTime.Now}       10bit timestamp:{timestamp_10bit}");
            Console.WriteLine("10位时间戳转DateTime:");
            Console.WriteLine($"10bit timestamp:{timestamp_10bit}       DateTime:{timestamp_10bit.ToDateTime()}");
            Console.WriteLine("--------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("DateStampExtensionTest Complete");
            Console.WriteLine();
        }

        /// <summary>
        /// PyToolsTest
        /// </summary>
        public void PyToolsTest()
        {
            Console.WriteLine();
            Console.WriteLine("PyToolsTest");
            Console.WriteLine("--------------------------------------------------------------------------------------------------------------------");
            string[] maxims = {
                "事常与人违，事总在人为123456789",
                @"骏马是跑出来的，强兵是打出来的?|\!@$%^&*()_+=-,./';:{}[]<>",
                "驾驭命运的舵是奋斗。不抱有一丝幻想，不放弃一点机会,不停止一日努力.",
            };
            string[] medicines = {
                "聚维酮碘溶液",
                "开塞露",
                "sadgsad测试1",
                "输血记录"
            };
            Console.WriteLine("UTF8句子拼音：");
            foreach (var s in maxims)
            {
                Console.WriteLine($"汉字：{s}\n拼音：{PyTools.GetPinYin(s, '%')}\n");
            }
            var GBK = Encoding.GetEncoding("GBK");
            Console.WriteLine("GBK拼音简码：");
            Console.WriteLine("不支持汉字使用自定义符号'%'替代测试:");
            Console.WriteLine($"錒：\n简码：{PyTools.GetInitials("錒", '%', GBK)}\n");
            foreach (var m in medicines)
            {
                Console.WriteLine($"药品：{PyTools.ConvertEncoding(m, Encoding.UTF8, GBK)}\n简码：{PyTools.GetInitials(PyTools.ConvertEncoding(m, Encoding.UTF8, GBK), '测', GBK)}\n");
            }
            Console.WriteLine("--------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("PyToolsTest Complete");
            Console.WriteLine();
        }

        /// <summary>
        /// 农历测试
        /// </summary>
        public void LunarTest()
        {
            Console.WriteLine();
            Console.WriteLine("LunarTest");
            Console.WriteLine("--------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine($"农历输出年月日.当前系统时间 {DateTime.Now}");
            Console.WriteLine($"年:{ToLunar.LunarYear} 月:{ToLunar.LunarMonth} 日:{ToLunar.LunarDay}");
            Console.WriteLine($"星座:当前系统时间 {DateTime.Now}");
            Console.WriteLine($"星座:{ToLunar.Constellation}");
            Console.WriteLine($"属相:当前系统时间 {DateTime.Now}");
            Console.WriteLine($"属相:{ToLunar.Animal}");
            ToLunar.Init(new DateTime(1994, 11, 15));
            Console.WriteLine($"农历输出年月日:1994-11-15 {ToLunar.ChineseLunar}");
            Console.WriteLine($"年:{ToLunar.LunarYear} 月:{ToLunar.LunarMonth} 日:{ToLunar.LunarDay}");
            Console.WriteLine("星座:1994-11-15");
            Console.WriteLine($"星座:{ToLunar.Constellation}");
            Console.WriteLine("属相:1994-11-15");
            Console.WriteLine($"属相:{ToLunar.Animal}");
            Console.WriteLine("农历输出:当前系统时间");
            ToLunar.Init(DateTime.Now);
            Console.WriteLine(ToLunar.ChineseLunar);
            Console.WriteLine("农历输出:20181120");
            ToLunar.Init("20181120");
            Console.WriteLine(ToLunar.ChineseLunar);
            Console.WriteLine("农历偏移:");
            ToLunar.AddYear(20);
            Console.WriteLine($"增加20年:{ToLunar.ChineseLunar}");
            ToLunar.AddYear(-10);
            Console.WriteLine($"减少10年:{ToLunar.ChineseLunar}");
            ToLunar.AddMonth(13);
            Console.WriteLine($"增加13月:{ToLunar.ChineseLunar}");
            ToLunar.AddMonth(-12);
            Console.WriteLine($"减少12月:{ToLunar.ChineseLunar}");
            ToLunar.AddDay(15);
            Console.WriteLine($"增加15天:{ToLunar.ChineseLunar}");
            ToLunar.AddDay(-12);
            Console.WriteLine($"减少12天:{ToLunar.ChineseLunar}");
            Console.WriteLine("--------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("LunarTest Complete");
            Console.WriteLine();
        }

        [Serializable]
        public class Studet
        {
            public string Name { get; set; }

            public string Sex { get; set; }

            public int Age { get; set; }
            public string ToCmd() => $"姓名:{Name} 性别:{Sex} 年龄:{Age}";
        }

        /// <summary>
        /// 序列化测试
        /// </summary>
        public void SerializerTest()
        {
            Console.WriteLine();
            Console.WriteLine("SerializerTest");
            Console.WriteLine("--------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine($"Xml序列化:");
            Studet zhangsan = new Studet
            {
                Name = "张三",
                Sex = "女",
                Age = 23
            };
            var zhangsanstr = XmlSerializerTool.ToXml(zhangsan);
            Console.WriteLine(zhangsanstr);
            Console.WriteLine("Binary序列化:");
            Studet lisi = new Studet
            {
                Name = "李四",
                Sex = "男",
                Age = 25
            };
            var lisistr = BinarySerializerTool.ToBinary(lisi);
            Console.WriteLine(lisistr);
            Console.WriteLine($"Xml反序列化:");           
            var zhangs = XmlSerializerTool.FromXml<Studet>(zhangsanstr);
            Console.WriteLine(zhangs.ToCmd());
            Console.WriteLine("Binary反序列化:");
            var lis = BinarySerializerTool.FromBinary<Studet>(lisistr);
            Console.WriteLine(lis.ToCmd());
            Console.WriteLine("--------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("SerializerTest Complete");
            Console.WriteLine();
        }
    }
}
