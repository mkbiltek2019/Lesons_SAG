using System;
using System.IO;
using System.Threading;
using System.Text;

namespace AsyncRequest
{
    class AsyncRequestClass
    {
        static void Main(string[] args)
        {
            //AsyncReadRequest();

            FileStream fs = new FileStream(@"../../Program.cs", FileMode.Open,
                                            FileAccess.Read, FileShare.Read, 1024,
                                            FileOptions.Asynchronous);

            Byte[] data = new Byte[100];

            IAsyncResult ar = fs.BeginRead(data, 0, data.Length, null, null);

            while (!ar.AsyncWaitHandle.WaitOne(1, false))
            {
                Console.WriteLine("Операция не завершена, ожидайте...");
            }

            Int32 bytesRead = fs.EndRead(ar);

            fs.Close();

            Console.WriteLine("Количество считаных байт = {0}", bytesRead);
            Console.WriteLine(Encoding.UTF8.GetString(data).Remove(0, 1));
        }

        private static void AsyncReadRequest()
        {
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
    }
}
