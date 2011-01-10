using System.Collections.Generic;
using System.Web.UI;

namespace ChocoPlanet.Validation
{
    public class CustomDataValidator: IValidator 
    {
        private Dictionary<string, ValidationModel> _dictionary = ValidationCollection.Create();
        private bool isValid = false;
        private string errorMessage = string.Empty;

        private string badPasswordConfirmation = "Введено невірен підтвердження паролю";

        public string FieldID
        {
            get; 
            set;
        }

        public string FieldValue
        {
            get;
            set;
        }

        public void ValidatePassword(string passwd, string passwdConfirm)
        {
            IsValid = passwd.Equals(passwdConfirm);
            if (!IsValid)
            {
                errorMessage = badPasswordConfirmation;
            }
        }

        public new void  Validate()
        {
            if (!string.IsNullOrEmpty(FieldID) && !string.IsNullOrEmpty(FieldValue))
            {
                isValid = _dictionary[FieldID].EmailRegex.IsMatch(FieldValue);
                errorMessage = _dictionary[FieldID].ErrorMessage;
            }
        }

        public new bool IsValid
        {
            get
            {
                return isValid;
            }
            set
            {
                isValid = value;
            }
        }

        public new string ErrorMessage
        {
            get
            {
                return errorMessage;
            }
            set
            {
                errorMessage = value;
            }
        }
    }
}