using System;

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
            Console.ReadKey();
        }
    }
}
