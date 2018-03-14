/*
Задача о максимальном произведении трех чисел массива (Задача, которую предлагали на собеседованиях в Apple).

У вас есть массив с целыми числами, в том числе и отрицательными.
Bам нужно найти самое большое произведение 3 чисел из этого массива.

Например: у вас есть массив arrayInts, содержащий числа -10, -10, 1, 3, 2.
Метод, который обрабатывает этот массив, должен вернуть 300, так как  -10 * -10 * 3 = 300. 
*/

					/* С сортировкой массива */

using System;

namespace DZ_1._5 {
	class Program {
		static void Main(string[] args) {
			Console.WriteLine("Enter the array of integet numbers (more then 3 numbers).");

			/*Получение от пользователя строки с разбиением по пробелам и запятым с помещением в массив */	  
			string[] strNumbers = Console.ReadLine().Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

			int[] numbers = new int[strNumbers.Length];     // массив полученных от пользователя чисел

			/* Преобразование массива строк в массив целых чисел */
			for (int i = 0; i < strNumbers.Length; i++) {
				Int32.TryParse(strNumbers[i], out numbers[i]);
			}

			if (numbers.Length < 3) {
				Console.WriteLine("You enter less then 3 numbers");
				return;
			}

			Array.Sort(numbers);		// сортировка массива по возрастанию

			int maxMultiplying;			// максимальное произведение трех чисел в массиве
			if (numbers[0] * numbers[1] * numbers[numbers.Length - 1] >= numbers[numbers.Length - 1] * numbers[numbers.Length - 2] * numbers[numbers.Length - 3]) {
				maxMultiplying = numbers[0] * numbers[1] * numbers[numbers.Length - 1];
			} else {
				maxMultiplying=numbers[numbers.Length - 1] * numbers[numbers.Length - 2] * numbers[numbers.Length - 3];
			}
			Console.WriteLine("{0}{1}", "Max multiplying of 3 numbers from array: ", maxMultiplying);

			Console.ReadKey();
		}
	}
}
