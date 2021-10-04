using System;
using System.Runtime.Serialization;

namespace Examich.Exceptions
{
    public class ExamichDbException : Exception
    {
        public ExamichDbException()
        {
        }

        public ExamichDbException(string message) : base(message)
        {
        }

        public ExamichDbException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ExamichDbException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
