using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MediaLibrary.Business;

namespace MediaLibrary.ValidationRules
{
    public class TrackListValidator : IValidator
    {
        #region IValidator Members

        public string ValidateMember(object objectToValidate, string memberName)
        {
            TrackList trackList = (TrackList)objectToValidate; 
            switch (memberName)
            {
                case "Name":
                    {
                        if (string.IsNullOrEmpty(trackList.Name))
                        {
                            return "ValidationError.CannotBeNull";
                        }
                    }
                    break;
                default:
                    throw new ArgumentException("Class does not contain speciefied member", "memberName");
                    break;
            }

            return string.Empty;
        }

        #endregion
    }
}
