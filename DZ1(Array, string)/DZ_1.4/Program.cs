/*
Вывести на экран "прямоугольник", образованный из двух видов символов.
Контур прямоугольника должен состоять из одного символа, а в "заливка" - из другого.
Размеры прямоугольника и виды символов вводятся с клавиатуры. 
*/
  
using System;

namespace DZ_1._4 {
	class Program {
		static void Main(string[] args) {
			char border, infill;		
			int width, length;
			const int max_width = 79;		// максимальная ширина прямоугольника для корректного отображения в консоли

			Console.WriteLine("Program paint the rectangle. Please enter size and symbols for border and infill");

			while (true) {
				try {
					Console.Write("Width ( <80 ): ");
					width = Convert.ToInt32(Console.ReadLine());
				} catch (Exception) {
					Console.WriteLine("Incorrect Width. Please try again.");
					Console.WriteLine();
					continue;
				}
				if (width > max_width)
					continue;
				break;
			}
			while (true) {
				try {
					Console.Write("Length: ");
					length = Convert.ToInt32(Console.ReadLine());
				} catch (Exception) {
					Console.WriteLine("Incorrect Length. Please try again.");
					Console.WriteLine();
					continue;
				}
				break;
			}
			while (true) {
				try {
					Console.Write("Symbols for border: ");
					border = Convert.ToChar(Console.ReadLine());
				} catch (Exception) {
					Console.WriteLine("Incorrect symbols for border. Please try again.");
					Console.WriteLine();
					continue;
				}
				break;
			}
			while (true) {
				try {
					Console.Write("Symbols for infill: ");
					infill = Convert.ToChar(Console.ReadLine());
				} catch (Exception) {
					Console.WriteLine("Incorrect symbols for infill. Please try again.");
					Console.WriteLine();
					continue;
				}
				break;
			}

			for (int i = 1; i <= length; i++) {
				for (int j = 1; j <= width; j++) {
					Console.Write((i == 1 || i == length || j == 1 || j == width) ? border : infill);
				}
				Console.WriteLine();
			}
			Console.ReadKey();
		}
	}
}
