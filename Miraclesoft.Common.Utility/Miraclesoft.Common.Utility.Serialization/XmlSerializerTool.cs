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
                var serializer = new XmlSerializer(item.GetType());
                var sb = new StringBuilder();
                using (var xmlwriter = XmlWriter.Create(sb))
                {
                    serializer.Serialize(xmlwriter, item);
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
                var serializer = new XmlSerializer(typeof(T));
                using (var reader = new XmlTextReader(new StringReader(str)))
                {
                    return (T)serializer.Deserialize(reader);
                }
            }
            catch (Exception ex)
            {
                throw new SerializerException("XML反序列化异常!", ex);
            }
        }

        /// <summary>
        /// 格式化XML字符串
        /// </summary>
        /// <param name="xmlstring">XML字符串</param>
        public static string FormatXML(string xmlstring)
        {
            try
            {
                using (var sw = new StringWriter())
                {
                    var xmlTextWriter = new XmlTextWriter(sw)
                    {
                        Indentation = 2, // 首行缩进
                        Formatting = Formatting.Indented
                    };
                    using (var writer = xmlTextWriter)
                    {
                        var doc = new XmlDocument();
                        doc.LoadXml(xmlstring);
                        doc.WriteContentTo(writer);
                    }
                    // 输出格式化后的XML字符串
                    return sw.ToString();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
