using System;
using System.Runtime.Serialization;

namespace RPSBackendLogic.Exceptions
{
    [Serializable]
    public class InvalidStringLengthException : Exception
    {
        public InvalidStringLengthException()
        {
        }

        public InvalidStringLengthException(string message) : base(message)
        {
        }

        public InvalidStringLengthException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidStringLengthException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}