/*
Задание 2.
Создать класс Map, позволяющий работать с ДИНАМИЧЕСКИМ словарем.
Словарь (dictionary)  представляет собой сложную структуру данных, позволяющую обеспечить доступ к элементам по ключу.
Протестировать созданный класс в методе Main().	  
*/

using System;

namespace Dubinetski {
	public class Map {
		const int minSize = 10;								// минимальный размер словаря
		private const int resizeMultiplying = 2;            // множитель изменения размера массива
		private const int multiForResize = 3;               // критерий для "сжатия" массива

		int maxCount;
		int count;
		string[] keys;
		double[] values;
		/// <summary>
		/// Инициализирует новый пустой экземпляр класса
		/// </summary>
		public Map() {
			maxCount = minSize;
			count = 0;
			keys = new string[maxCount];
			values = new double[maxCount];
		}
		/// <summary>
		/// Возвращает число пар "ключ-значение", содержащихся в словаре 
		/// </summary>
		public int Count { get { return count; } }
		/// <summary>
		/// Получает массив, содержащий ключи в словаре
		/// </summary>
		public string[] Keys {
			get {
				string[] tmpKeys = new string[count];
				Array.Copy(keys, tmpKeys, count);
				return tmpKeys;
			}
		}

		/// <summary>
		/// Получает массив, содержащий значения в словаре
		/// </summary>
		public double[] Values {
			get {
				double[] tmpVal = new double[count];
				Array.Copy(values, tmpVal, count);
				return tmpVal;
			}
		}

		/// <summary>
		/// Возвращает или задает значение, связанное с указанным ключом.
		/// </summary>
		/// <param name="key">Ключ, значение которого требуется получить или задать.</param>
		/// <returns>Значение, связанное с указанным ключом.</returns>
		public double this[string key] {
			get {
					int keyPosition = Array.IndexOf(Keys, key);
				if (keyPosition !=-1) {
					return values[keyPosition];
				} else {
					throw new KeyNotExistException(key + " key is not exist in map.");        
				}
			}
			set {
				int keyPosition = Array.IndexOf(Keys, key);
				if (keyPosition != -1) {
					 values[keyPosition] = value;  
				} else {
					throw new KeyNotExistException(key+ "  is not exist in map.");        
				}
			}
		}

		/// <summary>
		/// Добавляет указанные ключ и значение в словарь.
		/// </summary>
		/// <param name="key">Ключ добавляемого элемента.</param>
		/// <param name="value">Добавляемое значение элемента.</param>
		public void Add(string key, double value) {
			if (Array.IndexOf(Keys, key) == -1) {
				if (count == maxCount) {   // если словарь полностью заполнен увеличиваем его размер в "resizeMultiplying" раз
					maxCount *= resizeMultiplying;
					Array.Resize<string>(ref keys, maxCount);
					Array.Resize<double>(ref values, maxCount);
				}
				keys[count] = key;
				values[count++] = value;
			} else {
				throw new System.ArgumentException(key + " is already exist in map.");
			}
		}
		/// <summary>
		/// Удаляет все ключи и значения из словаря
		/// </summary>
		public void Clear() {
			keys = new string[minSize];
			values = new double[minSize];
			count = 0;
			maxCount = minSize;
		}
		/// <summary>
		/// Определяет, содержится ли указанный ключ в словаре
		/// </summary>
		/// <param name="key">Ключ, который требуется найти в словаре</param>
		/// <returns>true, если словарь содержит элемент  с указанным ключом, в противном случае — false.</returns>
		public bool ContainsKey(string key) {
			return (Array.IndexOf(Keys, key) == -1) ? false : true;
		}
		/// <summary>
		/// Определяет, содержит ли словарь указанное значение.
		/// </summary>
		/// <param name="value">Значение, которое требуется найти в словаре</param>
		/// <returns>Значение true, если элемент с указанным значением, в противном случае — значение false.</returns>
		public bool ContainsValue(double value) {
			return (Array.IndexOf(values, value) == -1) ? false : true;
		}

		/// <summary>
		/// Удаляет значение с указанным ключом из словаря
		/// </summary>
		/// <param name="key">Ключ элемента, который необходимо удалить.</param>
		/// <returns>true, если элемент успешно найден и удален, в противном случае — false</returns>
		public bool Remove(string key) {
			int keyPosition = Array.IndexOf(Keys, key);
			if (keyPosition != -1) {
				keys[keyPosition] = keys[count - 1];    // для неразрывности массивов на место удаленного элемента словаря (ключ + значение) устанавливаем последний элемент
				values[keyPosition] = values[--count];
				if (count < maxCount / multiForResize && maxCount / resizeMultiplying > minSize) {  // если словарь заполнен на 1/"multiForResize" - уменьшаем вместимость в "resizeMultiplying" раз
					Array.Resize<string>(ref keys, maxCount / resizeMultiplying);
					Array.Resize<double>(ref values, maxCount / resizeMultiplying);
					maxCount /= resizeMultiplying;
				}
				return true;
			} else {
				return false;
			}
		}
		/// <summary>
		/// Получает значение, связанное с указанным ключом.
		/// </summary>
		/// <param name="key">Ключ значения, которое необходимо получить.</param>
		/// <param name="value">Возвращаемое значение, связанное с указанном ключом, если он найден; в противном
		/// случае — значение по умолчанию для данного типа параметра value. Этот параметр передается неинициализированным.</param>
		/// <returns>true, если элемент найден, false - в противном случае</returns>
		public bool TryGetValue(string key, out double value) {
			int keyPosition = Array.IndexOf(Keys, key);
			if (keyPosition != -1) {
				value = values[keyPosition];
				return true;
			} else {
				value = 0;
				return false;
			}
		}
	}
}

public class KeyNotExistException : Exception {
	public KeyNotExistException() {	}
	public KeyNotExistException(string message)	: base(message) { }
}