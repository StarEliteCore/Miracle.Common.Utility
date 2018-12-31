using Newtonsoft.Json;
using System;
using System.Collections.Specialized;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace Miraclesoft.Common.Utility.String
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

        #region 计算输入数据的MD5哈希值
        /// <summary>
        /// 使用加密服务提供程序(CSP)计算输入数据的MD5哈希值。
        /// </summary>
        /// <param name="value">要加密的字符串。</param>
        /// <returns>经过MD5加密的字符串。</returns>
        public static string ToMD5(this string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return value;
            }
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] byteValue = null;
            byte[] byteHash = null;
            byteValue = Encoding.UTF8.GetBytes(value);
            byteHash = md5.ComputeHash(byteValue);
            md5.Clear();
            string strTemp = "";
            for (int i = 0; i < byteHash.Length; i++)
            {
                strTemp += byteHash[i].ToString("X", System.Globalization.CultureInfo.CurrentCulture).PadLeft(2, '0');
            }
            return strTemp.ToLower();
        }
        #endregion

        #region 计算输入数据的SHA1哈希值
        /// <summary>
        /// 使用加密服务提供程序(CSP)计算输入数据的SHA1哈希值
        /// </summary>
        /// <param name="value">要加密的字符串</param>
        /// <returns>经过SHA1加密后的字符串</returns>
        public static string ToSHA1(this string value)
        {
            SHA1 sha1 = new SHA1CryptoServiceProvider();
            byte[] bytes_sha1_in = Encoding.Default.GetBytes(value);
            byte[] bytes_sha1_out = sha1.ComputeHash(bytes_sha1_in);
            return BitConverter.ToString(bytes_sha1_out);
        }
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
            if (string.IsNullOrEmpty(value))
            {
                return defaultValue;
            }
            if (DateTime.TryParse(value, out defaultValue))
            {
                return defaultValue;
            }
            else
            {
                return defaultValue;
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
            StringCollection strColl = new StringCollection();
            if (value != null)
            {
                strColl.AddRange(value);
            }
            return strColl;
        }
        #endregion

        #region 以特定字符间隔的字符串转化为字符串集合。
        /// <summary>
        /// 以特定字符间隔的字符串转化为字符串集合。
        /// </summary>
        /// <param name="value">需要处理的字符串。</param>
        /// <param name="separator">分隔此实例中子字符串的 Unicode 字符。</param>
        /// <returns>转化后的字符串集合，如果传入数组为null则返回空集合。</returns>
        public static StringCollection ToStringCollection(this string value, char separator)
        {
            StringCollection strColl = new StringCollection();
            if (value == null)
            {
                return strColl;
            }
            return value.ToStringCollection(separator.ToString());
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
            StringCollection col = new StringCollection();
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
                if (pos >= 0)
                {
                    col.Add(value.Substring(index, pos - index));
                }
                else
                {
                    col.Add(value.Substring(index));
                }
                index = pos + len;
            }
            return col;
        }
        #endregion

        /// <summary>
        /// Json反序列化,用于接收客户端Json后生成对应的对象。
        /// </summary>
        public static T JsonToObject<T>(this string value)
        {
            var type = typeof(T);
            var tReturn = type.Assembly.CreateInstance(type.FullName);
            try
            {
                tReturn = JsonConvert.DeserializeObject<T>(value);
            }
            catch { }
            return (T)tReturn;
        }

        /// <summary>
        /// 将字符串中的单词首字母大写。
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToTitleUpperCase(this string value)
        {
            Regex regex = new Regex(@"\w+");
            return regex.Replace(value,
                delegate (Match m)
                {
                    string str = m.ToString();
                    if (char.IsLower(str[0]))
                    {
                        return char.ToUpper(str[0], System.Globalization.CultureInfo.CurrentCulture) + str.Substring(1, str.Length - 1);
                    }
                    return str;
                });
        }

        /// <summary>
        /// 将字符串中的单词首字母小写。
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToTitleLowerCase(this string value)
        {
            Regex regex = new Regex(@"\w+");
            return regex.Replace(value,
                delegate (Match m)
                {
                    string str = m.ToString();
                    if (char.IsUpper(str[0]))
                    {
                        return char.ToLower(str[0], System.Globalization.CultureInfo.CurrentCulture) + str.Substring(1, str.Length - 1);
                    }
                    return str;
                });
        }

        /// <summary>
        /// 将字符串值转换为整数。
        /// </summary>
        /// <param name="value">字符串值。</param>
        /// <returns>整数值，转换不成功返回0。</returns>
        public static int ToInt(this string value)
        {
            int returnValue = 0;
            try
            {
                returnValue = Convert.ToInt32(value);
            }
            catch
            { }
            return returnValue;
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
            MemoryStream mStream = new MemoryStream();
            byte[] data = encoding.GetBytes(value);
            mStream.Write(data, 0, data.Length);
            mStream.Position = 0;
            return mStream;
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
            StringCollection collection = value.ToStringCollection(separator);
            string[] vs = new string[collection.Count];
            collection.CopyTo(vs, 0);
            return vs;
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
                throw new Exception("输入的字符串无法转化为GUID对象", ex);
            }
        }

        /// <summary>
        /// 将字符串转换成Base64字符串
        /// </summary>
        /// <param name="value">字符串</param>
        /// <returns></returns>
        public static string StringToBase64(this string value)
        {
            byte[] byteArray = Encoding.Default.GetBytes(value);
            //先转成byte[];
            return Convert.ToBase64String(byteArray);
        }
        /// <summary>
        /// 将Base64字符转成String
        /// </summary>
        /// <param name="value">Base64字符串</param>
        /// <returns></returns>
        public static string Base64ToString(this string value)
        {
            byte[] byteArray = Convert.FromBase64String(value);
            return Encoding.Default.GetString(byteArray);
        }
        /// <summary>
        /// 字符串插入指定分隔符
        /// </summary>
        /// <param name="text">字符串</param>
        /// <param name="spacingString">分隔符</param>
        /// <param name="spacingIndex">隔多少个字符插入分隔符</param>
        /// <returns></returns>
        public static string Spacing(this string text, string spacingString, int spacingIndex)
        {
            StringBuilder sb = new StringBuilder(text);
            for (int i = spacingIndex; i <= sb.Length; i += spacingIndex + 1)
            {
                if (i >= sb.Length) break;
                sb.Insert(i, spacingString);
            }
            return sb.ToString();
        }

        /// <summary>
        /// 将使用BitConverter转化的字节数组重新转为字节数组
        /// </summary>
        /// <param name="bitstring">字符串,如:"96-F8-79-F4-18-37-D0-BF-B3-15-BE-A5-77-7F-7D-9E-59"</param>
        /// <returns></returns>
        public static byte[] StringToBit(this string bitstring)
        {
            string[] values = bitstring.Split("-");
            var inBytes = new byte[values.Length];
            for (var i = 0; i < values.Length; i++)
            {
                inBytes[i] = (byte)Convert.ToInt32(values[i], 16);
            }
            return inBytes;
        }

        /// <summary>
        /// 对字符串进行DES加密
        /// </summary>
        /// <param name="value">字符串</param>
        /// <param name="vKey">密钥</param>
        /// <returns></returns>
        public static string DESEncrypt(this string value, string vKey = "microsoft",string ivVal="microsoft")
        {
            try
            {
                var des = new DESCryptoServiceProvider()
                {
                    Key = Encoding.ASCII.GetBytes(vKey.ToMD5().Substring(0, 8)),
                    IV = Encoding.ASCII.GetBytes(ivVal.ToMD5().Substring(0, 8))
                };
                var inputByteArray = Encoding.Default.GetBytes(value);
                var desencrypt = des.CreateEncryptor();
                byte[] result = desencrypt.TransformFinalBlock(inputByteArray, 0, inputByteArray.Length);
                return BitConverter.ToString(result);
            }
            catch (Exception ex)
            {
                throw new Exception("加密错误", ex);
            }
        }

        /// <summary>
        /// 对加密字符串进行DES解密
        /// </summary>
        /// <param name="value">被加密的字符串</param>
        /// <param name="vKey">密钥</param>
        /// <returns></returns>
        public static string DESDecrypt(this string value, string vKey = "microsoft",string ivVal = "microsoft")
        {
            try
            {
                var des = new DESCryptoServiceProvider()
                {
                    Key = Encoding.ASCII.GetBytes(vKey.ToMD5().Substring(0, 8)),
                    IV = Encoding.ASCII.GetBytes(ivVal.ToMD5().Substring(0, 8))
                };
                string[] values = value.Split("-");
                var inBytes = new byte[values.Length];
                for (var i = 0; i < values.Length; i++)
                {
                    inBytes[i] = (byte)Convert.ToInt32(values[i], 16);
                }
                var desdecrypt = des.CreateDecryptor();
                byte[] outBlock = desdecrypt.TransformFinalBlock(inBytes, 0, inBytes.Length);
                return Encoding.Default.GetString(outBlock);
            }
            catch (Exception ex)
            {
                throw new Exception("密码错误或其他错误", ex);
            }
        }

        /// <summary>
        /// 超级警告.对字符串进行不可逆DES加密,该加密算法的结果和GUID一样,每一次都不相同.针对制作恶意加密程序可以使用,输出的密码长度为32位MD5码,用解密软件估计也得跑很久,何况每个文件的密码都不一致..
        /// </summary>
        /// <param name="value">字符串</param>
        /// <returns></returns>
        public static string IrreversibleEncrypt(this string value)
        {
            try
            {
                var key = Guid.NewGuid().ToString("N").ToUpper();
                var ivVal = Guid.NewGuid().ToString("N").ToUpper();
                Random rd = new Random();
                var keystart = rd.Next(key.Length - 8);
                var ivstart = rd.Next(ivVal.Length - 8);
                var des = new DESCryptoServiceProvider()
                {
                    Key = Encoding.ASCII.GetBytes(key.Substring(keystart, 8)),
                    IV = Encoding.ASCII.GetBytes(ivVal.Substring(ivstart, 8))
                };
                var inputByteArray = Encoding.Default.GetBytes(value);
                var desencrypt = des.CreateEncryptor();
                byte[] result = desencrypt.TransformFinalBlock(inputByteArray, 0, inputByteArray.Length);
                return BitConverter.ToString(result).ToMD5().ToUpper();
            }
            catch (Exception ex)
            {
                throw new Exception("加密错误", ex);
            }
        }
    }
}
