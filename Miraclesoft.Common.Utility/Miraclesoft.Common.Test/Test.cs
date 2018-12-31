using Miraclesoft.Common.Utility.ChineseLunar;
using Miraclesoft.Common.Utility.DateTimeStamp;
using Miraclesoft.Common.Utility.PinYin;
using Miraclesoft.Common.Utility.RMB;
using Miraclesoft.Common.Utility.Serialization;
using Miraclesoft.Common.Utility.String;
using Newtonsoft.Json;
using System;
using System.Text;
using static System.Console;

namespace Miraclesoft.Common.Test
{
    /// <summary>
    /// 测试类
    /// </summary>
    public class Test
    {
        /// <summary>
        /// RMB工具类测试
        /// </summary>
        public void RMBTest()
        {
            WriteLine("RMB Test:");
            WriteLine("--------------------------------------------------------------------------------------------------------------------");
            WriteLine("数字转中文大写:");
            var rmb_test_number = 1247823234234312648.34m;
            WriteLine($"原始文字:{rmb_test_number}");
            WriteLine(RmbTools.ConvertToChinese(rmb_test_number));

#pragma warning disable  //这个地方会报方法过时,使用这个东西忽略警告.
            WriteLine(RmbTools.NumToChineseStr(12648.34m));//这种方法当数据过大存在溢出风险
#pragma warning restore

            WriteLine("字符串转中文大写:");
            var rmb_test_string = "878343235234853234.56";
            WriteLine($"原始文字:{rmb_test_string}");
            WriteLine(RmbTools.ConvertToChinese(rmb_test_string));
            try
            {
                WriteLine("异常:");
                WriteLine(RmbTools.ConvertToChinese("测试"));
            }
            catch (RmbException ex)
            {
                WriteLine(ex.ToString());
                WriteLine("--------------------------------------------------------------------------------------------------------------------");
            }
            WriteLine("RMBTest complete");
        }

        /// <summary>
        /// DateStampExtensionTest
        /// </summary>
        public void DateStampExtensionTest()
        {
            WriteLine();
            WriteLine("DateStampExtensionTest");
            WriteLine("--------------------------------------------------------------------------------------------------------------------");
            WriteLine("DateTime转13位时间戳:");
            long timestamp_13bit = DateTime.Now.ToUnixTimeStamp_13bit();
            WriteLine($"DateTime:{DateTime.Now}       13bit timestamp:{timestamp_13bit}");
            WriteLine("13位时间转DateTime:");
            WriteLine($"13bit timestamp:{timestamp_13bit} DateTime:{timestamp_13bit.ToDateTime()}");
            WriteLine();
            WriteLine("DateTime转10位时间戳:");
            int timestamp_10bit = DateTime.Now.ToLinuxTimeStamp_10bit();
            WriteLine($"DateTime:{DateTime.Now}       10bit timestamp:{timestamp_10bit}");
            WriteLine("10位时间戳转DateTime:");
            WriteLine($"10bit timestamp:{timestamp_10bit}       DateTime:{timestamp_10bit.ToDateTime()}");
            WriteLine("--------------------------------------------------------------------------------------------------------------------");
            WriteLine("DateStampExtensionTest Complete");
            WriteLine();
        }

        /// <summary>
        /// PyToolsTest
        /// </summary>
        public void PyToolsTest()
        {
            WriteLine();
            WriteLine("PyToolsTest");
            WriteLine("--------------------------------------------------------------------------------------------------------------------");
            string[] maxims = {
                "事常与人违，事总在人为123456789",
                @"骏马是跑出来的，强兵是打出来的?|\!@$%^&*()_+=-,./';:{}[]<>",
                "驾驭命运的舵是奋斗。不抱有一丝幻想，不放弃一点机会,不停止一日努力.",
            };
            string[] medicines = {
                "聚维酮碘溶液",
                "开塞露",
                "sadgsad测试1",
                "输血记录"
            };
            WriteLine("UTF8句子拼音：");
            foreach (var s in maxims)
            {
                WriteLine($"汉字：{s}\n拼音：{PyTools.GetPinYin(s, '%')}\n");
            }
            var GBK = Encoding.GetEncoding("GBK");
            WriteLine("GBK拼音简码：");
            WriteLine("不支持汉字使用自定义符号'%'替代测试:");
            WriteLine($"錒：\n简码：{PyTools.GetInitials("錒", '%', GBK)}\n");
            foreach (var m in medicines)
            {
                WriteLine($"药品：{PyTools.ConvertEncoding(m, Encoding.UTF8, GBK)}\n简码：{PyTools.GetInitials(PyTools.ConvertEncoding(m, Encoding.UTF8, GBK), '测', GBK)}\n");
            }
            WriteLine("--------------------------------------------------------------------------------------------------------------------");
            WriteLine("PyToolsTest Complete");
            WriteLine();
        }

