/*
 Вводится целое число в диапазоне 100–999.
 Вывести строку-описание данного числа,
 например: 256 — «двести пятьдесят шесть», 814 — «восемьсот четырнадцать».
 */
   
using System;

namespace DZ_1._1 {
	class Program {
		static void Main(string[] args) {
			const int min_number = 100;		// минимальное число в диапазоне
			const int max_number = 999;		// максимальное число в диапазоне

			string[] hundreds = { "", "сто", "двести", "триста", "четыреста", "пятьсот", "шестьсот", "семьсот", "восемьсот", "девятьсот" };
			string[] tens = { "", "", "двадцать", "тридцать", "сорок", "пятьдесят", "шестьдесят", "семьдесят", "восемьдесят", "девяносто" };
			string[] second_ten = {"десять", "одиннадцать", "двенадцать", "тринадцать", "четырнадцать",
			"пятнадцать", "шестнадцать", "семнадцать", "восемнадцать", "девятнадцать"};
			string[] units = { "", "один", "два", "три", "четыре", "пять", "шесть", "семь", "восемь", "девять" };

			int number;						// Введенное пользователем число
			string number_str;				// Число словами

			while (true) {
				try {
					Console.WriteLine("Please enter any integer number between 100 and 999");
					number = Convert.ToInt32(Console.ReadLine());
				} catch (Exception) {
					Console.WriteLine("Incorrect number. Please try again.");
					continue;
				}
				if (number < min_number || number > max_number)
					continue;
				break;
			}

			number_str = hundreds[number / 100] + " " + (number / 10 % 10 == 1 ? second_ten[number % 10] : tens[number / 10 % 10] + " " + units[number % 10]);

			Console.WriteLine("{0}{1}{2}", number, " in string: ", number_str);

			Console.ReadKey();
		}
	}
}
