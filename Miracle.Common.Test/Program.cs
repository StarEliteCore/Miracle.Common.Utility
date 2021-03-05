using System;
using System.Text;

namespace Miracle.Common.Test
{
    class Program
    {
        static void Main(string[] args)
        {

            #region 人民币工具测试
            Test.RMBTest();
            #endregion

            #region DateTimeStampExtensionTest
            Test.DateStampExtensionTest();
            #endregion

            #region 拼音工具测试
            /**
             * 默认情况下.Net Core只支持28951,UTF-8,UTF-16,其他的编码格式均不支持.
             * 工具库已经引用了System.Text.Encoding.CodePages.dll
             * 在启动的时候,需要注册EncodingProvider,执行代码如下:
             * Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
             */
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            Test.PyToolsTest();
            #endregion

            #region 农历测试
            Test.LunarTest();
            #endregion

            #region 序列化测试
            Test.SerializerTest();
            #endregion

            #region 字符串扩展方法测试
            Test.StringExtensionTest();
            #endregion

            #region 字符串加密扩展测试
            Test.SecurityExtensionTest();
            #endregion

            #region 数组扩展函数测试
            Test.ArrayExtensionTest();
            #endregion

            #region DateTime扩展测试
            Test.DateTimeExtensionTest();
            #endregion

            try
            {
                //使用VSCode调试代码的时候ReadKey会抛出异常
                _ = Console.ReadKey();
            }
            catch { }
        }
    }
}
