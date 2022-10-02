using System;
using System.Runtime.Serialization;

namespace ExamichUserService.Exceptions
{
    public class ExamichUserServiceDbException : Exception
    {
        public ExamichUserServiceDbException()
        {
        }

        public ExamichUserServiceDbException(string message) : base(message)
        {
        }

        public ExamichUserServiceDbException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ExamichUserServiceDbException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
