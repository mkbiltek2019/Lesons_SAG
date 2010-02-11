using System;
using System.Collections;
using System.IO;

namespace ArrayListExz
{
    class Program
    {
        static void Main(string[] args)
        {
            String pathName;
            Console.Write("Введите путь к папке с изображениями: ");
            pathName = Console.ReadLine();
            DirectoryInfo di = new DirectoryInfo(pathName);
            string[] fileTypes = { "*.bmp", "*.gif", "*.jpg", "*.png" };
            ArrayList images = new ArrayList();
            foreach (string ext in fileTypes)
            {
                FileInfo[] files = di.GetFiles(ext);
                if (files.Length > 0)
                {
                    images.AddRange(files);
                }
            }

            Console.WriteLine("В Данной директории имеются следующие Изображения:");

            for (int i = 0; i < images.Count; i++)
            {
                FileInfo file = (FileInfo)images[i];

                Console.WriteLine("Имя файла: {0}, его расширение: {1}", file.Name, file.Extension);
            }

            Console.ReadLine();
        }
    }
}