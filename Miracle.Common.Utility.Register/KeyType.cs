namespace Miracle.Common.Utility.Register
{
    #region 枚举
    /// <summary>
    /// 注册表基项枚举
    /// </summary>
    public enum KeyType
    {
        /// <summary>
        /// 注册表基项 HKEY_CLASSES_ROOT
        /// </summary>
        HKEY_CLASS_ROOT = 0,
        /// <summary>
        /// 注册表基项 HKEY_CURRENT_USER
        /// </summary>
        HKEY_CURRENT_USER = 1,
        /// <summary>
        /// 注册表基项 HKEY_LOCAL_MACHINE
        /// </summary>
        HKEY_LOCAL_MACHINE = 2,
        /// <summary>
        /// 注册表基项 HKEY_USERS
        /// </summary>
        HKEY_USERS = 3,
        /// <summary>
        /// 注册表基项 HKEY_CURRENT_CONFIG
        /// </summary>
        HKEY_CURRENT_CONFIG = 4
    }
    #endregion
}