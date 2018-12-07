using System;
using Miraclesoft.Common.Utility.RMB;
using Miraclesoft.Common.Utility.DateTimeStamp;
using Miraclesoft.Common.Utility.Exceptions;
using System.Text;
using Miraclesoft.Common.Utility.PinYin;
using Miraclesoft.Common.Utility.ChineseLunar;

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
            Console.WriteLine("--------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("字符串转中文大写:");
            var rmbteststring = "878343235234853234.56";
            Console.WriteLine($"原始文字:{rmbteststring}");
            Console.WriteLine(RmbTools.ConvertToChinese(rmbteststring));
            Console.WriteLine("--------------------------------------------------------------------------------------------------------------------");
            try
            {
                Console.WriteLine("异常测试:");
                Console.WriteLine(RmbTools.ConvertToChinese("测试"));
                Console.WriteLine("--------------------------------------------------------------------------------------------------------------------");
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
            Console.WriteLine($"DateTime:{DateTime.Now}       13bit timestamp{timestamp_13bit}");
            Console.WriteLine("13位时间转DateTime:");
            Console.WriteLine($"13bit timestamp:{timestamp_13bit} DateTime:{timestamp_13bit.ToDateTime()}");
            Console.WriteLine();
            Console.WriteLine("DateTime转10位时间戳:");
            int timestamp_10bit = DateTime.Now.ToLinuxTimeStamp_10bit();
            Console.WriteLine($"DateTime:{DateTime.Now}       10bit timestamp{timestamp_10bit}");
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
                "炉甘石洗剂",
                "氢化可的松软膏5461",
                "sadgsad测试1",
                "输血记录"
            };
            Console.WriteLine("UTF8句子拼音：");
            foreach (var s in maxims)
            {
                Console.WriteLine($"汉字：{s}\n拼音：{PyTools.GetPinYin(s, '%')}\n");
            }
            Console.WriteLine("--------------------------------------------------------------------------------------------------------------------");
            var GBK = Encoding.GetEncoding("GBK");
            Console.WriteLine("GBK拼音简码：");
            Console.WriteLine("--------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("不支持汉字使用自定义符号'%'替代测试:");
            Console.WriteLine($"錒：\n简码：{PyTools.GetInitials("錒", '%', GBK)}\n");
            Console.WriteLine("--------------------------------------------------------------------------------------------------------------------");
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
            Console.WriteLine("测试农历输出年月日.非特定日期");
            Console.WriteLine($"年:{Lunar.LunarYear},月:{Lunar.LunarMonth},日:{Lunar.LunarDay}");
            Console.WriteLine("--------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine($"测试农历输出年月日,特定日期:1994-11-15-{Lunar.GetDate(new DateTime(1994, 11, 15))}");
            Console.WriteLine($"年:{Lunar.LunarYear},月:{Lunar.LunarMonth},日:{Lunar.LunarDay}");
            Console.WriteLine("--------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("测试农历输出:DateTime.Now");
            Console.WriteLine(Lunar.GetDate(DateTime.Now));
            Console.WriteLine("--------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("测试农历输出:20181120");
            Console.WriteLine(Lunar.GetDate("20181120"));
            Console.WriteLine("测试农历输出:DateTime.Now");
            Console.WriteLine(Lunar.GetDate(DateTime.Now));
            Console.WriteLine("--------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("LunarTest Complete");
            Console.WriteLine();
        }
    }
}
