using System;
using System.IO;
using System.Threading;
using System.Text;

namespace AsyncWait
{
    class AsyncWaitClass
    {
        static void Main(string[] args)
        {
            //AsyncReadOneFile();

            //AsyncReadMultiplyFiles();

            FileStream fs = new FileStream(@"../../Program.cs", FileMode.Open,
               FileAccess.Read, FileShare.Read, 1024,
               FileOptions.Asynchronous);

            Byte[] data = new Byte[100];

            IAsyncResult ar = fs.BeginRead(data, 0, data.Length, null, null);

            while (!ar.IsCompleted)
            {
                Console.WriteLine("Операция не завершена, ожидайте...");
                Thread.Sleep(10);
            }

            Int32 bytesRead = fs.EndRead(ar);

            fs.Close();

            Console.WriteLine("Количество считаных байт = {0}", bytesRead);
            Console.WriteLine(Encoding.UTF8.GetString(data).Remove(0, 1));
        }

        //Метод считывания из нескольких файлов
        private static void AsyncReadMultiplyFiles()
        {
            string[] files = {"../../Program.cs", 
                              "../../AsyncWait.csproj", 
                              "../../Properties/AssemblyInfo.cs"};
            AsyncReader[] asrArr = new AsyncReader[3];
            for (int i = 0; i < asrArr.Length; ++i)
                asrArr[i] = new AsyncReader(new FileStream(files[i], FileMode.Open, FileAccess.Read,
                                                    FileShare.Read, 1024, FileOptions.Asynchronous), 100);

            foreach (AsyncReader asr in asrArr)
                Console.WriteLine(asr.EndRead());
        }

        //Метод считывания из одного файла
        private static void AsyncReadOneFile()
        {
            FileStream fs = new FileStream(@"../../Program.cs", FileMode.Open, FileAccess.Read,
                                            FileShare.Read, 1024, FileOptions.Asynchronous);
            Byte[] data = new Byte[100];
            // Начало асинхронной операции чтения из файла FileStream. 
            IAsyncResult ar = fs.BeginRead(data, 0, data.Length, null, null);
            // Здесь выполняется другой код... 
            // Приостановка этого потока до завершения асинхронной операции 
            // и получения ее результата. 
            Int32 bytesRead = fs.EndRead(ar);
            // Других операций нет. Закрытие файла. 
            fs.Close();
            // Теперь можно обратиться к байтовому массиву и вывести результат операции. 
            Console.WriteLine("Количество прочитаных байт = {0}", bytesRead);

            Console.WriteLine(Encoding.UTF8.GetString(data).Remove(0, 1));
        }
    }

    class AsyncReader
    {
        FileStream stream;
        byte[] data;
        IAsyncResult asRes;

        public AsyncReader(FileStream s, int size)
        {
            stream = s;
            data = new byte[size];
            asRes = s.BeginRead(data, 0, size, null, null);
        }

        public string EndRead()
        {
            int countByte = stream.EndRead(asRes);
            stream.Close();
            Array.Resize(ref data, countByte);
            return string.Format("Файл: {0}\n{1}\n\n", stream.Name, Encoding.UTF8.GetString(data).Remove(0, 1));
        }
    }
}
