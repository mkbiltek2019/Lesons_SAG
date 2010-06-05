using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MediaLibrary.ValidationRules
{
    public interface IValidator
    {
        string ValidateMember(object objectToValidate, string memberName);
    }
}
