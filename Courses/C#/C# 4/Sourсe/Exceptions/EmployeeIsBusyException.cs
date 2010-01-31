using System;

namespace Lesson_04
{
    public class EmployeeIsBusyException : ImpossibilityOfPerformanceException
    {
        public EmployeeIsBusyException()
            : base() { }

        public EmployeeIsBusyException(String message)
            : base(message) { }

        public EmployeeIsBusyException(String message,
            Exception innerException)
            : base(message, innerException) { }

        public EmployeeIsBusyException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }

        private DateTime remainingTime;
        public DateTime RemainingTime
        {
            get { return remainingTime; }
            set { remainingTime = value; }
        }

        private String workDescription;
        public String WorkDescription
        {
            get { return workDescription; }
            set { workDescription = value; }
        }
    }
}
