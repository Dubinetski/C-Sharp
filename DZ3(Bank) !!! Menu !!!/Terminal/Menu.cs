using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem {
	public delegate void EventHandler1(Dictionary<string, string> dict);


	public class Menu {
		private readonly int firstRow;			// позиция первой строки
		private readonly int firstColumn;		// отступ пунктов меню от левого края
		private readonly int SPLITTER = 2;		// интервал между полями меню и их значениями
		private readonly int FILD_VALUE_MAX_LENGTH = 20;   // максимальная длина значений полей
		private readonly int TITLE_SEPARATE = 3;		   // расстояние от заголовка до пунктов меню
		private readonly int menuMaxItemLength;			   // максимальная длина элемента меню

		public int SelectedItem { get; set; }			   // номер выбранного пункта меню

		private string[] menuItems;  // массив названий элементов меню, состоящий из полей и кнопок
		public string Title { get; set; }
		public Dictionary<string, string> FildsDict { get; private set; }	// коллекция названий пунктов меню и их значений


		public Menu(string title, string[] filds, string[] buttons) {
			Title = title;
			if (filds != null) {
				FildsDict = new Dictionary<string, string>();
				for (int i = 0; i < filds.Length; i++) {
					FildsDict.Add(filds[i], null);
					menuMaxItemLength = menuMaxItemLength < filds[i].Length ? filds[i].Length : menuMaxItemLength;
				}
			} else {
				FildsDict = null;
			}
			menuItems = new string[(filds?.Length ?? 0) + (buttons?.Length ?? 0)];
			filds?.CopyTo(menuItems, 0);
			buttons?.CopyTo(menuItems, filds?.Length ?? 0);

			firstRow = (Console.WindowHeight - (filds?.Length ?? 0) - (buttons?.Length ?? 0) - TITLE_SEPARATE) / 2;
			firstColumn = (Console.BufferWidth - menuMaxItemLength - SPLITTER - FILD_VALUE_MAX_LENGTH) / 2;
			SelectedItem = 0;
		}
		/// <summary>
		/// Отображает меню на консоли
		/// </summary>
		public void Show() {
			Console.Clear();
			SelectedItem = 0;
			WriteAt(Title, (Console.BufferWidth - Title?.Length ?? 0) / 2, firstRow - TITLE_SEPARATE);

			Console.ForegroundColor = ConsoleColor.Red;
			WriteAt(menuItems[0], firstColumn, firstRow);
			Console.ResetColor();
			WriteAt(FildsDict?[menuItems[0]], firstColumn + menuMaxItemLength + SPLITTER, firstRow);
			for (int i = 1; i < menuItems.Length; i++) {
				WriteAt(menuItems[i], firstColumn, firstRow + i);
				if (i < FildsDict?.Count) {
					WriteAt(FildsDict[menuItems[i]], firstColumn + menuMaxItemLength + SPLITTER, firstRow + i);
				}
			}

			Console.SetCursorPosition(firstColumn + menuMaxItemLength + SPLITTER, firstRow);
			ChoiseItem();
		}
		/// <summary>
		/// Выбор пункта меню и ввод значений полей
		/// </summary>
		public void ChoiseItem() {
			ConsoleKeyInfo key;

			while (true) {
				key = Console.ReadKey(true);
				switch (key.Key) {
					case ConsoleKey.DownArrow:        // нажата стрелка ВНИЗ
						ChangeSelectedItem(true);
						break;                        // нажата стрелка ВВЕРХ
					case ConsoleKey.UpArrow:
						ChangeSelectedItem(false);
						break;
					case ConsoleKey.Enter:
						if (SelectedItem > (FildsDict?.Count ?? 0) - 1) {
							return;
						} else {
							ChangeSelectedItem(true);
						}
						break;
					case ConsoleKey.Escape:
						Environment.Exit(0);
						break;
					default:
						if (SelectedItem < FildsDict?.Count) {	  // если пункт - поле
							if (((key.Key >= ConsoleKey.D0 && key.Key <= ConsoleKey.Z) || (key.Key >= ConsoleKey.NumPad0 && key.Key <= ConsoleKey.NumPad9))&& 
								(FildsDict[menuItems[SelectedItem]]?.Length ?? 0) < FILD_VALUE_MAX_LENGTH) // если нажатая клавиша - буква или цифра
								FildsDict[menuItems[SelectedItem]] = (FildsDict[menuItems[SelectedItem]] ?? "") + key.KeyChar; // выводим нажатый символ
							if (key.Key == ConsoleKey.Backspace && (FildsDict[menuItems[SelectedItem]]?.Length ?? 0) > 0) // если нажата клавиша Backspace
								FildsDict[menuItems[SelectedItem]] = FildsDict[menuItems[SelectedItem]].Substring(0, FildsDict[menuItems[SelectedItem]].Length - 1);
							WriteAt("".PadRight(FILD_VALUE_MAX_LENGTH), firstColumn + menuMaxItemLength + SPLITTER, firstRow + SelectedItem); // затираем область для значения поля пробелами
							WriteAt(FildsDict[menuItems[SelectedItem]], firstColumn + menuMaxItemLength + SPLITTER, firstRow + SelectedItem); // выводим новое значение поля
						}
						break;
				}
			}
		}
		public int ButtonPressedIndex() {
			return SelectedItem - (FildsDict?.Count ?? 0);
		}
		/// <summary>
		/// Перемещение по меню
		/// </summary>
		/// <param name="toNext">true - к следующему пункту меню, false - к предыдущему </param>
		protected void ChangeSelectedItem(bool toNext) {
			WriteAt(menuItems[SelectedItem], firstColumn, firstRow + SelectedItem);
			Console.ForegroundColor = ConsoleColor.Red;

			if (toNext) {
				SelectedItem = (SelectedItem == menuItems.Length - 1) ? 0 : SelectedItem + 1;
			} else {
				SelectedItem = (SelectedItem == 0) ? menuItems.Length - 1 : SelectedItem - 1;
			}
			WriteAt(menuItems[SelectedItem], firstColumn, firstRow + SelectedItem);
			Console.ResetColor();
			Console.SetCursorPosition(firstColumn + menuMaxItemLength + SPLITTER, firstRow + SelectedItem);
		}

		/// <summary>
		/// Вывод строки в заданном месте консоли
		/// </summary>
		/// <param name="s">Выводимая строка</param>
		/// <param name="x">Количество символов до начала строки (по горизонтали)</param>
		/// <param name="y">Количество строк до выводимой строки (сверху)</param>
		protected void WriteAt(string s, int x, int y) {
			if (s != null) {
				Console.SetCursorPosition(x, y);
				Console.Write(s);
			}
		}
	}
}
