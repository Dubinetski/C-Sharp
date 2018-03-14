/*
Задача о максимальном произведении трех чисел массива (Задача, которую предлагали на собеседованиях в Apple).

У вас есть массив с целыми числами, в том числе и отрицательными.
Bам нужно найти самое большое произведение 3 чисел из этого массива.

Например: у вас есть массив arrayInts, содержащий числа -10, -10, 1, 3, 2.
Метод, который обрабатывает этот массив, должен вернуть 300, так как  -10 * -10 * 3 = 300. 
*/

						/* Без сортировки массива (за один проход)*/
	
using System;

namespace DZ_1._5 {
	class Program {
		static void Main(string[] args) {
			Console.WriteLine("Enter the array of integet numbers (more then 3 numbers).");

			/*Получение от пользователя строки с разбиением по пробелам и запятым с помещением в массив */
			string[] strNumbers = Console.ReadLine().Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

			int[] numbers = new int[strNumbers.Length];	 // массив полученных от пользователя чисел

			/* Преобразование массива строк в массив целых чисел */
			for (int i = 0; i < strNumbers.Length; i++) {
				Int32.TryParse(strNumbers[i], out numbers[i]);
			}

			if (numbers.Length <3) {
				Console.WriteLine("You enter less then 3 numbers");
				return;
			}

			int min = 0;			// минимальное число
			int second_min = 0;		// второе по величине число
			int max = 0;			// максимальное число
			int second_max = 0;		// предпоследнее по величине число
			int third_max = 0;		// третье из максимальных чисел

			foreach (int i in numbers) {
				if (i <= min) {
					second_min = min;
					min = i;
				} else if (i<=second_min) {
					second_min = i;
				} else if (i>=max) {
					third_max = second_max;
					second_max = max;
					max = i;
				} else if (i>=second_max) {
					third_max = second_max;
					second_max = i;
				} else if (i >= third_max) {
					third_max = i;
				}
			}
			int maxMultiplying = (min * second_min * max >= max * second_max * third_max) ? min * second_min * max : max * second_max * third_max;

			Console.WriteLine("{0}{1}", "Max multiplying of 3 numbers from array: ", maxMultiplying);

			Console.ReadKey();
		}
	}
}
