using Miraclesoft.Common.Utility.Exceptions;
using Miraclesoft.Common.Utility.RMB;
using System;
using System.Collections.Generic;
using System.Text;

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
    }
}
