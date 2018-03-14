using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlySimulator {
	public class ConsoleFlySimulator {
		// Размеры окна
		const int WINDOW_HEIGHT = 25;
		const int WINDOW_WIDTH = 80;
		const int STATUS_BAR_Y = WINDOW_HEIGHT - 2;

		// Список диспетчеров
		const int DISPATCHER_Y = 3;
		const int DISPATCHER_NUMBER_X = 38;
		const int DISPATCHER_NAME_X = 41;
		const int DISPATCHER_HEIGHT_X = 60;
		const int DISPATCHER_PENALTY_X = 71;
		const int DISPATCHER_LIST_WIDTH = 40;
		const int MAX_DISPATCHER_NAME_LENGTH = 15;

		// Область полета
		const int START_POSITION_X = 4;
		const int START_POSITION_Y = 18;
		const int MAX_POSITION_X = 24;
		const int MAX_POSITION_Y = 4;
		const int SPEED_X = 12;
		const int SPEED_Y = 2;
		const int HEIGHT_X = 1;
		const int HEIGHT_Y = 9;
		const int BORDER_HEIGHT_X = 26;
		const int ESCART_X = 32;

		const int MAX_CIPHER_IN_SPEED = 4;
		const int MAX_CIPHER_IN_HEIGHT = 4;
		const int MAX_CIPHER_IN_PENALTY = 4;

		int currentDispatcher;
		int xPosition = START_POSITION_X;
		int yPosition = START_POSITION_Y;
		int yLowerBorder = START_POSITION_Y;
		int yUpperBorder = START_POSITION_Y;

		public int CurrentDispatcher { get => currentDispatcher; set => currentDispatcher = value; }

		/// <summary>
		/// Отобразить экран симулятора на консоль
		/// </summary>
		private void Show() {
			Console.Clear();
			Console.Title = "FLIGHT SIMULATOR";
			Console.SetBufferSize(WINDOW_WIDTH, WINDOW_HEIGHT);
			Console.SetWindowSize(WINDOW_WIDTH, WINDOW_HEIGHT);

			Console.WriteLine(@"
        ╔═══════════════╗             №  Despatcher       Recommend   Penalty
 ╔══════╣     0  км/ч   ╠══════╗                            heigth         
 ║      ╚═══════════════╝      ║       
 ║                             ║       
 ║                             ║       
 ║                             ║        
 ║                             ║        
╔╩╗                            ║        
║ ║                            ║        
║ ║                            ║        	
║ ║                            ║        
║ ║                            ║    
╚╦╝                            ║          SPASE       START / STOP
 ║                             ║    	  1-9         Select despatcher
 ║                             ║          +/-         Add/Del despatcher
 ║                             ║          ▲/▼         Height +/- 250 m
 ║                             ║          SHIFT + ▲/▼ Height +/- 500 m
 ║                             ║          ◄/►	      Speed +/- 50 km/h
 ║_   _   _   _   _   _   _   _║          SHIFT + ◄/► Speed +/- 150 km/h
 ╚═════════════════════════════╝          ESC         End training
		     
______________________________________________________________________________
");
		}
		/// <summary>
		/// Запустить симулятор полета
		/// </summary>
		public void Go() {
			Show();
			ConsoleKeyInfo keyInfo;
			while (true) {
				keyInfo = Console.ReadKey(true);
				WriteAt("".PadLeft(WINDOW_WIDTH), 0, STATUS_BAR_Y);

				try {
					switch (keyInfo.Key) {
						case ConsoleKey.Add:
							AddDispatcher();
							break;
						case ConsoleKey.Subtract:
							DelDispatcher();
							break;
						case ConsoleKey.Spacebar:
							Aircraft.StartOrStop();
							PrintCurrentHeight();
							ChangeSpeedUpdateInfo();
							if (Aircraft.Speed == 0) {
								Console.ForegroundColor = ConsoleColor.Green;
								WriteAt("!!! CONGRATULATION !!! Test complite. (Summ pemalty: " + Aircraft.SummPenalty + ")", 0, STATUS_BAR_Y);
								Console.ResetColor();
								Reset();
							}
							break;
						case ConsoleKey.LeftArrow:
							if (keyInfo.Modifiers == ConsoleModifiers.Shift)
								Aircraft.SpeedForceChange(false);
							else
								Aircraft.SpeedChange(false);
							ChangeSpeedUpdateInfo();
							break;
						case ConsoleKey.RightArrow:
							if (keyInfo.Modifiers == ConsoleModifiers.Shift)
								Aircraft.SpeedForceChange();
							else
								Aircraft.SpeedChange();
							ChangeSpeedUpdateInfo();
							break;
						case ConsoleKey.UpArrow:
							if (keyInfo.Modifiers == ConsoleModifiers.Shift)
								Aircraft.HeightForceChange();
							else
								Aircraft.HeightChange();
							ChangeHeightUpdateInfo();
							break;
						case ConsoleKey.DownArrow:
							if (keyInfo.Modifiers == ConsoleModifiers.Shift)
								Aircraft.HeightForceChange(false);
							else
								Aircraft.HeightChange(false);
							ChangeHeightUpdateInfo();
							break;
						case ConsoleKey.Escape:
							return;
						default:
							if ((keyInfo.Key >= ConsoleKey.D1 && keyInfo.Key <= ConsoleKey.D9) ||
								(keyInfo.Key >= ConsoleKey.NumPad1 && keyInfo.Key <= ConsoleKey.NumPad9))
								DispetcherSelect(Int32.Parse(keyInfo.KeyChar.ToString()));
							break;
					}
				} catch (Warning ex) {
					Console.ForegroundColor = ConsoleColor.Yellow;
					WriteAt(ex.Message, 0, STATUS_BAR_Y);
					Console.ResetColor();
				} catch (GameOver ex) {
					Console.ForegroundColor = ConsoleColor.Red;
					WriteAt(ex.Message, 0, STATUS_BAR_Y);
					Console.ResetColor();
					return;
				} catch (Exception ex) {
					WriteAt(ex.Message, 0, STATUS_BAR_Y);
				}
			}
		}
		/// <summary>
		/// Удаление диспетчера
		/// </summary>
		private void DelDispatcher() {
			Aircraft.DelDispatcher(currentDispatcher - 1);
			DispatcherInfoFullUpdate();
			currentDispatcher = Aircraft.Dispatchers.Count;
		}
		/// <summary>
		/// Обновить информацию после изменения скорости
		/// </summary>
		private void ChangeSpeedUpdateInfo() {
			WriteAt(Aircraft.Speed.ToString().PadRight(Dispatcher.MAX_SPEED.ToString().Length), SPEED_X, SPEED_Y);
			DispatchersInfoUpdate();
			ChangePosition(Aircraft.Speed, Aircraft.Height);
		}
		/// <summary>
		/// Обновить информацию после изменения высоты полета
		/// </summary>
		private void ChangeHeightUpdateInfo() {
			PrintCurrentHeight();
			DispatchersInfoUpdate(false);
			ChangePosition(Aircraft.Speed, Aircraft.Height);
		}
		private void DispetcherSelect(int dispIndex) {
			if (dispIndex <= Aircraft.Dispatchers.Count) {// если нажатая цифра
				WriteAt(currentDispatcher, DISPATCHER_NUMBER_X, DISPATCHER_Y + currentDispatcher);
				currentDispatcher = dispIndex;
				Console.ForegroundColor = ConsoleColor.Red;
				WriteAt(currentDispatcher, DISPATCHER_NUMBER_X, DISPATCHER_Y + currentDispatcher);
				Console.ResetColor();
			}
		}
		/// <summary>
		/// Добавление нового диспетчера
		/// </summary>
		private void AddDispatcher() {
			Console.SetCursorPosition(DISPATCHER_NAME_X, DISPATCHER_Y + (Aircraft.Dispatchers?.Count ?? 0) + 1);
			string newDispName = EnterText(MAX_DISPATCHER_NAME_LENGTH, DISPATCHER_NAME_X, DISPATCHER_Y + (Aircraft.Dispatchers?.Count ?? 0) + 1);
			if (newDispName != null) {
				Aircraft.AddDispatcher(newDispName);
				PrintDispatcherInfo(Aircraft.Dispatchers.Count - 1);

				ChangePosition(Aircraft.Speed, Aircraft.Height);
				CurrentDispatcher = Aircraft.Dispatchers.Count;
			}
		}
		/// <summary>
		/// Изменить позицию самолета
		/// </summary>
		/// <param name="newSpeed">Новая скорость</param>
		/// <param name="newHeight">Новая высота полета</param>
		private void ChangePosition(int newSpeed, int newHeight) {
			WriteAt("  ", xPosition, yPosition);
			xPosition = START_POSITION_X + (MAX_POSITION_X - START_POSITION_X) * Aircraft.Speed / Dispatcher.MAX_SPEED;

			yPosition = (newHeight <= (START_POSITION_Y - MAX_POSITION_Y) * Aircraft.HEIGHT_CHANGE_STEP / 2) ?
				 START_POSITION_Y - newHeight / Aircraft.HEIGHT_CHANGE_STEP :
				 MAX_POSITION_Y + (START_POSITION_Y - MAX_POSITION_Y) / 2;

			if (newSpeed >= Dispatcher.MIN_CONTROL_SPEED)
				ChangeAirPassage();
			WriteAt("═>", xPosition, yPosition);
		}
		/// <summary>
		/// Изменить воздушный коридор
		/// </summary>
		private void ChangeAirPassage() {
			RemoveBorderPassage(yLowerBorder);
			RemoveBorderPassage(yUpperBorder);
			PrintBorderPassage(Aircraft.MinHeight, Aircraft.LowerPassageBorderEcart, false);
			PrintBorderPassage(Aircraft.MaxHeight, Aircraft.UpperPassageBorderEcart);
		}
		/// <summary>
		/// Удалить границу воздушного коридора
		/// </summary>
		/// <param name="yPos"></param>
		private void RemoveBorderPassage(int yPos) {
			if (yPos <= START_POSITION_Y && yPos >= MAX_POSITION_Y) {
				WriteAt("".PadLeft(MAX_POSITION_X - START_POSITION_X + MAX_CIPHER_IN_HEIGHT + 2), START_POSITION_X, yPos);
				WriteAt("".PadLeft(MAX_CIPHER_IN_HEIGHT + 1), ESCART_X, yPos);
			}
		}
		/// <summary>
		/// Печать границы воздушного коридора
		/// </summary>
		/// <param name="height">Текущая высота</param>
		/// <param name="ecart">Текущее отклонение от границы</param>
		/// <param name="isUpper">Верхняя граница?</param>
		private void PrintBorderPassage(int height, int ecart, bool isUpper = true) {
			int yBord = yPosition - ((ecart / Aircraft.HEIGHT_CHANGE_STEP) + (ecart > 0 ? 1 : (ecart < 0) ? -1 : 0)) * (isUpper ? 1 : -1);

			if (yBord <= START_POSITION_Y && yBord >= MAX_POSITION_Y && Aircraft.Speed > 0) {
				WriteAt("─────────────────────", START_POSITION_X, yBord);
				WriteAt(height, BORDER_HEIGHT_X, yBord);
				WriteAt((ecart * (isUpper ? 1 : -1)).ToString(), ESCART_X, yBord);
			}
			if (isUpper)
				yUpperBorder = yBord;
			else
				yLowerBorder = yBord;
		}
		/// <summary>
		/// Печать текущей высоты
		/// </summary>
		private void PrintCurrentHeight() {
			for (int i = 0; i < MAX_CIPHER_IN_HEIGHT; i++) {
				WriteAt((i < Aircraft.Height.ToString().Length) ? Aircraft.Height.ToString()[i].ToString() : " ", HEIGHT_X, HEIGHT_Y + i);
			}
		}
		/// <summary>
		/// Обновление информации от диспетчеров
		/// </summary>
		/// <param name="dispatchers">Список диспетчеров</param>
		/// <param name="isSpeedChanged">Признак изменения скорости полета</param>
		private void DispatchersInfoUpdate(bool isSpeedChanged = true) {
			for (int i = 0; i < Aircraft.Dispatchers.Count; i++) {
				if (isSpeedChanged)
					WriteAt(Aircraft.Dispatchers[i].RecommendHeigth.ToString().PadRight(MAX_CIPHER_IN_HEIGHT), DISPATCHER_HEIGHT_X, DISPATCHER_Y + i + 1);
				WriteAt(Aircraft.Dispatchers[i].Penalty.ToString().PadRight(MAX_CIPHER_IN_PENALTY), DISPATCHER_PENALTY_X, DISPATCHER_Y + i + 1);
			}
		}
		private void DispatcherInfoFullUpdate() {
			for (int i = 0; i < Aircraft.MAX_COUNT_OF_DISPATCHERS; i++) {
				DelDispatcherInfo(i);
				PrintDispatcherInfo(i);
			}
		}
		/// <summary>
		/// Удалить информацию от диспетчера
		/// </summary>
		/// <param name="dispIndex">Индекс диспетчера</param>
		private void DelDispatcherInfo(int dispIndex) {
			if (dispIndex < Aircraft.MAX_COUNT_OF_DISPATCHERS)
				WriteAt("".PadRight(WINDOW_WIDTH - DISPATCHER_NUMBER_X), DISPATCHER_NUMBER_X, DISPATCHER_Y + dispIndex + 1);
		}
		/// <summary>
		/// Печать информации от диспетчера
		/// </summary>
		/// <param name="dispIndex">Индекс диспетчера</param>
		private void PrintDispatcherInfo(int dispIndex) {
			if (dispIndex < Aircraft.Dispatchers.Count) {
				WriteAt(dispIndex + 1, DISPATCHER_NUMBER_X, DISPATCHER_Y + dispIndex + 1);
				WriteAt(Aircraft.Dispatchers[dispIndex].Name, DISPATCHER_NAME_X, DISPATCHER_Y + dispIndex + 1);
				WriteAt(Aircraft.Dispatchers[dispIndex].RecommendHeigth, DISPATCHER_HEIGHT_X, DISPATCHER_Y + dispIndex + 1);
				WriteAt(Aircraft.Dispatchers[dispIndex].Penalty, DISPATCHER_PENALTY_X, DISPATCHER_Y + dispIndex + 1);
			}
		}
		/// <summary>
		/// Сбросить информацию
		/// </summary>
		private void Reset() {
			DispatcherInfoFullUpdate();
			RemoveBorderPassage(yLowerBorder);
			RemoveBorderPassage(yUpperBorder);
		}
		/// <summary>
		/// Печать текста
		/// </summary>
		/// <param name="maxLength">Максимальная длина текста</param>
		/// <param name="x">Отступ слева</param>
		/// <param name="y">Отступ сверху</param>
		/// <returns>Напечатанная строка</returns>
		private string EnterText(int maxLength, int x, int y) {
			String rezStr = "";
			ConsoleKeyInfo key;
			bool isContinue = true;
			while (isContinue) {
				key = Console.ReadKey(true);
				switch (key.Key) {
					case ConsoleKey.Backspace:
						if (rezStr?.Length > 0)
							rezStr = rezStr.Substring(0, rezStr.Length - 1);
						break;
					case ConsoleKey.Enter:
						isContinue = false;
						break;
					case ConsoleKey.Escape:
						rezStr = null;
						break;
					default:
						if (((key.Key >= ConsoleKey.D0 && key.Key <= ConsoleKey.Z) || (key.Key >= ConsoleKey.NumPad0 && key.Key <= ConsoleKey.NumPad9)) &&
							(rezStr?.Length < maxLength)) // если нажатая клавиша - буква или цифра и длина строки меньше допустимой
							rezStr = (rezStr ?? "") + key.KeyChar; // добавляем нажатый символ к строке
						break;
				}
				WriteAt("".PadRight(maxLength), x, y); // затираем область для значения поля пробелами
				WriteAt(rezStr, x, y); // выводим новое значение поля
			}
			return rezStr;
		}
		/// <summary>
		/// Печать текста, начиная с заданных координат
		/// </summary>
		/// <param name="obj">Объект</param>
		/// <param name="x">Отступ слева</param>
		/// <param name="y">Отступ сверу</param>
		private void WriteAt(Object obj, int x, int y) {
			if (obj != null) {
				Console.SetCursorPosition(x, y);
				Console.Write(obj);
			}
		}
	}
}
