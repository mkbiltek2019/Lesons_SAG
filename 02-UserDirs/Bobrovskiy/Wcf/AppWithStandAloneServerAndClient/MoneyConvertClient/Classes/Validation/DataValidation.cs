using System;

namespace MoneyConvertClient.Classes.Validation
{
    public interface IValidator
    {
        string ValidateText(string value);
        double ValidateAndConvertToDouble(string value);
    }

    class DataValidator : IValidator
    {
        private const string textError = "data not valide";

        public string ValidateText(string value)
        {
            string result = string.Empty;

            if (!string.IsNullOrEmpty(value))
            {
                result = value;
            }
            else
            {
                throw new Exception(textError);
            }

            return result;
        }

        public double ValidateAndConvertToDouble(string value)
        {
            double result = 0.0;
            string valideText = string.Empty;

            valideText = ValidateText(value);

            result = Convert.ToDouble(valideText);

            if (result == null)
            {
                throw new Exception(textError);
            }

            return result;
        }

    }

    public class Validator : IValidator
    {
        private IValidator dataValidator = new DataValidator();

        public event Action<string> ValidationState = null;

        private const string textError = "not valid";
        private const string textValid = "valid";

        private bool validationState = false;

        public bool DataIsValid
        {
            get
            {
                return validationState;
            }
            set
            {
                validationState = value;
            }
        }

        public string ValidateText(string value)
        {
            string result = string.Empty;

            try
            {
                result = dataValidator.ValidateText(value);
                validationState = true;
            }
            catch (Exception e)
            {
                validationState = false;
                ValidationState.Invoke(textError + e.Message);
            }

            //if (validationState)
            //{
            //    ValidationState.Invoke(textValid);
            //}

            return result;
        }

        public double ValidateAndConvertToDouble(string value)
        {
            double result = 0.0;

            try
            {
                result = dataValidator.ValidateAndConvertToDouble(value);
                validationState = true;
            }
            catch (Exception e)
            {
                validationState = false;
                ValidationState.Invoke(textError + e.Message);
            }

            //if (validationState)
            //{
            //    ValidationState.Invoke(textValid);
            //}

            return result;
        }

    }

}
