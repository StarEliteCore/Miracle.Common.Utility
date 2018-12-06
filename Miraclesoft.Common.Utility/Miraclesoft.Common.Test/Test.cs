using System;
using Miraclesoft.Common.Utility.RMB;
using Miraclesoft.Common.Utility.Extension.DateTimeStamp;
using Miraclesoft.Common.Utility.Exceptions;

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
            Console.WriteLine("RMB Test is complete");
        }

        public void DateStampExtensionTest()
        {
            Console.WriteLine("DateTime转13位时间戳:");
            long timestamp_13bit = DateTime.Now.ToUnixTimeStamp_13bit();
            Console.WriteLine($"DateTime:{DateTime.Now}       13bit timestamp{timestamp_13bit}");
            Console.WriteLine("13位时间转DateTime:");
            Console.WriteLine($"13bit timestamp:{timestamp_13bit} DateTime:{timestamp_13bit.ToDateTime()}");
            Console.WriteLine("");
            Console.WriteLine("DateTime转10位时间戳:");
            int timestamp_10bit = DateTime.Now.ToLinuxTimeStamp_10bit();
            Console.WriteLine($"DateTime:{DateTime.Now}       10bit timestamp{timestamp_10bit}");
            Console.WriteLine("10位时间戳转DateTime:");
            Console.WriteLine($"10bit timestamp:{timestamp_10bit}       DateTime:{timestamp_10bit.ToDateTime()}");
        }
    }
}
