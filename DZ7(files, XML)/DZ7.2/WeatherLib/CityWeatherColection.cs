using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherLib {
	public class CityWeatherColection {
		private List<CityWeather> sityWeatherList;
		public List<CityWeather> CityWeatherList { get => sityWeatherList; set => sityWeatherList = value; }

		public CityWeatherColection() {
			CityWeatherList = new List<CityWeather>();
		}
		public CityWeatherColection(int cityCod) {
			CityWeatherList = new List<CityWeather>();
			AddCityWeather(cityCod);
		}

		public CityWeatherColection(int[] citysCods) {
			CityWeatherList = new List<CityWeather>();

			for (int i = 0; i < citysCods.Length; i++) {
				AddCityWeather(citysCods[i]);
			}
		}
		public void AddCityWeather(int cityCod) {
			CityWeather newItem = new CityWeather(cityCod);
			if (!CityWeatherList.Contains(newItem)) 
				CityWeatherList.Add(newItem);
		}

		public CurrencyWeather HotestWeather() {
			double Tmax = CityWeatherList[0].ListWeather[0].Tmax;
			CurrencyWeather hotestWeather = CityWeatherList[0].ListWeather[0];
			foreach (var city in CityWeatherList) {
				foreach (CurrencyWeather weather in city.ListWeather) {
					if (weather.Tmax > Tmax) {
						Tmax = weather.Tmax;
						hotestWeather = weather;
					}
				}
			}
			return hotestWeather;
		}

		public void SaveToXML() {
			for (int i = 0; i < CityWeatherList.Count; i++) {
				CityWeatherList[i].SaveToXML();
			}
		}

		public override string ToString() {
			string rezStr = "";
			for (int i = 0; i < sityWeatherList.Count; i++) {
				rezStr +=  (sityWeatherList[i] + "\n");
			}
			return rezStr;
		}
	}
}
