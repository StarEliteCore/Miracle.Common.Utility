using Miraclesoft.Common.Utility.Exceptions;
using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Miraclesoft.Common.Utility.Serialization
{
    /// <summary>
    /// XML序列化工具
    /// </summary>
    public static class XmlSerializerTool
    {
        #region XML序列化
        /// <summary>
        /// 文本化XML序列化
        /// </summary>
        /// <param name="item">对象</param>
        public static string ToXml<T>(T item)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(item.GetType());
                StringBuilder sb = new StringBuilder();
                using (XmlWriter writer = XmlWriter.Create(sb))
                {
                    serializer.Serialize(writer, item);
                    return sb.ToString();
                }
            }
            catch (Exception ex)
            {
                throw new SerializerException("XML序列化异常!", ex);
            }
        }

        /// <summary>
        /// 文本化XML反序列化
        /// </summary>
        /// <param name="str">字符串序列</param>
        public static T FromXml<T>(string str)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                using (XmlReader reader = new XmlTextReader(new StringReader(str)))
                {
                    return (T)serializer.Deserialize(reader);
                }
            }
            catch (Exception ex)
            {
                throw new SerializerException("XML反序列化异常!", ex);
            }
            #endregion
        }
    }
}
