using Miracle.Common.Utility.Array;
using Miracle.Common.Utility.ChineseLunar;
using Miracle.Common.Utility.DateTimeStamp;
using Miracle.Common.Utility.PinYin;
using Miracle.Common.Utility.RMB;
using Miracle.Common.Utility.Security;
using Miracle.Common.Utility.Serialization;
using Miracle.Common.Utility.String;
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
        /// output text to console by color font,default red color.
        /// </summary>
        /// <param name="ex">异常对象</param>
        /// <param name="wrap">是否换行输出</param>
        public static void WriteColorText(Exception ex, ConsoleColor color = ConsoleColor.Red, bool wrap = true)
        {
            ForegroundColor = color;
            if (wrap) WriteLine(ex.ToString());
            else Write(ex.ToString());
            ForegroundColor = ConsoleColor.White;
        }
        /// <summary>
        /// output text to console by color font,default red color.
        /// </summary>
        /// <param name="ex">字符串类型</param>
        /// <param name="wrap">是否换行输出</param>
        public static void WriteColorText(string ex, ConsoleColor color = ConsoleColor.Red, bool wrap = true)
        {
            ForegroundColor = color;
            if (wrap) WriteLine(ex);
            else Write(ex);
            ForegroundColor = ConsoleColor.White;
        }

        /// <summary>
        /// RMB工具类测试
        /// </summary>
        public static void RMBTest()
        {
            WriteColorText("RMB Test:", ConsoleColor.Green);
            WriteColorText("--------------------------------------------------------------------------------------------------------------------", ConsoleColor.Yellow);
            WriteLine("数字转中文大写:");
            var rmb_test_number = 1247823232352324312648.34m;
            Write($"{rmb_test_number}转为大写:");
            WriteColorText(RmbTools.ConvertToChinese(rmb_test_number), ConsoleColor.Magenta);

#pragma warning disable  //这个地方会报方法过时,使用这个东西忽略警告.
            Write("12648.34m转为大写:");
            WriteColorText(RmbTools.NumToChineseStr(12648.34m), ConsoleColor.Magenta);//这种方法当数据过大存在溢出风险
#pragma warning restore

            WriteLine("字符串转中文大写:");
            var rmb_test_string = "878343235234853234.56";
            Write($"{rmb_test_string}转为大写:");
            WriteColorText(RmbTools.ConvertToChinese(rmb_test_string), ConsoleColor.Magenta);
            try
            {
                WriteColorText("[异常测试:]");
                WriteLine(RmbTools.ConvertToChinese("测试"));
            }
            catch (RmbException ex)
            {
                WriteColorText(ex);
                WriteColorText("--------------------------------------------------------------------------------------------------------------------", ConsoleColor.Yellow);
            }
            WriteColorText("RMBTest complete", ConsoleColor.Green);
        }

        /// <summary>
        /// DateStampExtensionTest
        /// </summary>
        public static void DateStampExtensionTest()
        {
            WriteLine();
            WriteColorText("DateStampExtensionTest", ConsoleColor.Green);
            WriteColorText("--------------------------------------------------------------------------------------------------------------------", ConsoleColor.Yellow);
            WriteLine("DateTime转13位时间戳:");
            long timestamp_13bit = DateTime.Now.ToUnixTimeStamp_13bit();
            WriteLine($"DateTime:{DateTime.Now}");
            Write("13bit timestamp:");
            WriteColorText($"{timestamp_13bit}", ConsoleColor.Magenta);
            WriteLine("13位时间转DateTime:");
            Write("13bit timestamp:");
            WriteColorText($"{timestamp_13bit}", ConsoleColor.Magenta);
            Write("DateTime:");
            WriteColorText($"{ timestamp_13bit.ToDateTime()}", ConsoleColor.Magenta);
            WriteLine();
            WriteLine("DateTime转10位时间戳:");
            int timestamp_10bit = DateTime.Now.ToLinuxTimeStamp_10bit();
            WriteLine($"DateTime:{DateTime.Now}");
            Write("10bit timestamp:");
            WriteColorText($"{timestamp_10bit}", ConsoleColor.Magenta);
            WriteLine("10位时间戳转DateTime:");
            Write("10bit timestamp:");
            WriteColorText($"{timestamp_10bit}", ConsoleColor.Magenta);
            Write("DateTime:");
            WriteColorText($"{timestamp_10bit.ToDateTime()}", ConsoleColor.Magenta);
            WriteColorText("--------------------------------------------------------------------------------------------------------------------", ConsoleColor.Yellow);
            WriteColorText("DateStampExtensionTest Complete", ConsoleColor.Green);
            WriteLine();
        }

        /// <summary>
        /// PyToolsTest
        /// </summary>
        public static void PyToolsTest()
        {
            WriteLine();
            WriteColorText("PyToolsTest", ConsoleColor.Green);
            WriteColorText("--------------------------------------------------------------------------------------------------------------------", ConsoleColor.Yellow);
            string[] maxims = { "事常与人违，123456789", @"骏马是跑出来的，?|\!@$%^&*()_+=-,./';:{}[]<>", "深圳" };
            string[] medicines = { "聚维酮碘溶液", "开塞露", "输血记录", "深圳" };
            WriteLine("UTF8句子拼音：");
            foreach (var s in maxims)
            {
                Write("汉字：");
                WriteColorText($"{s}", ConsoleColor.DarkCyan, false);
                Write("\n拼音：");
                WriteColorText($"{PyTools.GetPinYin(s, '%')}\n", ConsoleColor.Magenta);
            }
            var GBK = Encoding.GetEncoding("GBK");
            WriteLine("GBK拼音简码：");
            WriteColorText("不支持汉字使用自定义符号'%'替代测试:", ConsoleColor.DarkYellow);
            Write("錒：\n简码：");
            WriteColorText($"{PyTools.GetInitials("錒", '%', GBK)}\n", ConsoleColor.Magenta);
            foreach (var m in medicines)
            {
                Write("药品：");
                WriteColorText($"{PyTools.ConvertEncoding(m, Encoding.UTF8, GBK)}\n", ConsoleColor.Magenta, false);
                Write("简码：");
                WriteColorText($"{ PyTools.GetInitials(PyTools.ConvertEncoding(m, Encoding.UTF8, GBK), '?', GBK)}\n", ConsoleColor.Magenta);
            }
            WriteColorText("--------------------------------------------------------------------------------------------------------------------", ConsoleColor.Yellow);
            WriteColorText("PyToolsTest Complete", ConsoleColor.Green);
            WriteLine();
        }

        /// <summary>
        /// 农历测试
        /// </summary>
        public static void LunarTest()
        {
            WriteLine();
            WriteColorText("LunarTest", ConsoleColor.Green);
            WriteColorText("--------------------------------------------------------------------------------------------------------------------", ConsoleColor.Yellow);
            WriteLine($"农历输出年月日.当前系统时间 {DateTime.Now}");
            Write("年:");
            WriteColorText($"{ToLunar.LunarYear}", ConsoleColor.Magenta, false);
            Write("月:");
            WriteColorText($"{ ToLunar.LunarMonth}", ConsoleColor.Magenta, false);
            Write("日:");
            WriteColorText($"{ ToLunar.LunarDay}", ConsoleColor.Magenta);
            WriteLine($"星座:当前系统时间 {DateTime.Now}");
            Write("星座:");
            WriteColorText($"{ToLunar.Constellation}", ConsoleColor.Magenta);
            Write("属相:");
            WriteColorText($"{ToLunar.Animal}", ConsoleColor.Magenta);
            ToLunar.Init(new DateTime(1994, 11, 15));
            Write($"农历输出年月日:1994-11-15");
            WriteColorText($" {ToLunar.ChineseLunar}", ConsoleColor.Magenta);
            Write("年:");
            WriteColorText($"{ToLunar.LunarYear}", ConsoleColor.Magenta, false);
            Write("月:");
            WriteColorText($"{ ToLunar.LunarMonth}", ConsoleColor.Magenta, false);
            Write("日:");
            WriteColorText($"{ ToLunar.LunarDay}", ConsoleColor.Magenta);
            WriteLine("星座:1994-11-15");
            Write("星座:");
            WriteColorText($"{ToLunar.Constellation}", ConsoleColor.Magenta);
            Write("属相:");
            WriteColorText($"{ToLunar.Animal}", ConsoleColor.Magenta);
            WriteLine("农历输出:当前系统时间");
            ToLunar.Init(DateTime.Now);
            WriteColorText(ToLunar.ChineseLunar, ConsoleColor.Magenta);
            WriteLine("农历输出:20181120");
            ToLunar.Init("20181120");
            WriteColorText(ToLunar.ChineseLunar, ConsoleColor.Magenta);
            WriteColorText("农历偏移:", ConsoleColor.Blue);
            ToLunar.AddYear(20);
            Write("增加20年:");
            WriteColorText($"{ToLunar.ChineseLunar}", ConsoleColor.Magenta);
            ToLunar.AddYear(-10);
            Write("减少10年:");
            WriteColorText($"{ToLunar.ChineseLunar}", ConsoleColor.Magenta);
            ToLunar.AddMonth(13);
            Write("增加13月:");
            WriteColorText($"{ToLunar.ChineseLunar}", ConsoleColor.Magenta);
            ToLunar.AddMonth(-12);
            Write("减少12月:");
            WriteColorText($"{ToLunar.ChineseLunar}", ConsoleColor.Magenta);
            ToLunar.AddDay(15);
            Write("增加15天:");
            WriteColorText($"{ToLunar.ChineseLunar}", ConsoleColor.Magenta);
            ToLunar.AddDay(-12);
            Write("减少12天:");
            WriteColorText($"{ToLunar.ChineseLunar}", ConsoleColor.Magenta);
            WriteColorText("--------------------------------------------------------------------------------------------------------------------", ConsoleColor.Yellow);
            WriteColorText("LunarTest Complete", ConsoleColor.Green);
            WriteLine();
        }

        [Serializable]
        public class Student
        {
            public string Name { get; set; }

            public string Sex { get; set; }

            public int Age { get; set; }
            /// <summary>
            /// 将对象的姓名,性别,年龄信息输出到控制台
            /// </summary>
            public void ToConsole()
            {
                Write("姓名:");
                WriteColorText($"{Name}", ConsoleColor.Cyan, false);
                Write("性别:");
                WriteColorText($"{Sex}", ConsoleColor.Cyan, false);
                Write("年龄:");
                WriteColorText($"{Age}", ConsoleColor.Cyan);
            }
            private static void WriteColorText(string ex, ConsoleColor color = ConsoleColor.Red, bool wrap = true)
            {
                ForegroundColor = color;
                if (wrap) WriteLine(ex);
                else Write(ex);
                ForegroundColor = ConsoleColor.White;
            }
        }

        /// <summary>
        /// 序列化测试
        /// </summary>
        public static void SerializerTest()
        {
            WriteLine();
            WriteColorText("SerializerTest", ConsoleColor.Green);
            WriteColorText("--------------------------------------------------------------------------------------------------------------------", ConsoleColor.Yellow);
            WriteLine($"Xml序列化:");
            Student z_san = new Student
            {
                Name = "张三",
                Sex = "女",
                Age = 23
            };
            var z_san_str = XmlSerializerTool.ToXml(z_san);
            WriteColorText(XmlSerializerTool.FormatXML(z_san_str), ConsoleColor.Magenta);
            WriteLine("Binary序列化:");
            Student li_si = new Student
            {
                Name = "李四",
                Sex = "男",
                Age = 25
            };
            var li_si_str = BinarySerializerTool.ToBinary(li_si);
            WriteColorText(li_si_str, ConsoleColor.Magenta);
            WriteLine($"Xml反序列化:");
            var z_s = XmlSerializerTool.FromXml<Student>(z_san_str);
            z_s.ToConsole();
            WriteLine("Binary反序列化:");
            var lis = BinarySerializerTool.FromBinary<Student>(li_si_str);
            lis.ToConsole();
            WriteColorText("--------------------------------------------------------------------------------------------------------------------", ConsoleColor.Yellow);
            WriteColorText("SerializerTest Complete", ConsoleColor.Green);
            WriteLine();
        }

        /// <summary>
        /// StringExtension测试
        /// </summary>
        public static void StringExtensionTest()
        {
            WriteLine();
            WriteColorText("StringExtensionTest", ConsoleColor.Green);
            WriteColorText("--------------------------------------------------------------------------------------------------------------------", ConsoleColor.Yellow);
            Write("将指定字符串,按照串联的方式重复一定次数.测试值:test,重复两次:");
            WriteColorText("test".ReplicateString(2), ConsoleColor.Magenta);
            WriteLine();
            Write("将指定字符,按照串联的方式重复一定次数.测试值:t,重复三次:");
            WriteColorText("t".ReplicateString(3), ConsoleColor.Magenta);
            WriteLine();
            Write("日期字符串转化为日期对象:");
            DateTime time = "2019-01-01".ToDateTime();
            WriteColorText(time.ToLongDateString(), ConsoleColor.Magenta);
            WriteLine();
            WriteLine("字符串数组转换成字符串集合.测试数组:{'123sdf','dsgsdg','gf3rgt'}");
            string[] vs = { "123sdf", "dsgsdg", "gf3rgt" };
            WriteColorText(vs.ToStringCollection().GetType().ToString(), ConsoleColor.Magenta);
            WriteLine();
            WriteLine("以特定字符间隔的字符串转化为字符串集合.测试字符串:'dhgausdg,sudygfuasdg,3235sdg'");
            Write("以','为间隔符,输出转化后的字符串数量:");
            WriteColorText($"{"dhgausdg, sudygfuasdg, 3235sdg".ToStringCollection(',').Count}", ConsoleColor.Magenta);
            WriteLine();
            WriteLine("以特定字符间隔的字符串转化为字符串集合.测试字符串:'siuhgasidgh12sdgasdhafh12989878ajshgdasd12adgase'");
            Write("以'12'为间隔符,输出转化后的字符串数量:");
            WriteColorText($"{"siuhgasidgh12sdgasdhafh12989878ajshgdasd12adgase".ToStringCollection("12").Count}", ConsoleColor.Magenta);
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
            student.ToConsole();
            WriteLine();
            WriteLine("将字符串中的单词首字母大写,测试字符串:'game over'");
            string str = "game over".ToTitleUpperCase();
            WriteColorText(str, ConsoleColor.Magenta);
            WriteLine("将字符串中的单词首字母小写.测试字符串:为上函数转化后的字符串");
            WriteColorText(str.ToTitleLowerCase(), ConsoleColor.Magenta);
            Write("将字符串值'123'转换为整数:");
            WriteColorText($"{ "123".ToInt()}", ConsoleColor.Magenta);
            WriteLine();
            Write("将字符串转换为GUID:测试字符串:'936DA01F-9ABD-4d9d-80C7-02AF85C822A8',输出结果:");
            WriteColorText($"{"936DA01F-9ABD-4d9d-80C7-02AF85C822A8".ToGuid().GetType().ToString()}", ConsoleColor.Magenta);
            WriteLine();
            WriteLine("将字符串转换为GUID异常测试:测试字符串:'Microsoft'");
            try
            {
                WriteColorText($"{"Microsoft".ToGuid()}", ConsoleColor.Magenta);
            }
            catch (Exception ex)
            {
                WriteColorText(ex);
            }
            WriteLine();
            string base64str = "Microsoft".StringToBase64();
            Write("将字符串转换成Base64字符串:测试字符串:'Microsoft',输出结果:");
            WriteColorText(base64str, ConsoleColor.Magenta);
            WriteLine();
            Write($"将Base64字符转成String:测试字符串:'{base64str}',输出结果:");
            WriteColorText(base64str.Base64ToString(), ConsoleColor.Magenta);
            WriteLine();
            WriteLine("字符串插入指定分隔符,隔多少个字符插入分隔符.测试字符串为:'独立国家哈桑领导讲话稿按时鉴定会gals的机会格拉斯的结果'");
            Write("每隔4个字符插入一个逗号,输出结果为:");
            WriteColorText("独立国家哈桑领导讲话稿按时鉴定会gals的机会格拉斯的".Spacing(",", 3), ConsoleColor.Magenta);
            WriteLine();
            WriteLine("字符串的全角半角转换:测试字符串:'我是ABC,你是谁?'");
            string sbc = "我是ABC,你是谁?".ToSBC();
            Write("转化为全角:");
            WriteColorText(sbc, ConsoleColor.Magenta);
            Write("转化为半角:");
            WriteColorText(sbc.ToDBC(), ConsoleColor.Magenta);
            WriteLine();
            WriteLine("测试字符串是否为数字函数:测试字符串为:'3634635'和'767sf'");
            Write("3634635:", "3634635".IsNumber());
            WriteColorText($"{"3634635".IsNumber()}", ConsoleColor.Magenta);
            Write("767sf:");
            WriteColorText($"{"767sf".IsNumber()}", ConsoleColor.Magenta);
            WriteLine();
            WriteLine(@"验证某个字符串是否符合某个正则表达式:测试方式为电子邮件:test@qq.com和www.qq.com,正则为:'[\w]+(\.[\w]+)*@[\w]+(\.[\w])+'");
            Write("test@qq.com的结果:");
            WriteColorText($"{"test@qq.com".QuickValidate(@"[\w]+(\.[\w]+)*@[\w]+(\.[\w])+")}", ConsoleColor.Magenta);
            Write("www.qq.com的结果:");
            WriteColorText($"{"www.qq.com".QuickValidate(@"[\w]+(\.[\w]+)*@[\w]+(\.[\w])+")}", ConsoleColor.Magenta);
            WriteLine();
            Write("指针方式反转字符串:中文汉字反转测试:");
            WriteColorText($"{new string("中文汉字反转测试").ReverseByPointer()}", ConsoleColor.Magenta);
            WriteLine();
            // 由于使用指针反转后,会对内存数据进行修改,所以后边的函数再次使用相同的变量就会出现看起来没有反转一样,所以再反转一次
            Write("StringBuilder反转字符串:中文汉字反转测试:");
            WriteColorText($"{new string("中文汉字反转测试").ReverseByStringBuilder()}", ConsoleColor.Magenta);
            WriteLine();
            Write("ReverseByArray反转字符串:中文汉字反转测试:");
            WriteColorText($"{new string("中文汉字反转测试").ReverseByArray()}", ConsoleColor.Magenta);
            WriteLine();
            WriteColorText("--------------------------------------------------------------------------------------------------------------------", ConsoleColor.Yellow);
            WriteColorText("StringExtensionTest Complete", ConsoleColor.Green);
            WriteLine();
        }

        /// <summary>
        /// 将字节数组按照{23,34,56}格式输出
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private static string FormateByte(byte[] value)
        {
            var str = "{";
            for (var i = 0; i < value.Length; i++)
            {
                if (i < value.Length - 1)
                {
                    str += value[i];
                    str += ", ";
                }
                else
                    str += value[i];
            }
            str += "}";
            return str;
        }

        /// <summary>
        /// 安全加密扩展
        /// </summary>
        public static void SecurityExtensionTest()
        {
            WriteLine();
            WriteColorText("SecurityExtensionTest", ConsoleColor.Green);
            WriteColorText("--------------------------------------------------------------------------------------------------------------------", ConsoleColor.Yellow);
            Write("使用加密服务提供程序(CSP)计算输入数据的MD5哈希值.测试值:microsoft,输出结果为:");
            WriteColorText("microsoft".ToMD5(), ConsoleColor.Magenta);
            WriteLine();
            Write("使用加密服务提供程序(CSP)计算输入数据的SHA1哈希值.测试值:microsoft,输出结果为:");
            WriteColorText("microsoft".ToSHA1(), ConsoleColor.Magenta);
            WriteLine();
            WriteLine("对字符串进行DES加密.测试字符串:'Microsoft love Linux'");
            string encryptstr = "Microsoft love Linux".DESEncrypt("Linux doesn't love Microsoft");
            Write("密匙为:'Linux doesn't love Microsoft'DES加密结果:");
            WriteColorText(encryptstr, ConsoleColor.Magenta);
            WriteLine();
            //WriteLine("大佬的加密算法:{0}", "Microsoft love Linux".Des("Linux doesn't love Microsoft", "Linux doesn't love Microsoft"));
            Write("密匙为:'Linux doesn't love Microsoft'DES解密结果:");
            WriteColorText(encryptstr.DESDecrypt("Linux doesn't love Microsoft"), ConsoleColor.Magenta);
            WriteLine();
            WriteLine("当密匙错误的时候的情况:");
            try
            {
                encryptstr.DESDecrypt("Linux love Microsoft");
            }
            catch (Exception ex)
            {
                WriteColorText(ex);
            }
            WriteLine();
            WriteLine("测试将使用BitConverter转化的字节数组重新转为字节数组,所使用的字符串为上边加密后的字符串");
            byte[] bytes = encryptstr.StringToBit();
            WriteColorText(FormateByte(bytes), ConsoleColor.DarkYellow);
            WriteLine();
            Write("测试对字符串进行不可逆DES加密输出结果,测试字符串为:'Microsoft love Linux',输出结果如下:");
            WriteColorText("Microsoft love Linux".IrreversibleEncrypt(), ConsoleColor.Magenta);
            WriteLine();
            WriteLine("TripleDES 算法加密解密测试:");
            Write("对字符串进行加密,测试字符串为:Microsoft,密钥为:microsoft,加密后的内容:");
            string tripstr = "Microsoft".TripleDESEncrypt("microsoft");
            WriteColorText(tripstr, ConsoleColor.Magenta);
            WriteLine();
            Write("对加密后的字符串进行解密:");
            WriteColorText(tripstr.TripleDESDecrypt("microsoft"), ConsoleColor.Magenta);
            WriteLine();
            Write("按照指定字符集输出解密后的字符串:UTF-8字符集输出:");
            WriteColorText(tripstr.TripleDESDecrypt(Encoding.UTF8, "microsoft"), ConsoleColor.Magenta);
            WriteLine();
            Write("对字节数组进行加密:测试子节数组为:'[23,34,156,78]',密码为:Microsoft,加密结果:");
            byte[] bty = { 23, 34, 156, 78 };
            var value = bty.TripleDESEncrypt("Microsoft");
            WriteColorText(FormateByte(value), ConsoleColor.Magenta);
            WriteLine();
            Write("对上述加密后的字节数组进行解密,密码为:Microsoft,解密结果:");
            var back = value.TripleDESDecrypt("Microsoft");
            WriteColorText(FormateByte(back), ConsoleColor.Magenta);
            WriteLine();
            WriteLine("密码错误测试:");
            try
            {
                tripstr.TripleDESDecrypt("TEST");
            }
            catch (Exception ex)
            {
                WriteColorText(ex);
            }
            WriteLine();
            try
            {
                value.TripleDESDecrypt("TEST");
            }
            catch (Exception ex)
            {
                WriteColorText(ex);
            }
            WriteLine();
            WriteColorText("--------------------------------------------------------------------------------------------------------------------", ConsoleColor.Yellow);
            WriteColorText("SecurityExtensionTest Complete", ConsoleColor.Green);
            WriteLine();
        }

        /// <summary>
        /// 将Int数组按照{23,34,56}格式输出
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private static string FormateInt(int[] value)
        {
            var str = "{";
            for (var i = 0; i < value.Length; i++)
            {
                if (i < value.Length - 1)
                {
                    str += value[i];
                    str += ", ";
                }
                else
                    str += value[i];
            }
            str += "}";
            return str;
        }

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
