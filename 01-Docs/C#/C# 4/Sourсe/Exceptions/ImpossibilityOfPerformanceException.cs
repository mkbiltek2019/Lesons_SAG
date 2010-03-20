using System;

namespace Lesson_04
{
    public class ImpossibilityOfPerformanceException : ApplicationException
    {
        public ImpossibilityOfPerformanceException()
            : base() { }

        public ImpossibilityOfPerformanceException(String message)
            : base(message) { }

        public ImpossibilityOfPerformanceException(String message,
            Exception innerException)
            : base(message, innerException) { }

        public ImpossibilityOfPerformanceException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
    }
}
