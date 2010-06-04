using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WindowsFormsApplication9.AdventureWorksLT2008DataSetTableAdapters;

namespace WindowsFormsApplication9
{
    class DataBasaManeger
    {
        public static AdventureWorksLT2008DataSet GetTypeDateSet()
        {

            AdventureWorksLT2008DataSet result = new AdventureWorksLT2008DataSet();
            (new ProductTableAdapter()).Fill(result.Product);
            (new AddressTableAdapter()).Fill(result.Address);
            (new CustomerTableAdapter()).Fill(result.Customer);
            (new CustomerAddressTableAdapter()).Fill(result.CustomerAddress);
            (new ProductCategoryTableAdapter()).Fill(result.ProductCategory);
            (new ProductDescriptionTableAdapter()).Fill(result.ProductDescription);
            (new ProductModelTableAdapter()).Fill(result.ProductModel);
            (new ProductModelProductDescriptionTableAdapter()).Fill(result.ProductModelProductDescription);
            (new SalesOrderDetailTableAdapter()).Fill(result.SalesOrderDetail);
            (new SalesOrderHeaderTableAdapter()).Fill(result.SalesOrderHeader);
            return result;
        }
        public static string EscapeLikeValue(string valueWithoutWildcards)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < valueWithoutWildcards.Length; i++)
            {
                char c = valueWithoutWildcards[i];
                if (c == '*' || c == '%' || c == '[' || c == ']')
                    sb.Append("[").Append(c).Append("]");
                else if (c == '\'')
                    sb.Append("''");
                else
                    sb.Append(c);
            }
            return sb.ToString();
        }
        
    }
}
