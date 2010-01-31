using System;

namespace Lesson_04
{
    public class CrunchException : ImpossibilityOfPerformanceException
    {
        public CrunchException()
            : base() { }

        public CrunchException(String message)
            : base(message) { }

        public CrunchException(String message,
            Exception innerException)
            : base(message, innerException) { }

        public CrunchException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
    }
}
