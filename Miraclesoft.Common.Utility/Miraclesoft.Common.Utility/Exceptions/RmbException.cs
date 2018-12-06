using System;


/// <summary>
/// 异常
/// </summary>
namespace Miraclesoft.Common.Utility.Exceptions
{
    /// <summary>
    /// 人民币异常类
    /// </summary>
    public class RmbException : Exception
    {
        /// <summary>
        /// 不带消息
        /// </summary>
        public RmbException()
        {
        }

        /// <summary>
        /// 带一个消息
        /// </summary>
        /// <param name="message">消息</param>
        public RmbException(string message) : base(message)
        {
        }

        /// <summary>
        /// 带消息和异常对象
        /// </summary>
        /// <param name="message">消息</param>
        /// <param name="innerException">异常对象</param>
        public RmbException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
