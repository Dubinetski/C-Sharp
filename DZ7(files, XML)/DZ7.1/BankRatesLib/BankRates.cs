using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace BankRatesLib {
	public class BankRates {
		private List<CurrencyRate> listCurrency;
		private DateTime date;
		public List<CurrencyRate> ListCurrency { get => listCurrency; private set => listCurrency = value; }
		public DateTime Date { get => date; private set => date = value; }

		public BankRates(string url) {
			XDocument doc = XDocument.Load(url);
			ListCurrency = new List<CurrencyRate>();
			foreach (var item in doc.Root.Elements()) {
				ListCurrency.Add(new CurrencyRate() {
					Code = item.Element("CharCode").Value,
					Name = item.Element("Name").Value,
					Scale = item.Element("Scale").Value,
					Rate = item.Element("Rate").Value
				});
				Date = DateTime.ParseExact(doc.Root.Attribute("Date").Value, "mm/dd/yyyy", null);
			}
		}

		public override string ToString() {
			string str = String.Format("Rate of exchange BYN on {0:dd.MM.yyyy}:\n\n", Date);
			for (int i = 0; i < ListCurrency.Count; i++) {
				str += ListCurrency[i];
				str += Environment.NewLine;
			}
			return str;
		}
	}
}
