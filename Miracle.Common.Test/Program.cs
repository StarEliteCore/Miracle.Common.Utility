using System;

namespace Miracle.Common.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Test.SerializerTest();
            Test.SecurityExtensionTest();

            try
            {
                //使用VSCode调试代码的时候ReadKey会抛出异常
                _ = Console.ReadKey();
            }
            catch { }
        }
    }
}
