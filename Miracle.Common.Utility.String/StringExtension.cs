using System;
using System.Collections.Specialized;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace Miracle.Common.Utility.String
{
    /// <summary>
    /// 字符串String扩展
    /// </summary>
    public static class StringExtension
    {
        #region 重复字符串
        /// <summary>
        /// 将指定字符串，按照串联的方式重复一定次数。
        /// </summary>
        /// <param name="value">要重复的字符串。</param>
        /// <param name="count">重复的次数。</param>
        /// <returns>字符串value重复count次后的串联字符串。</returns>
        public static string ReplicateString(this string value, int count) => string.Join(value, new string[count + 1]);
        /// <summary>
        /// 将指定字符，按照串联的方式重复一定次数。
        /// </summary>
        /// <param name="c">要重复的字符。</param>
        /// <param name="count">重复的次数。</param>
        /// <returns>字符c重复count次后的串联字符串。</returns>
        public static string ReplicateString(this char c, int count) => new string(c, count);
        #endregion

        #region 字符串转为日期
        /// <summary>
        /// 将格式化日期串转化为相应的日期。
        /// （比如2004/05/06，2004-05-06 12:00:03，12:23:33.333等。）
        /// </summary>
        /// <param name="value">日期格式化串。</param>		
        /// <returns>转换后的日期，对于不能转化的返回DateTime.MinValue。</returns>
        public static DateTime ToDateTime(this string value) => ToDateTime(value, DateTime.MinValue);
        /// <summary>
        /// 将格式化日期串转化为相应的日期。
        /// （比如2004/05/06，2004-05-06 12:00:03，12:23:33.333等。）
        /// </summary>
        /// <param name="value">日期格式化串。</param>
        /// <param name="defaultValue">当为空或错误时的返回日期。</param>
        /// <returns>转换后的日期。</returns>
        public static DateTime ToDateTime(this string value, DateTime defaultValue)
        {
            try
            {
                return string.IsNullOrEmpty(value) || DateTime.TryParse(value, out defaultValue) ? defaultValue : defaultValue;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion

        #region 字符串数组转换成字符串集合。
        /// <summary>
        /// 字符串数组转换成字符串集合。
        /// </summary>
        /// <param name="value">需要转化为字符串集合的数组。</param>
        /// <returns>转化后的字符串集合，如果传入数组为null则返回空集合。</returns>
        public static StringCollection ToStringCollection(this string[] value)
        {
            try
            {
                var strColl = new StringCollection();
                if (value != null)
                {
                    strColl.AddRange(value);
                }
                return strColl;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion

        #region 以特定字符间隔的字符串转化为字符串集合

        /// <summary>
        /// 以特定字符间隔的字符串转化为字符串集合
        /// </summary>
        /// <param name="value">需要处理的字符串</param>
        /// <param name="separator">分隔此实例中子字符串的 Unicode 字符</param>
        /// <returns>转化后的字符串集合，如果传入数组为null则返回空集合</returns>
        public static StringCollection ToStringCollection(this string value, char separator)
        {
            try
            {
                var strColl = new StringCollection();
                return value == null ? strColl : value.ToStringCollection(separator.ToString());
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        #endregion

        #region 以特定字符间隔的字符串转化为字符串集合。
        /// <summary>
        /// 以特定字符间隔的字符串转化为字符串集合。
        /// </summary>
        /// <param name="value">需要处理的字符串。</param>
        /// <param name="separator">分隔此实例中子字符串。</param>
        /// <returns>转化后的字符串集合，如果传入数组为null则返回空集合。</returns>
        public static StringCollection ToStringCollection(this string value, string separator)
        {
            try
            {
                var col = new StringCollection();
                if (string.IsNullOrEmpty(separator) || string.IsNullOrEmpty(value) || string.IsNullOrEmpty(value.Trim()))
                {
                    return col;
                }
                int index = 0;
                int pos = 0;
                int len = separator.Length;
                while (pos >= 0)
                {
                    pos = value.IndexOf(separator, index, StringComparison.CurrentCultureIgnoreCase);
                    _ = pos >= 0 ? col.Add(value.Substring(index, pos - index)) : col.Add(value.Substring(index));
                    index = pos + len;
                }
                return col;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion

        //#region Josn反序列化将Json字符串转为对象
        ///// <summary>
        ///// Json反序列化,用于接收客户端Json后生成对应的对象。
        ///// </summary>
        //public static T JsonToObject<T>(this string value)
        //{
        //    try
        //    {
        //        var type = typeof(T);
        //        var tReturn = type.Assembly.CreateInstance(type.FullName);
        //        try
        //        {
        //            tReturn = JsonConvert.DeserializeObject<T>(value);
        //        }
        //        catch { }
        //        return (T)tReturn;
        //    }
        //    catch (Exception e)
        //    {
        //        throw e;
        //    }
        //}
        //#endregion

        #region 将字符串中的单词首字母大写或者小写
        /// <summary>
        /// 将字符串中的单词首字母大写。
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToTitleUpperCase(this string value)
        {
            try
            {
                var regex = new Regex(@"\w+");
                return regex.Replace(value,
                    delegate (Match m)
                    {
                        string str = m.ToString();
                        return char.IsLower(str[0])
                            ? char.ToUpper(str[0], System.Globalization.CultureInfo.CurrentCulture) + str.Substring(1, str.Length - 1)
                            : str;
                    });
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// 将字符串中的单词首字母小写。
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToTitleLowerCase(this string value)
        {
            try
            {
                var regex = new Regex(@"\w+");
                return regex.Replace(value,
                    delegate (Match m)
                    {
                        string str = m.ToString();
                        return char.IsUpper(str[0])
                            ? char.ToLower(str[0], System.Globalization.CultureInfo.CurrentCulture) + str.Substring(1, str.Length - 1)
                            : str;
                    });
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion

        #region 将字符串转为整数,数组,内存流,GUID(GUID需要字符串本身为GUID格式)
        /// <summary>
        /// 将字符串值转换为整数。
        /// </summary>
        /// <param name="value">字符串值。</param>
        /// <returns>整数值，转换不成功返回0。</returns>
        public static int ToInt(this string value)
        {
            try
            {
                return Convert.ToInt32(value);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// 将以逗号分隔的字符串转换为字符串数组。
        /// </summary>
        /// <param name="value">要转换的值。</param>
        /// <returns>字符串数组。</returns>
        public static string[] ToArray(this string value) => ToArray(value, ",");

        /// <summary>
        ///  将以指定分隔符分隔的字符串转换为字符串数组。
        /// </summary>
        /// <param name="value">要转换的值。</param>
        /// <param name="split">分隔符(如果为空则默认为逗号)。</param>
        /// <returns></returns>
        public static string[] ToArray(this string value, string split) => value.Split(split.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

        /// <summary>
        /// 将字符串转化为内存字节流。
        /// </summary>
        /// <param name="value">需转换的字符串。</param>
        /// <param name="encoding">编码类型。</param>
        /// <returns>字节流。</returns>
        public static MemoryStream ToStream(this string value, Encoding encoding)
        {
            try
            {
                using (var mStream = new MemoryStream())
                {
                    byte[] data = encoding.GetBytes(value);
                    mStream.Write(data, 0, data.Length);
                    mStream.Position = 0;
                    return mStream;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// 将字符串转化为内存字节流。
        /// </summary>
        /// <param name="value">需转换的字符串。</param>
        /// <param name="charset">字符集代码。</param>
        /// <returns>字节流。</returns>
        public static MemoryStream ToStream(this string value, string charset) => ToStream(value, Encoding.GetEncoding(charset));

        /// <summary>
        /// 将字符串以默认编码转化为内存字节流。
        /// </summary>
        /// <param name="value">需转换的字符串。</param>
        /// <returns>字节流。</returns>
        public static MemoryStream ToStream(this string value) => ToStream(value, Encoding.Default);

        /// <summary>
        /// 将字符串拆分为数组。
        /// </summary>
        /// <param name="value">需转换的字符串。</param>
        /// <param name="separator">分割符</param>
        /// <returns>字符串数组</returns>
        public static string[] Split(this string value, string separator)
        {
            try
            {
                var collection = value.ToStringCollection(separator);
                string[] vs = new string[collection.Count];
                collection.CopyTo(vs, 0);
                return vs;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// 将字符串转换为GUID
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Guid ToGuid(this string value)
        {
            try
            {
                return new Guid(value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Base64-String互转
        /// <summary>
        /// 将字符串转换成Base64字符串
        /// </summary>
        /// <param name="value">字符串</param>
        /// <returns></returns>
        public static string StringToBase64(this string value)
        {
            try
            {
                byte[] byteArray = Encoding.Default.GetBytes(value);
                //先转成byte[];
                return Convert.ToBase64String(byteArray);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        /// <summary>
        /// 将Base64字符转成String
        /// </summary>
        /// <param name="value">Base64字符串</param>
        /// <returns></returns>
        public static string Base64ToString(this string value)
        {
            try
            {
                byte[] byteArray = Convert.FromBase64String(value);
                return Encoding.Default.GetString(byteArray);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion

        #region 字符串插入指定分隔符
        /// <summary>
        /// 字符串插入指定分隔符
        /// </summary>
        /// <param name="text">字符串</param>
        /// <param name="spacingString">分隔符</param>
        /// <param name="spacingIndex">隔多少个字符插入分隔符</param>
        /// <returns></returns>
        public static string Spacing(this string text, string spacingString, int spacingIndex)
        {
            try
            {
                var sb = new StringBuilder(text);
                for (int i = spacingIndex; i <= sb.Length; i += spacingIndex + 1)
                {
                    if (i >= sb.Length) break;
                    _ = sb.Insert(i, spacingString);
                }
                return sb.ToString();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion

        #region 半角全角相互转换
        /// <summary>
        /// 转全角的函数(SBC case)
        /// </summary>
        /// <param name="input">需要转换的字符串</param>
        /// <returns>转换为全角的字符串</returns>
        public static string ToSBC(this string input)
        {
            try
            {
                //半角转全角：
                char[] c = input.ToCharArray();
                for (int i = 0; i < c.Length; i++)
                {
                    if (c[i] == 32)
                    {
                        c[i] = (char)12288;
                        continue;
                    }
                    if (c[i] < 127) c[i] = (char)(c[i] + 65248);
                }
                return new string(c);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        ///  转半角的函数(SBC case)
        /// </summary>
        /// <param name="input">需要转换的字符串</param>
        /// <returns>转换为半角的字符串</returns>
        public static string ToDBC(this string input)
        {
            try
            {
                char[] c = input.ToCharArray();
                for (int i = 0; i < c.Length; i++)
                {
                    if (c[i] == 12288)
                    {
                        c[i] = (char)32;
                        continue;
                    }
                    if (c[i] > 65280 && c[i] < 65375) c[i] = (char)(c[i] - 65248);
                }
                return new string(c);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion

        #region 检查一个字符串是否是纯数字构成的，一般用于查询字符串参数的有效性验证
        /// <summary>
        /// 检查一个字符串是否是纯数字构成的,一般用于查询字符串参数的有效性验证
        /// </summary>
        /// <param name="value">需验证的字符串</param>
        /// <returns>是否合法的bool值。</returns>
        public static bool IsNumber(this string value)
        {
            try
            {
                return QuickValidate(value, @"^\d+$");
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion

        #region 快速验证一个字符串是否符合指定的正则表达式
        /// <summary>
        /// 快速验证一个字符串是否符合指定的正则表达式
        /// </summary>
        /// <param name="value">需验证的字符串</param>
        /// <param name="express">正则表达式的内容</param>
        /// <returns>是否合法的bool值。</returns>
        public static bool QuickValidate(this string value, string express)
        {
            try
            {
                if (value == null | value.Length == 0)
                    return false;
                var myRegex = new Regex(express);
                return myRegex.IsMatch(value);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion

        #region 字符串反转
        /// <summary>
        /// 使用指针的方式反转字符串,该函数会修改原字符串.
        /// </summary>
        /// <param name="value">待反转字符串</param>
        /// <returns>反转后的结果</returns>
        public static unsafe string ReverseByPointer(this string value)
        {
            fixed (char* pText = value)
            {
                var pStart = pText;
                var pEnd = pText + value.Length - 1;
                //for (var i = original.Length / 2; i > 0; i--)
                //{
                //    var temp = *pStart;
                //    *pStart++ = *pEnd;
                //    *pEnd-- = temp;
                //    ++forcount;
                //}
                while (pStart < pEnd)
                {
                    var temp = *pStart;
                    *pStart++ = *pEnd;
                    *pEnd-- = temp;
                }
                return value;
            }
        }
        /// <summary>
        /// 使用StringBuilder和String索引器的方式反转字符串,该函数不会修改原字符串
        /// </summary>
        /// <param name="value">待反转字符串</param>
        /// <returns>反转后的结果</returns>
        public static string ReverseByStringBuilder(this string value)
        {
            var sb = new StringBuilder(capacity: value.Length);
            for (int i = value.Length; i > 0;)
            {
                _ = sb.Append(value[--i]);
            }
            return sb.ToString();
        }
        /// <summary>
        /// 使用Array.Reverse()的方式反转字符串,该函数不会修改原字符串
        /// </summary>
        /// <param name="value">待反转字符串</param>
        /// <returns>反转后的结果</returns>
        public static string ReverseByArray(this string value)
        {
            char[] arr = value.ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
        }
        #endregion
    }
}
