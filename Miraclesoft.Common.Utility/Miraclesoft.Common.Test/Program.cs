using System;
using System.Text;

namespace Miraclesoft.Common.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Test test = new Test();

            #region RMBTest
            test.RMBTest();
            #endregion

            #region DateTimeStampExtensionTest
            test.DateStampExtensionTest();
            #endregion

            #region PyToolsTest
            /**
             * 默认情况下.Net Core只支持28951,UTF-8,UTF-16,其他的编码格式均不支持.
             * 工具库已经引用了System.Text.Encoding.CodePages.dll
             * 在启动的时候,需要注册EncodingProvider,执行代码如下:
             * Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
             */
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            test.PyToolsTest();
            #endregion

            Console.ReadKey();
        }
    }
}
