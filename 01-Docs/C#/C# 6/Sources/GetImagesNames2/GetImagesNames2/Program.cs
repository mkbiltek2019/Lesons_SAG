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
            String extension;

            Console.Write("Введите путь к папке с изображениями: ");
            pathName = Console.ReadLine();
            Console.Write("Введите расширение для считываемых изображений в формате *.extension: ");
            extension = Console.ReadLine();

            DirectoryInfo di = new DirectoryInfo(pathName);

            ArrayList images = new ArrayList();
           
                FileInfo[] files = di.GetFiles(extension);
                if (files.Length > 0)
                {
                    images.AddRange(files);
                }

            Console.WriteLine("В данной директории имеются следующие изображения:");

            for (int i = 0; i < images.Count; i++)
            {
                FileInfo file = (FileInfo)images[i];

                Console.WriteLine("Имя файла: {0}" , file.Name);
            }

            Console.ReadLine();
        }
    }
}
