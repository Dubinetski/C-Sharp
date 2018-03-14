using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherLib {
	public class CurrencyWeather {
		public string City { get; set; }
		public DateTime Date { get; set; }
		public string DayTime { get; set; }
		public int Tmin { get; set; }
		public int Tmax { get; set; }
		public int Bmin { get; set; }
		public int Bmax { get; set; }
		public int WitdSpeed { get; set; }
		public string WindStream { get; set; }

		public override string ToString() {
			return String.Format("{0} {1:dd MMM}({2}): Температура {3}..{4}, Давление {5}..{6}, ветер {7} {8} м/с",
				City, Date, DayTime, Tmin, Tmax, Bmin, Bmax, WindStream, WitdSpeed);
		}
	}
}
