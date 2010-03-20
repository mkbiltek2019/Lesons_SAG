using System;

namespace Lesson_04
{
    public class ForceMajeureException : ImpossibilityOfPerformanceException
    {
        public ForceMajeureException()
            : base() { }

        public ForceMajeureException(String message)
            : base(message) { }

        public ForceMajeureException(String message,
            Exception innerException)
            : base(message, innerException) { }

        public ForceMajeureException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }

        private String forceMajeureDescription;
        public String ForceMajeureDescription
        {
            get { return forceMajeureDescription; }
            set { forceMajeureDescription = value; }
        }

        private Decimal extentOfDamage;
        public Decimal ExtentOfDamage
        {
            get { return extentOfDamage; }
            set { extentOfDamage = value; }
        }
    }
}