        /// <summary>
        /// 农历测试
        /// </summary>
        public void LunarTest()
        {
            WriteLine();
            WriteLine("LunarTest");
            WriteLine("--------------------------------------------------------------------------------------------------------------------");
            WriteLine($"农历输出年月日.当前系统时间 {DateTime.Now}");
            WriteLine($"年:{ToLunar.LunarYear} 月:{ToLunar.LunarMonth} 日:{ToLunar.LunarDay}");
            WriteLine($"星座:当前系统时间 {DateTime.Now}");
            WriteLine($"星座:{ToLunar.Constellation}");
            WriteLine($"属相:当前系统时间 {DateTime.Now}");
            WriteLine($"属相:{ToLunar.Animal}");
            ToLunar.Init(new DateTime(1994, 11, 15));
            WriteLine($"农历输出年月日:1994-11-15 {ToLunar.ChineseLunar}");
            WriteLine($"年:{ToLunar.LunarYear} 月:{ToLunar.LunarMonth} 日:{ToLunar.LunarDay}");
            WriteLine("星座:1994-11-15");
            WriteLine($"星座:{ToLunar.Constellation}");
            WriteLine("属相:1994-11-15");
            WriteLine($"属相:{ToLunar.Animal}");
            WriteLine("农历输出:当前系统时间");
            ToLunar.Init(DateTime.Now);
            WriteLine(ToLunar.ChineseLunar);
            WriteLine("农历输出:20181120");
            ToLunar.Init("20181120");
            WriteLine(ToLunar.ChineseLunar);
            WriteLine("农历偏移:");
            ToLunar.AddYear(20);
            WriteLine($"增加20年:{ToLunar.ChineseLunar}");
            ToLunar.AddYear(-10);
            WriteLine($"减少10年:{ToLunar.ChineseLunar}");
            ToLunar.AddMonth(13);
            WriteLine($"增加13月:{ToLunar.ChineseLunar}");
            ToLunar.AddMonth(-12);
            WriteLine($"减少12月:{ToLunar.ChineseLunar}");
            ToLunar.AddDay(15);
            WriteLine($"增加15天:{ToLunar.ChineseLunar}");
            ToLunar.AddDay(-12);
            WriteLine($"减少12天:{ToLunar.ChineseLunar}");
            WriteLine("--------------------------------------------------------------------------------------------------------------------");
            WriteLine("LunarTest Complete");
            WriteLine();
        }

        [Serializable]
        public class Student
        {
            public string Name { get; set; }

            public string Sex { get; set; }

            public int Age { get; set; }
            public string ToCmd() => $"姓名:{Name} 性别:{Sex} 年龄:{Age}";
        }

        /// <summary>
        /// 序列化测试
        /// </summary>
        public void SerializerTest()
        {
            WriteLine();
            WriteLine("SerializerTest");
            WriteLine("--------------------------------------------------------------------------------------------------------------------");
            WriteLine($"Xml序列化:");
            Student z_san = new Student
            {
                Name = "张三",
                Sex = "女",
                Age = 23
            };
            var z_san_str = XmlSerializerTool.ToXml(z_san);
            WriteLine(XmlSerializerTool.FormatXML(z_san_str));
            WriteLine("Binary序列化:");
            Student li_si = new Student
            {
                Name = "李四",
                Sex = "男",
                Age = 25
            };
            var li_si_str = BinarySerializerTool.ToBinary(li_si);
            WriteLine(li_si_str);
            WriteLine($"Xml反序列化:");
            var z_s = XmlSerializerTool.FromXml<Student>(z_san_str);
            WriteLine(z_s.ToCmd());
            WriteLine("Binary反序列化:");
            var lis = BinarySerializerTool.FromBinary<Student>(li_si_str);
            WriteLine(lis.ToCmd());
            WriteLine("--------------------------------------------------------------------------------------------------------------------");
            WriteLine("SerializerTest Complete");
            WriteLine();
        }

