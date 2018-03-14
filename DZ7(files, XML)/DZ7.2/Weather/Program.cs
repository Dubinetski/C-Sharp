/*
Приложение, позволяющее просматривать погоду на текущую дату выбранного города.
Информация о погоде берется с сайта GisMeteo по ссылке http://informer.gismeteo.by/rss/код города.xml

Библиотека, загружает xml файл, обрабатывает его  и выводит погоду для выбранного города. 
Дополнительно:
•	пары «код-имя города» хранятся в файле, что позволяет добавлять новые города, без перекомпиляции;
•	находится самая теплая погода в представленных городах;
•	xml-файлы сохраняются для формирования статистки. 
 */	

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WeatherLib;

namespace Weather {
	class Program {
		static void Main(string[] args) {
			Dictionary<string, int> cityDict = GetCitys("Citys.txt");
			PrintCitysMenu(cityDict.Keys.ToList());

			CityWeatherColection cityWeatherColection = new CityWeatherColection(cityDict.Values.ToArray());

			Console.Write("\nIndex of city: ");
			int menuIndex = Int32.Parse(Console.ReadLine());
			Console.WriteLine();

			if (menuIndex != 0) {
				try {
					Console.WriteLine(cityWeatherColection.CityWeatherList[menuIndex - 1]);
				} catch (Exception ex) {
					Console.WriteLine(ex.Message);
				}
			} else {
				try {
					Console.WriteLine(cityWeatherColection);
				} catch (Exception ex) {
					Console.WriteLine(ex.Message);
				}
			}
			Console.WriteLine("Hottest weather in city:\n{0}", cityWeatherColection.HotestWeather());
			cityWeatherColection.SaveToXML();

			Console.ReadKey();
		}

		static Dictionary<string, int> GetCitys(string filePath) {
			string citysCod = File.ReadAllText(filePath);
			Dictionary<string, int> cityDict = new Dictionary<string, int>();
			Regex regex = new Regex(@"(\d{5}) >([А-я-]+)");
			foreach (Match item in regex.Matches(citysCod)) {
				cityDict.Add(item.Groups[2].Value, Int32.Parse(item.Groups[1].Value));
			}
			return cityDict;
		}

		static void PrintCitysMenu(List<string> citys) {
			const int INDEX_WIDTH = 5;
			const int SPASES_BEATWIN_COLUMNS = 5;
			const int MIN_COLUMN_WIDTH = 10;

			int columnWidth = MIN_COLUMN_WIDTH;

			foreach (var city in citys) {
				if (city.Length > columnWidth) {
					columnWidth = city.Length;
				}
			}
			columnWidth = INDEX_WIDTH + columnWidth + SPASES_BEATWIN_COLUMNS;
			int columnCount = Console.WindowWidth / columnWidth;
			int citysInOneColumn = (citys.Count + 1) / columnCount;
			int column;
			Console.Write("0  - All Citys");

			for (int i = 0; i < citys.Count; i++) {
				column = (i + 1) / citysInOneColumn;
				Console.SetCursorPosition(columnWidth * column, (i + 1) - (citysInOneColumn * column));
				Console.Write("{0,-3}- {1}", i + 1, citys[i]);
			}
			Console.WriteLine();
		}
	}
}