using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace ADO_001
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlConnection connection = new SqlConnection();
            try
            {
                connection.ConnectionString = @"Server=WIN7XP\SQLEXPRESS;Initial Catalog=AdventureWorks;Integrated Security=SSPI;";
                connection.Open();
                Console.WriteLine("1. Select data");
                Console.WriteLine("2. Insert data");
                Console.WriteLine("3. Delete data");
                Console.Write("4. Exit\n>>");
                int i = int.Parse(Console.ReadLine());
                while (i!=4)
                {
                    switch (i)
                    {
                        case 1:
                            {
//Error in query  WHY???                              
                                SqlCommand SelectCom = new SqlCommand(                      
                                    @" SELECT * , ROW_NUMBER() over( order by ProductCategoryID) as 'RowNumber'    
                                        FROM [Production].[ProductCategory]
                                        WHERE RowNumber BETWEEN @Count and (@Count+10);", connection);
                                SqlParameter paramSel = new SqlParameter();
                                paramSel.ParameterName = "@Count";
                                Console.WriteLine("Enter Page Number");
                                paramSel.Value = int.Parse(Console.ReadLine())*10;
                                SqlDataReader reader = SelectCom.ExecuteReader();
                                while (reader.Read() != false)
                                {
                                    Console.WriteLine("{0, -5} {1}", reader["ProductCategoryID"], reader["Name"]);
                                }
                                reader.Close();
                                i = 5;
                            }
                            break;
                        case 2:
                            {
                                SqlCommand InsertCom = new SqlCommand(
                                    @"INSERT INTO [AdventureWorksLT].[SalesLT].[ProductCategory]
                                       (  [Name], [ParentProductCategoryID])
                                      VALUES
                                        ( @CategoryName,@ParentParam)", connection);
                                SqlParameter NameParam = new SqlParameter();
                                NameParam.ParameterName = "@CategoryName";
                                Console.WriteLine(" Enter new category name");
                                NameParam.Value = Console.ReadLine();
                                SqlParameter ParentParam = new SqlParameter();
                                ParentParam.ParameterName = "@ParentParam";
                                Console.WriteLine(" Enter parent category id");
                                ParentParam.Value = Console.ReadLine();
                                InsertCom.Parameters.Add(NameParam);
                                InsertCom.Parameters.Add(ParentParam);
                                SqlDataReader readerIns = InsertCom.ExecuteReader();
                                readerIns.Close();
                                i = 5;
                            }
                            break;
                        case 3:
                            {
                                SqlCommand DeletteCom = new SqlCommand(
                                    @"DELETE FROM [AdventureWorksLT].[SalesLT].[ProductCategory]
                                    WHERE ProductCategoryID = @ID" , connection);
                                SqlParameter DelParam = new SqlParameter();
                                DelParam.ParameterName = "@ID";
                                Console.WriteLine("Enter category ID");
                                DelParam.Value = int.Parse(Console.ReadLine());
                                DeletteCom.Parameters.Add(DelParam);
                                SqlDataReader readerDel = DeletteCom.ExecuteReader();
                                readerDel.Close();
                                i = 5;

                            }
                            break;
                        case 4:
                            break;
                        case 5:
                            Console.WriteLine("----------------");
                            Console.WriteLine("1. Select data");
                            Console.WriteLine("2. Insert data");
                            Console.WriteLine("3. Delete data");
                            Console.Write("4. Exit\n>>");
                            i = int.Parse(Console.ReadLine());
                            break;
                        default:
                            Console.WriteLine("Try once more !!!");
                             
                            break;
                    }

                    
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                // Закрываем соединение
                connection.Close();
            }
        }
    }
}
