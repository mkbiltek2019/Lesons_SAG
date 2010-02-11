using System;

namespace Lesson_5_Delegate_E3
{
    class Program
    {
        private class Circle
        {
            public Double Radius;

            public Circle(Double radius)
            {
                this.Radius = radius;
            }

            public void PrintRadius()
            {
                Console.WriteLine("Радиус равен :           {0,7:N3}", Radius);
            }

            public void PrintDiameter()
            {
                Double diameter = 2 * Radius;
                Console.WriteLine("Диаметр равен :          {0,7:N3}", diameter);
            }

            public void PrintLenght()
            {
                Double lenght = 2 * Math.PI * Radius;
                Console.WriteLine("Длина окружности равна : {0,7:N3}", lenght);
            }

            public void PrintSquare()
            {
                Double square = Math.PI * Radius * Radius;
                Console.WriteLine("Площадь круга равна :    {0,7:N3}", square);
            }
        }

        private delegate void PrintInfo();

        static void Main(string[] args)
        {
            Circle circle = new Circle(4);

            PrintInfo printInfo = new PrintInfo(circle.PrintRadius);
            Console.WriteLine("\nДелегат инициализирован одним методом"+
                " PrintRadius()");
            printInfo();

            printInfo += circle.PrintDiameter;
            printInfo += circle.PrintLenght;
            printInfo += circle.PrintSquare;

            Console.WriteLine("\nДелегат вызывает цепочку методов \nPrintRadius(),"+
                " PrintDiameter(), PrintLenght(), PrintSquare() :\n");
            printInfo();

            PrintInfo printInfo1 = circle.PrintSquare;

            printInfo -= printInfo1;
            Console.WriteLine(
                "\nТеперь делегат вызывает методы \nPrintRadius(),"+
                " PrintDiameter(), PrintLenght() :\n");
            printInfo();


            printInfo = printInfo + printInfo1 - new PrintInfo(circle.PrintRadius) 
                - new PrintInfo(circle.PrintDiameter);
            Console.WriteLine("\nТеперь делегат вызывает методы" +
                " \nPrintLenght(), PrintSquare() :\n");
            printInfo();

            Console.WriteLine("\n");
        }
    }
}
