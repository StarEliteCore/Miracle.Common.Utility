using System;
using System.Linq;

namespace Miraclesoft.Common.Utility.Array
{
    /// <summary>
    /// 数组扩展
    /// </summary>
    public static class ArrayExtension
    {
        /// <summary>
        /// 获取数组中随机的一个数
        /// </summary>
        /// <typeparam name="T">数组对象类型</typeparam>
        /// <param name="array">数组对象</param>
        /// <returns>随机返回数组中的一个对象</returns>
        public static T GetRandom<T>(this T[] array)
        {
            if (array == null || array.Length == 0)
                return default(T);
            Random random = new Random();
            return array[random.Next(0, array.Length)];
        }

        /// <summary>
        /// 获取数组的子数组
        /// </summary>
        /// <typeparam name="T">数组对象类型</typeparam>
        /// <param name="array">数组对象</param>
        /// <param name="startIndex">起始位置</param>
        /// <param name="length">子数组长度,若是长度大于起始位置至末位元素数量,返回起始元素至末位元素子数组</param>
        /// <returns>子数组对象</returns>
        public static T[] SubArray<T>(this T[] array, int startIndex, int length = -1)
        {
            if (length == -1 || length - 1 >= array.Length - 1 - startIndex)
                return array.Skip(startIndex).ToArray();
            return array.Skip(startIndex).Take(length).ToArray();
        }
    }
}
