using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
// Используем технологию пространство OLE DB
using System.Data.OleDb;

namespace GetData
{
    class Program
    {
        static void Main(string[] args)
        {
            // создаём объект для соединения с базой
            OleDbConnection connection = new OleDbConnection();
            try
            {
                // Прописываем строку соединения 
                // Указываем параметры необходимые для MS Access
                // Их два: имя провайдера (Provider) зарегистрированное в системе 
                // и путь к файлу базы данных (Data Source) 
                connection.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=../../sample.mdb";
                // Открываем соединение 
                // Если произойдет ошибка вылетит исключение
                connection.Open();
                // Создаём объект для исполнения запроса
                // Указываем ему в качестве параметра запрос и объект открытого соединения
                OleDbCommand command = new OleDbCommand("SELECT * FROM PEOPLE",connection);
                // Исполняем запрос и сохраняем ссылку на объект результата
                OleDbDataReader reader = command.ExecuteReader();
                // Проходимся по результатам работы запроса строка за строкой
                // Когда данные кончатся метод Read вернет false
                while (reader.Read() != false)
                {
                    // Так как в таблице три столбца в результате в строке будет тоже три столбца
                    // Для обращения к столбцу используется индексатор 
                    // Возможен доступ как по имени столбца так и по индексу
                    Console.WriteLine("{0,-10} {1,-10} {2,-10}",reader["id"],reader["firstname"],reader["lastname"]);
                    /*
                      Console.WriteLine("{0,-10} {1,-10} {2,-10}", reader[0], reader[1], reader[2]);
                     */ 
                }
                
            }
            catch(Exception ex){
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
