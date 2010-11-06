using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JuggedArray
{
    class Program
    {
        static void Main(string[] args)
        {
            // определяем массив
            JuggedArray array = new JuggedArray(
                new double[][]
                    {
                        new double[] {11, 12, 13, 14, 15},
                        new double[] {21, 22, 23},
                        new double[] {31, 32, 33, 34}
                    }
            );
            // создаем конвертер
            JuggedArrayConverter converter = new JuggedArrayConverter();
            // конфигурируем конвертер массивом
            converter.Array = array;

            Console.WriteLine("Текстовое представление массива:");
            // конфигурируем конвертер строителем текстового представления
            converter.Builder = new TextJuggedArrayBuilder();
            // проводим конвертацию
            object textArray = converter.Convert();
            // выводим результат построения на консоль
            Console.WriteLine(textArray);

            Console.WriteLine("Xml-представление массива:");
            // конфигурируем конвертер строителем xml-представления
            converter.Builder = new XmlJuggedArrayBuilder();
            // проводим конвертацию
            object xmlArray = converter.Convert();
            // выводим результат построения на консоль
            Console.WriteLine(xmlArray);
        }
    }
}