        /// <summary>
        /// StringExtension测试
        /// </summary>
        public void StringExtensionTest()
        {
            WriteLine();
            WriteLine("StringExtensionTest");
            WriteLine("--------------------------------------------------------------------------------------------------------------------");
            WriteLine("将指定字符串,按照串联的方式重复一定次数.测试值:test");
            WriteLine("test".ReplicateString(2));
            WriteLine();
            WriteLine("将指定字符,按照串联的方式重复一定次数.测试值:t");
            WriteLine("t".ReplicateString(3));
            WriteLine();
            WriteLine("使用加密服务提供程序(CSP)计算输入数据的MD5哈希值.测试值:microsoft");
            WriteLine("microsoft".ToMD5());
            WriteLine();
            WriteLine("使用加密服务提供程序(CSP)计算输入数据的SHA1哈希值.测试值:microsoft");
            WriteLine("microsoft".ToSHA1());
            WriteLine();
            DateTime time = "2019-01-01".ToDateTime();
            WriteLine(time.ToLongDateString());
            WriteLine();
            WriteLine("字符串数组转换成字符串集合.测试数组:{'123sdf','dsgsdg','gf3rgt'}");
            string[] vs = { "123sdf", "dsgsdg", "gf3rgt" };
            WriteLine(vs.ToStringCollection().GetType().ToString());
            WriteLine();
            WriteLine("以特定字符间隔的字符串转化为字符串集合.测试字符串:'dhgausdg,sudygfuasdg,3235sdg'");
            WriteLine("输出转化后的字符串数量:{0}", "dhgausdg,sudygfuasdg,3235sdg".ToStringCollection(',').Count);
            WriteLine();
            WriteLine("以特定字符间隔的字符串转化为字符串集合.测试字符串:'siuhgasidgh12sdgasdhafh12989878ajshgdasd12adgase'");
            WriteLine("输出转化后的字符串数量:{0}", "siuhgasidgh12sdgasdhafh12989878ajshgdasd12adgase".ToStringCollection("12").Count);
            WriteLine();
            WriteLine("Json反序列化,用于接收客户端Json后生成对应的对象");
            Student z_san = new Student
            {
                Name = "张三",
                Sex = "女",
                Age = 23
            };
            string json = JsonConvert.SerializeObject(z_san);
            Student student = json.JsonToObject<Student>();
            student.ToString();
            WriteLine();
            WriteLine("将字符串中的单词首字母大写,测试字符串:'ask结果,司空见惯test,game over'");
            string str = "ask结果,司空见惯test,game over".ToTitleUpperCase();
            WriteLine();
            WriteLine(str);
            WriteLine("将字符串中的单词首字母小写.测试字符串:为上函数转化后的字符串");
            WriteLine(str.ToTitleLowerCase());
            WriteLine();
            WriteLine("将字符串值转换为整数:{0}", "123".ToInt());
            WriteLine();
            WriteLine("将字符串转换为GUID:测试字符串:'936DA01F-9ABD-4d9d-80C7-02AF85C822A8',输出结果:{0}", "936DA01F-9ABD-4d9d-80C7-02AF85C822A8".ToGuid().GetType().ToString());
            WriteLine();
            WriteLine("将字符串转换为GUID异常测试:测试字符串:'Microsoft'");
            try
            {
                WriteLine("Microsoft".ToGuid());
            }
            catch(Exception ex)
            {
                WriteLine(ex.ToString());
            }
            WriteLine();
            string base64str = "Microsoft".StringToBase64();
            WriteLine("将字符串转换成Base64字符串:测试字符串:'Microsoft',输出结果:{0}", base64str);
            WriteLine();
            WriteLine("将Base64字符转成String:测试字符串:'{0}',输出结果:{1}", base64str, base64str.Base64ToString());
            WriteLine();
            WriteLine("字符串插入指定分隔符,隔多少个字符插入分隔符.测试字符串为:'u卡萨丁宫颈癌是独立国家哈桑领导讲话稿按时鉴定会gals的机会格拉斯的结果'");
            WriteLine("每隔4个字符插入一个逗号,输出结果为:{0}", "u卡萨丁宫颈癌是独立国家哈桑领导讲话稿按时鉴定会gals的机会格拉斯的结果".Spacing(",", 4));
            WriteLine();
            WriteLine("对字符串进行加密.测试字符串:'Microsoft love Linux'");
            string encryptstr = "Microsoft love Linux".DESEncrypt("Linux doesn't love Microsoft");
            WriteLine("密匙为:'Linux doesn't love Microsoft'加密结果:{0}", encryptstr);
            WriteLine();
            //WriteLine("大佬的加密算法:{0}", "Microsoft love Linux".Des("Linux doesn't love Microsoft", "Linux doesn't love Microsoft"));
            WriteLine("密匙为:'Linux doesn't love Microsoft'解密结果:{0}", encryptstr.DESDecrypt("Linux doesn't love Microsoft"));
            WriteLine();
            WriteLine("当密匙错误的时候的情况:");
            try
            {
                encryptstr.DESDecrypt("Linux love Microsoft");
            }
            catch(Exception ex)
            {
                WriteLine(ex.ToString());
            }
            WriteLine();
            WriteLine("测试将使用BitConverter转化的字节数组重新转为字节数组,所使用的字符串为上边加密后的字符串");
            byte[] bytes = encryptstr.StringToBit();
            for (var i = 0; i < bytes.Length;i++)
            {
                WriteLine($"第{i}个字节数,其值为:{bytes[i].ToString()}");
            }
            WriteLine();
            WriteLine("测试对字符串进行不可逆DES加密输出结果,测试字符串为:'Microsoft love Linux',输出结果如下:");
            WriteLine("Microsoft love Linux".IrreversibleEncrypt());
            WriteLine();
            WriteLine("--------------------------------------------------------------------------------------------------------------------");
            WriteLine("StringExtensionTest Complete");
            WriteLine();
        }
    }
}
