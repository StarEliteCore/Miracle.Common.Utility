using System;
using System.Text;

namespace Miraclesoft.Common.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Test test = new Test();

            #region 人民币工具测试
            test.RMBTest();
            #endregion

            #region DateTimeStampExtensionTest
            test.DateStampExtensionTest();
            #endregion

            #region 拼音工具测试
            /**
             * 默认情况下.Net Core只支持28951,UTF-8,UTF-16,其他的编码格式均不支持.
             * 工具库已经引用了System.Text.Encoding.CodePages.dll
             * 在启动的时候,需要注册EncodingProvider,执行代码如下:
             * Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
             */
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            test.PyToolsTest();
            #endregion

            #region 农历测试
            test.LunarTest();
            #endregion

            #region 序列化测试
            test.SerializerTest();
            #endregion

            #region 字符串扩展方法测试
            test.StringExtensionTest();
            #endregion


            try
            {
                //使用VSCode调试代码的时候ReadKey会抛出异常
                Console.ReadKey();
            }
            catch { }
        }
    }
}
