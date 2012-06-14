using System;

namespace Lesson1.Task1
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.Write("Введите размер первой стороны прямоугольника:");
			int a = Convert.ToInt32(Console.ReadLine());

			Console.Write("Введите размер второй стороны прямоугольника:");
			int b = Convert.ToInt32(Console.ReadLine());

			Console.Write("Введите размер стороны квадрата:");
			int c = Convert.ToInt32(Console.ReadLine());

			int rectangleArea = a * b;
			int squareArea = c * c;

			// precondition check
			if (rectangleArea < squareArea)
			{
				Console.WriteLine("Error: Задача невыполнима. Сторона квадрата больше стороны прямоугольника!");
				return;
			}

			// http://msdn.microsoft.com/ru-ru/library/system.string.aspx read about strings immutability
			// string.Format() <-- also read about this method
			Console.WriteLine("Площадь прямоугольника равна = {0}", rectangleArea);
			Console.WriteLine("Площадь квадрата равна = {0}", squareArea);

			int squaresCount = rectangleArea / squareArea;

			Console.WriteLine("В прямоугольник можно вписать = {0} квадрата(ов)", squaresCount);

			int remainder = rectangleArea % squareArea;

			Console.WriteLine("Площадь которая осталась незанятой = 0.{0}", remainder);
		}
	}
}
