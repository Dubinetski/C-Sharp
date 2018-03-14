/*
Задача о преобразовании массива с целыми числами

Исходные данные: массив с числами типа int.
Вам нужно написать метод, который на входе получит исходный массив, а на выходе вернет массив,
в котором каждое значение получено путем произведения всех значений исходного массива с отличным от текущего индексом.

Для ясности - пример. Исходный массив имеет вид:
[1, 7, 3, 4]
Тогда функция должна вернуть:
[84, 12, 28, 21]
Расчет значений происходит следующим образом:
[7*3*4, 1*3*4, 1*7*4, 1*7*3]	 
*/
	 
using System;

namespace DZ_1._6 {
	class Program {
		static void Main(string[] args) {
			Console.WriteLine("Enter the array of integer numbers.");

			/*Получение от пользователя строки с разбиением по пробелам и запятым с помещением в массив */
			string[] strNumbers = Console.ReadLine().Split(new[] { ' ', ','}, StringSplitOptions.RemoveEmptyEntries);

			int[] initialArray = new int[strNumbers.Length];
			int[] rezultArray = new int[strNumbers.Length];

			/* Преобразование массива строк в массив целых чисел */
			for (int i = 0; i < strNumbers.Length; i++) {
				Int32.TryParse(strNumbers[i], out initialArray[i]);
			}

			int multiArray = 1;	// произведение всех элементов массива (за исключением нулевых)
			int zeroPlacePosition = -1;	 // позиция элемента массива со значением равным нулю

			/* Вычисление произведения всех элементов массива */
			for (int i = 0; i < initialArray.Length; i++) {
				if (initialArray[i] == 0) {			// если текущий элемент массива нулевой
					if (zeroPlacePosition < 0) {	// если ранее нулевых элементов не встречалось
						zeroPlacePosition = i;		// запоминаем номер элемента
						continue;
					} else {						// если до этого уже встречался нулевой элемент
						multiArray = 0;
						break;
					}
				}
				multiArray *= initialArray[i];
			}


			if (zeroPlacePosition >= 0) {			// если в массиве имеется хотябы одно нулевое значение
				rezultArray[zeroPlacePosition] = multiArray;	// устанавливаем на место нулевого элемента значение произведения всех остальных элементов (остальные "устанавливаем" нулями)
			} else {
				for (int i = 0; i < rezultArray.Length; i++) {
					rezultArray[i] = multiArray / initialArray[i];
				}
			}
			Console.WriteLine();
			Console.WriteLine("Rezult array:");
			for (int i=0; i<rezultArray.Length; i++) {
				Console.Write("{0}{1}", rezultArray[i], i < rezultArray.Length - 1 ? ", ": "");
			}	   

			Console.ReadKey();
		}
	}
}
