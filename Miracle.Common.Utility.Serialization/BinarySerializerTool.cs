using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace Miracle.Common.Utility.Serialization
{
    /// <summary>
    /// Binary序列化工具
    /// </summary>
    public static class BinarySerializerTool
    {
        #region BinaryFormatter序列化
        /// <summary>
        /// BinaryFormatter序列化
        /// </summary>
        /// <param name="item">对象</param>
        public static string ToBinary<T>(T item)
        {
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                using (MemoryStream ms = new MemoryStream())
                {
                    formatter.Serialize(ms, item);
                    ms.Position = 0;
                    byte[] bytes = ms.ToArray();
                    StringBuilder sb = new StringBuilder();
                    foreach (byte bt in bytes)
                    {
                        _ = sb.Append(string.Format("{0:X2}", bt));
                    }
                    return sb.ToString();
                }
            }
            catch(Exception ex)
            {
                throw new SerializerException("Binary序列化异常", ex);
            }
        }

        /// <summary>
        /// BinaryFormatter反序列化
        /// </summary>
        /// <param name="str">字符串序列</param>
        public static T FromBinary<T>(string str)
        {
            try
            {
                int intLen = str.Length / 2;
                byte[] bytes = new byte[intLen];
                for (int i = 0; i < intLen; i++)
                {
                    int ibyte = Convert.ToInt32(str.Substring(i * 2, 2), 16);
                    bytes[i] = (byte)ibyte;
                }
                BinaryFormatter formatter = new BinaryFormatter();
                using (MemoryStream ms = new MemoryStream(bytes))
                {
                    return (T)formatter.Deserialize(ms);
                }
            }
            catch (Exception ex)
            {
                throw new SerializerException("Binary反序列化异常", ex);
            }
        }
        #endregion
    }
}
