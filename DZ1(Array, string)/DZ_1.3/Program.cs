/*
Найти все совершенные числа до 10 000.
Совершенное число - это такое число, которое равно сумме всех своих делителей, кроме себя самого.
Например, число 6 является совершенным, т.к. кроме себя самого делится на числа 1, 2 и 3, которые в сумме дают 6.
*/

using System;

namespace DZ_1._3 {
	class Program {
		static void Main(string[] args) {
			const int max_number = 10000;
			int summ_divisor;				// сумма делителей числа
			byte perfectNumbersCount = 0;	// колличество найденных совершенных чисел

			Console.Write("{0}{1:N0}{2}", "Perfect numbers under ", max_number, ": ");

			for (int number = 2; number < max_number; number++) {
				summ_divisor = 0;
				for (int j = 1; j < number; j++) {
					if (number % j == 0) {
						summ_divisor += j;
					}
				}
				if (number == summ_divisor) {
					Console.Write("{0}{1}", perfectNumbersCount == 0 ? "" : ", ", number);
					perfectNumbersCount++;
				}
			}
			Console.ReadKey();
		}
	}
}
