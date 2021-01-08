using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miracle.Common.Utility.Ini
{
    public class IniHelper
    {
        /// <summary>
        /// 读取或者创建ini
        /// </summary>
        /// <param name="path">文件路径</param>
        /// <returns></returns>
        public static async Task<IniContext> ReadOrCreateAsync(string path)
        {
            FileInfo fileInfo = new FileInfo(path);
            IniContext iniCotext = new IniContext() { Sections = new IniContext.Content() { Items = new List<IniContext.Section>() }, File = fileInfo };
            string[] lines = null;
            if (File.Exists(path))
            {
                lines = await File.ReadAllLinesAsync(path);
            }
            else
            {
                File.WriteAllText(path, string.Empty);
                return iniCotext;
            }
            IniContext.Section tempSection = null;
            try
            {
                for (int i = 0; i < lines?.Length; i++)
                {
                    string item = lines[i].TrimStart();
                    //; ；为注解
                    if (item.IndexOf(';') == 0 || item.IndexOf('；') == 0 || string.IsNullOrEmpty(item))
                    {
                        continue;
                    }
                NextSection:
                    if (tempSection == null)
                    {

                        int sectionStart = item.IndexOf('[');
                        int sectionEnd = item.LastIndexOf(']');

                        if (sectionStart == 0 && sectionEnd >= 1)
                        {
                            tempSection = new IniContext.Section
                            {
                                Name = item[(sectionStart + 1)..sectionEnd],
                                Line = i,
                                Args = new Dictionary<string, string>()
                            };

                            iniCotext.Sections.Items.Add(tempSection);
                        }

                        continue;
                    }

                    int ksIndex = item.IndexOf('=');
                    if (ksIndex == -1)
                    {
                        tempSection = null;
                        goto NextSection;
                    }
                    string k = item[0..ksIndex];
                    string v = item[(ksIndex + 1)..item.Length];
                    if (k == null)
                    {
                        continue;
                    }
                    tempSection.Args.Add(k, v);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return iniCotext;
        }

        /// <summary>
        /// 读取或者创建ini
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static IniContext ReadOrCreate(string path)
        {
            try
            {
                Task<IniContext> iniTask = ReadOrCreateAsync(path);
                iniTask.Wait();
                return iniTask.Result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 更新ini
        /// </summary>
        /// <param name="iniCotext"></param>
        public static async Task UpgradeAsync(IniContext iniCotext)
        {
            if (iniCotext.File == null)
            {
                throw new ArgumentNullException("文件路径为空");
            }
            try
            {
                string sb = null;
                await Task.Run(() =>
                {
                    try
                    {
                        sb = iniCotext.ToString();
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                });

                await File.WriteAllTextAsync(iniCotext.File.FullName, sb.ToString());
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 更新ini
        /// </summary>
        /// <param name="iniCotext"></param>
        public static void Upgrade(IniContext iniCotext)
        {
            try
            {
                Task iniTask = UpgradeAsync(iniCotext);
                iniTask.Wait();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// ini 文件内容
        /// </summary>
        public class IniContext
        {
            /// <summary>
            /// 所有节
            /// </summary>
            public Content Sections { get; set; }

            /// <summary>
            /// 文件路径
            /// </summary>
            public FileInfo File { get; set; }

            /// <summary>
            /// 节
            /// </summary>
            public class Section
            {
                /// <summary>
                /// 节名称
                /// </summary>
                public string Name { get; set; }

                /// <summary>
                /// 节行号
                /// </summary>
                public long Line { get; set; }

                /// <summary>
                /// 键值对
                /// </summary>
                public Dictionary<string, string> Args { get; set; }
            }

            public class Content
            {
                public List<Section> Items { get; set; }

                /// <summary>
                /// 节名称获取节
                /// </summary>
                /// <param name="sectionName">节名称</param>
                /// <param name="sectionIndex">节序列位置</param>
                /// <returns></returns>
                public Section this[string sectionName, int sectionIndex = 0]
                {
                    get
                    {
                        if (Items == null || Items.Count < 1)
                        {
                            return null;
                        }
                        var list = Items.Where(x => x.Name == sectionName).ToList();
                        return list.Count < 1 ? null : list[sectionIndex];
                    }
                    set
                    {
                        if (Items == null || Items.Count < 1 || sectionIndex < 0)
                        {
                            return;
                        }
                        var list = Items.Where(x => x.Name == sectionName).ToList();
                        if (list == null)
                        {
                            return;
                        }
                        for (int i = 0; i < list.Count; i++)
                        {
                            Section item = list[i];
                            if (sectionIndex == i)
                            {
                                if (null == value)
                                {
                                    item = null;
                                    list[i] = item;
                                    return;
                                }
                                item.Args = value.Args;
                                item.Line = value.Line;
                                item.Name = value.Name;
                                return;
                            }
                        }
                    }
                }

                /// <summary>
                /// 节下标获取节
                /// </summary>
                /// <param name="index"></param>
                /// <returns></returns>
                public Section this[int index]
                {
                    get
                    {
                        return null == Items || Items.Count < index ? null : Items[index];
                    }
                    set
                    {
                        if (null == Items || Items.Count < index)
                        {
                            return;
                        }
                        Items[index] = value;
                    }
                }
            }

            /// <summary>
            /// 转字符串
            /// </summary>
            /// <returns></returns>
            public override string ToString()
            {
                StringBuilder sb = new StringBuilder();

                if (Sections != null && Sections.Items != null && Sections.Items.Count > 0)
                {
                    try
                    {
                        foreach (var item in Sections.Items)
                        {
                            _ = sb.AppendLine($"[{item.Name}]");
                            if (item.Args == null)
                            {
                                continue;
                            }
                            IEnumerable<string> args = item.Args.Select(x => $"{x.Key}={x.Value}");
                            foreach (string argItem in args)
                            {
                                _ = sb.AppendLine(argItem);
                            }
                        }
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
                return sb.ToString();
            }
        }
    }
}
