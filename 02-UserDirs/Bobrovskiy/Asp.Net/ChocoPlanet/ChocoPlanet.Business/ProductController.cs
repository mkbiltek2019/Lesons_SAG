using System.Collections;
using System.Collections.Generic;
using System.Data;
using ChocoPlanet.Business.xmlParcer;

namespace ChocoPlanet.Business
{
    public class ProductController
    {
        private string fileName = ".\\xmlData\\xmlData.xml";
        private string tableName = "Product";
        private string columnName1 = "Category";
        private string columnName2 = "Name";
        private string columnName3 = "Description";
        private string columnName4 = "ThubmnailImagePath";
        private string columnName5 = "MainImagePath";
        private string columnName6 = "Price";
        private string defaultExspresion = "Make your choice.";

        private ChocoReader chocoReader = new ChocoReader();

        public ICollection GetCategoryList()
        {
            List<string> result = new List<string>();
            result.Add(defaultExspresion);

            foreach (DataRow dataModel in chocoReader.LoadDatasetFromXml(fileName).Tables[tableName].Rows)
            {
                string value = dataModel[columnName1].ToString();
                if (!result.Contains(value))
                {
                    result.Add(value);
                }
            }

            return result;
        }

        public ICollection GetListByCategoryName(string categoryName)
        {
            List<DataModel> result = new List<DataModel>();

            foreach (DataRow dataModel in chocoReader.LoadDatasetFromXml(fileName).Tables[tableName].Rows)
            {
                if (dataModel[columnName1].ToString() == categoryName)
                {
                    DataModel model = new DataModel();
                    model.Category = dataModel[columnName1].ToString();
                    model.Name = dataModel[columnName2].ToString();
                    model.Description = dataModel[columnName3].ToString();
                    model.ThubmnailImagePath = dataModel[columnName4].ToString();
                    model.MainImagePath = dataModel[columnName5].ToString();
                    model.Price = dataModel[columnName6].ToString();

                    result.Add(model);
                }
            }

            return result;
        }

        //public DataSet GetAllProducts()
        //{
        //    DataSet dataSet = new DataSet();
        //    dataSet = chocoReader.LoadDatasetFromXml(fileName);

        //    return chocoReader.LoadDatasetFromXml(fileName);
        //}
    }
}