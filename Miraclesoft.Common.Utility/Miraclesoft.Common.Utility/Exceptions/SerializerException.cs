using System;
using System.Runtime.Serialization;

namespace Miraclesoft.Common.Utility.Exceptions
{
    public class SerializerException : Exception
    {
        public SerializerException()
        {
        }

        public SerializerException(string message) : base(message)
        {
        }

        public SerializerException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected SerializerException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
