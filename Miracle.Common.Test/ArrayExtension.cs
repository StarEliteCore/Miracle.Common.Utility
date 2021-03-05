using Miracle.Common.Utility.Array;
using System;
using static System.Console;

namespace Miracle.Common.Test
{
    public static partial class Test
    {
        /// <summary>
        /// 数组扩展函数测试
        /// </summary>
        public static void ArrayExtensionTest()
        {
            WriteLine();
            WriteColorText("ArrayExtensionTest", ConsoleColor.Green);
            WriteColorText($@"--------------------------------------------------------------------------------------------------------------------", ConsoleColor.Yellow);
            int[] testArray = { 10, 23, 45, 67, 56, 45635, 245, 15, 34556, 5756, 14, 57, 854, 57, 8909, 54, 36, 678, 2, 32, 34, 5, 56, 645, 79 };
            Write("测试数组的长度:");
            WriteColorText($"{ testArray.Length}", ConsoleColor.Magenta);
            Write($"测试数组:");
            WriteColorText($"{FormateInt(testArray)}", ConsoleColor.Yellow);
            Write("获取数组中随机的一个数,第一次:");
            WriteColorText($"{ testArray.GetRandom()}", ConsoleColor.Magenta);
            Write("获取数组中随机的一个数,第二次:");
            WriteColorText($"{ testArray.GetRandom()}", ConsoleColor.Magenta);
            Write("获取数组中随机的一个数,第三次:");
            WriteColorText($"{ testArray.GetRandom()}", ConsoleColor.Magenta);
            WriteColorText("[说明:]", ConsoleColor.DarkRed, false);
            WriteColorText("为表达方便,这里说说的第1,2,3,4,5个数在数组中表示数组索引为1,2,3,4,5其中数组索引从0开始.", ConsoleColor.DarkYellow);
            WriteLine("获取数组的子数组,取8到末位.");
            WriteColorText($"{FormateInt(testArray.SubArray(8))}", ConsoleColor.Magenta);
            WriteLine("获取数组的子数组,取5到15.");
            WriteColorText($"{FormateInt(testArray.SubArray(5, 10))}", ConsoleColor.Magenta);
            WriteLine("获取数组的子数组,取15到25.");
            WriteColorText($"{FormateInt(testArray.SubArray(15, 10))}", ConsoleColor.Magenta);
            WriteLine("获取数组的子数组,取20到26.");
            WriteColorText($"{FormateInt(testArray.SubArray(20, 6))}", ConsoleColor.Magenta);
            WriteLine("测试数组添加新元素,测试单个元素, 90 :");
            testArray = testArray.Push(90);
            WriteColorText($"{ FormateInt(testArray)}", ConsoleColor.Magenta);
            WriteLine("测试数组添加新元素,测试多个元素, {90, 80, 70} :");
            testArray = testArray.PushRange(new int[] { 90, 80, 70 });
            WriteColorText($"{ FormateInt(testArray)}", ConsoleColor.Magenta);
            WriteLine("测试数组删除最后一个元素:");
            var temp = testArray.Pop();
            testArray = temp.Item2;
            WriteColorText($"{ FormateInt(testArray)}", ConsoleColor.Magenta);
            WriteColorText($"删除元素为: { temp.Item1}", ConsoleColor.Red);
            WriteLine();
            WriteColorText($@"--------------------------------------------------------------------------------------------------------------------", ConsoleColor.Yellow);
            WriteColorText("ArrayExtensionTest Complete", ConsoleColor.Green);
            WriteLine();
        }
    }
}
