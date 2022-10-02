using System;
using System.Runtime.Serialization;

namespace ExamichService.Exceptions
{
    public class ExamichServiceDbException : Exception
    {
        public ExamichServiceDbException()
        {
        }

        public ExamichServiceDbException(string message) : base(message)
        {
        }

        public ExamichServiceDbException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ExamichServiceDbException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
