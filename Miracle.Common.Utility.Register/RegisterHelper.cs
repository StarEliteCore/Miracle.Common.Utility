using Microsoft.Win32;
using System;

namespace Miracle.Common.Utility.Register
{
    /// <summary>
    /// 注册表辅助类
    /// </summary>
    public class RegisterHelper
    {
        /// <summary>
        /// 默认注册表基项
        /// </summary>
        public string BaseKey { get; } = "Software";

        #region 构造函数

        /// <summary>
        /// 构造函数
        /// </summary>
        public RegisterHelper()
        { }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="baseKey">基项的名称</param>
        public RegisterHelper(string baseKey) => BaseKey = baseKey;

        #endregion

        #region 公共方法

        /// <summary>
        /// 写入注册表,如果指定项已经存在,则修改指定项的值
        /// </summary>
        /// <param name="keytype">注册表基项枚举</param>
        /// <param name="key">注册表项,不包括基项</param>
        /// <param name="name">值名称</param>
        /// <param name="values">值</param>
        public void SetValue(KeyType keytype, string key, string name, string values)
        {
            var rk = GetRegistryKey(keytype) as RegistryKey;
            var software = rk.OpenSubKey(BaseKey, true);
            var rkt = software.CreateSubKey(key);
            rkt?.SetValue(name, values);
        }

        /// <summary>
        /// 读取注册表
        /// </summary>
        /// <param name="keytype">注册表基项枚举</param>
        /// <param name="key">注册表项,不包括基项</param>
        /// <param name="name">值名称</param>
        /// <returns>返回字符串</returns>
        public string GetValue(KeyType keytype, string key, string name)
        {
            var rk = GetRegistryKey(keytype) as RegistryKey;
            var software = rk.OpenSubKey(BaseKey, true);
            var rkt = software.OpenSubKey(key);
            return rkt?.GetValue(name).ToString() ?? string.Empty;
        }

        /// <summary>
        /// 删除注册表中的值
        /// </summary>
        /// <param name="keytype">注册表基项枚举</param>
        /// <param name="key">注册表项名称,不包括基项</param>
        /// <param name="name">值名称</param>
        public void DeleteValue(KeyType keytype, string key, string name)
        {
            var rk = GetRegistryKey(keytype) as RegistryKey;
            var software = rk.OpenSubKey(BaseKey, true);
            var rkt = software.OpenSubKey(key, true);
            var value = rkt?.GetValue(name);
            if (value != null)
                rkt.DeleteValue(name, true);
        }

        /// <summary>
        /// 删除注册表中的指定项
        /// </summary>
        /// <param name="keytype">注册表基项枚举</param>
        /// <param name="key">注册表中的项,不包括基项</param>
        /// <returns>返回布尔值,指定操作是否成功</returns>
        public void DeleteSubKey(KeyType keytype, string key)
        {
            var rk = GetRegistryKey(keytype) as RegistryKey;
            var software = rk.OpenSubKey(BaseKey, true);
            software?.DeleteSubKeyTree(key);
        }

        /// <summary>
        /// 判断指定项是否存在
        /// </summary>
        /// <param name="keytype">基项枚举</param>
        /// <param name="key">指定项字符串</param>
        /// <returns>返回布尔值,说明指定项是否存在</returns>
        public bool IsExist(KeyType keytype, string key)
        {
            var rk = GetRegistryKey(keytype) as RegistryKey;
            var software = rk.OpenSubKey(BaseKey);
            var rkt = software.OpenSubKey(key);
            return rkt != null;
        }

        /// <summary>
        /// 检索指定项关联的所有值
        /// </summary>
        /// <param name="keytype">基项枚举</param>
        /// <param name="key">指定项字符串</param>
        /// <returns>返回指定项关联的所有值的字符串数组</returns>
        public string[] GetValues(KeyType keytype, string key)
        {
            var rk = GetRegistryKey(keytype) as RegistryKey;
            var software = rk.OpenSubKey(BaseKey, true);
            var rkt = software.OpenSubKey(key);
            var names = rkt.GetValueNames();
            if (names.Length == 0)
                return names;
            var values = new string[names.Length];
            var i = 0;
            foreach (var name in names)
            {
                values[i] = rkt.GetValue(name).ToString();
                i++;
            }
            return values;
        }

        /// <summary>
        /// 将对象所有属性写入指定注册表中
        /// </summary>
        /// <param name="keyType">注册表基项枚举</param>
        /// <param name="key">注册表项,不包括基项</param>
        /// <param name="obj">传入的对象</param>
        public void SetObjectValue(KeyType keyType, string key, object obj)
        {
            if (obj == null)
                return;
            var t = obj.GetType();
            foreach (var p in t.GetProperties())
            {
                if (p == null)
                    continue;
                SetValue(keyType, key, p.Name, p.GetValue(obj, null).ToString());
            }
        }

        #endregion

        #region 私有方法

        /// <summary>
        /// 返回RegistryKey对象
        /// </summary>
        /// <param name="keyType">注册表基项枚举</param>
        /// <returns></returns>
        private object GetRegistryKey(KeyType keyType)
        {
            RegistryKey rk;
            switch (keyType)
            {
                case KeyType.HKEY_CLASS_ROOT:
                    rk = Registry.ClassesRoot;
                    break;
                case KeyType.HKEY_CURRENT_USER:
                    rk = Registry.CurrentUser;
                    break;
                case KeyType.HKEY_LOCAL_MACHINE:
                    rk = Registry.LocalMachine;
                    break;
                case KeyType.HKEY_USERS:
                    rk = Registry.Users;
                    break;
                case KeyType.HKEY_CURRENT_CONFIG:
                    rk = Registry.CurrentConfig;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(keyType), keyType, null);
            }
            return rk;
        }

        #endregion
    }
}