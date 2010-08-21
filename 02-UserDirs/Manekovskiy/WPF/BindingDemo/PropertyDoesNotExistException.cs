using System;

namespace BindingDemo
{
    public class PropertyDoesNotExistException : Exception
    {
        public PropertyDoesNotExistException(string propertyName)
            : base(string.Format("Property {0} does not exist!", propertyName))
        { }
    }
}