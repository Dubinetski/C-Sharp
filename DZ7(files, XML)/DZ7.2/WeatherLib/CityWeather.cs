using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Text.RegularExpressions;
using System.Globalization;
using System.IO;

namespace WeatherLib {
	public class CityWeather {
		private List<CurrencyWeather> listWeather;
		private string city;
		private string url;
		private bool isWeatherLoding;
		private XDocument doc;

		public CityWeather(int sityCod) {
			GetCityUrl(sityCod);
		}
		public List<CurrencyWeather> ListWeather {
			get {
				if (!isWeatherLoding) Update();
				return listWeather;
			}
			private set => listWeather = value;
		}

		public string City {
			get {
				if (!isWeatherLoding) Update();
				return city;
			}
			private set => city = value;
		}
		public string Url {
			get => url;
			set {
				url = value;
				isWeatherLoding = false;
			}
		}
		private void GetCityUrl(int cityCod) {
			Url = @"http://informer.gismeteo.by/rss/" + cityCod.ToString() + ".xml";
		}

		public void Update() {
			doc = XDocument.Load(Url);
			ListWeather = new List<CurrencyWeather>();
			Regex regex;
			Match match;
			CurrencyWeather weather;
			isWeatherLoding = true;

			foreach (var item in doc.Root.Element("channel").Elements("item")) {
				weather = new CurrencyWeather();
				regex = new Regex(@"([а-яА-ЯёЁ]+): ([а-яА-ЯёЁ]+) ([0-9 A-z]+)");
				match = regex.Match(item.Element("title").Value);
				if (city == null) 
					City = match.Groups[1].Value;
				weather.City = city;
				weather.DayTime = match.Groups[2].Value;
				weather.Date = DateTime.ParseExact(match.Groups[3].Value + " " + DateTime.Now.Year.ToString(), "dd MMM yyyy", CultureInfo.InvariantCulture);

				regex = new Regex(@"температура (-?\d{1,2})..(-?\d{1,2}) С, давление (\d{3})..(\d{3}) мм рт.ст., ветер ([а-яА-ЯёЁ-]+), (\d+) м/с");
				match = regex.Match(item.Element("description").Value);
				weather.Tmin = Int32.Parse(match.Groups[1].Value);
				weather.Tmax = Int32.Parse(match.Groups[2].Value);
				weather.Bmin = Int32.Parse(match.Groups[3].Value);
				weather.Bmax = Int32.Parse(match.Groups[4].Value);
				weather.WindStream = match.Groups[5].Value;
				weather.WitdSpeed = Int32.Parse(match.Groups[6].Value);

				regex = new Regex(@"([А-Я])[а-я]+-?([А-Я]?)[а-я]*");
				match = regex.Match(weather.WindStream);
				weather.WindStream = match.Groups[1].Value + match.Groups[2]?.Value ?? "";

				ListWeather.Add(weather);
			}
		}

		public override string ToString() {
			string str = City + "\n";
			for (int i = 0; i < ListWeather.Count; i++) {
				str += String.Format("{0:dd MMM} {1,5}: T = {2,3}..{3,-3} °С, B = {4}..{5} мм рт.ст, ветер {6} м/с ({7})\n",
					ListWeather[i].Date, ListWeather[i].DayTime,
					ListWeather[i].Tmin, ListWeather[i].Tmax,
					ListWeather[i].Bmin, ListWeather[i].Bmax,
					ListWeather[i].WitdSpeed, ListWeather[i].WindStream);
			}
			return str;
		}

		public void SaveToXML() {
			Update();
			try {
				if (!Directory.Exists(@".\CityWeatherSaves"))
					Directory.CreateDirectory(@".\CityWeatherSaves");
				if (!Directory.Exists(@".\CityWeatherSaves\" + City)) 
					Directory.CreateDirectory(@".\CityWeatherSaves\" + City);
				doc.Save(String.Format(@".\CityWeatherSaves\{0}\{1:dd/MM/yyyy HH}.xml", City, DateTime.Now));
			} catch (Exception ex) {
				Console.WriteLine(ex.Message);
			}
		}

		public override bool Equals(object obj) {
			if (obj is CityWeather)
				if (((CityWeather)obj).Url == Url)
					return true;
			return false;
		}
	}
}
