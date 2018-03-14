/*
Задание 1.
В С # индексация начинается с нуля, но в некоторых языках программирования это не так. Например, в Turbo Pascal индексация массиве начинается с 1. 
Напишите класс SmartArray, который  позволяет работать с массивом такого типа, в котором индексный диапазон устанавливается пользователем.
Например, в диапазоне от 6 до 10, или от -9 до 15.
(Установка диапазонов в классе обеспечивается с использованием соответствующих свойств.)
 */

using System;

namespace Dubinetski {
	public class SmartArray {
		private int[] arrInt;
		private int displacement;
		public SmartArray() : this(0, 10) {
		}
		public SmartArray(int startPosition, int endPosition) {
			displacement = startPosition;
			arrInt = new int[endPosition - startPosition + 1];
		}
		public SmartArray(int startPosition, int[] values) {
			displacement = startPosition;
			arrInt = values;
		}
		/// <summary>
		/// Set or get array length
		/// </summary>
		public int Length {
			get { return arrInt.Length; }
			set {
				Array.Resize<int>(ref arrInt, value);
			}
		}
		/// <summary>
		/// Set or get number of start item of array 
		/// </summary>
		public int StartPosition {
			get { return displacement; }
			set { displacement = value; }
		}
		/// <summary>
		/// Set or get values of items in array 
		/// </summary>
		public int[] Values {
			get { return arrInt; }
			set {
				for (int i = 0; i < (arrInt.Length <= value.Length ? arrInt.Length : value.Length); i++) {
					arrInt[i] = value[i];
				}
			}
		}
		public int this[int index] {
			get {
				try {
					return arrInt[index - displacement];
				} catch {
					Console.WriteLine("{0}{1}{2}{3}{4}", index, " - out of the array range. Array items positions is from ", displacement, " to ", displacement + arrInt.Length - 1);
					return -1;
				}
			}
			set {
				try {
					arrInt[index - displacement] = value;
				} catch {
					Console.WriteLine("{0}{1}{2}{3}{4}", index, " - out of the array range. Array items positions is from ", displacement, " to ", displacement + arrInt.Length - 1);
				}
			}
		}
		/// <summary>
		/// Convert array in string
		/// </summary>
		/// <returns>array in string</returns>
		public string ToStr() {
			string str = "";
			foreach (var item in arrInt) {
				str += item.ToString() + " ";
			}
			return str;
		}
	}
}
