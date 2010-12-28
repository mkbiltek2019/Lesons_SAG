using System.Collections.Generic;
using System.Data;
using System.Text.RegularExpressions;
using ChocoPlanet.Business.xmlParcer;

namespace ChocoPlanet.Validation
{
    public class ValidationModel
    {
        //public string FieldID
        //{
        //    get;
        //    set;
        //}
        public Regex EmailRegex
        {
            get; 
            set;
        }

        public string ErrorMessage
        {
            get; 
            set;
        }
    }

    public static class ValidationCollection
    {
        private static string fileName = ".\\xmlData\\FieldIDWithRegExp.xml";
        private static string tableName = "Expression";

        private static string fieldId = "FieldID";
        private static string regexp = "RegExp";
        private static string errorMessage = "ErrorMessage";
        
        private static ChocoReader chocoReader = new ChocoReader();

        public static Dictionary<string, ValidationModel> Create()
        {
            Dictionary<string, ValidationModel> result = new Dictionary<string, ValidationModel>();

            foreach (DataRow dataModel in chocoReader.LoadDatasetFromXml(fileName).Tables[tableName].Rows)
            {
                ValidationModel validationModel = new ValidationModel();
                validationModel.EmailRegex = new Regex(dataModel[regexp].ToString());
                validationModel.ErrorMessage = dataModel[errorMessage].ToString();

                result.Add(dataModel[fieldId].ToString(), validationModel);
            }

            return result;
        }
    }
}