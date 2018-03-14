using System;

namespace BankRatesLib {
	public class CurrencyRate {
		public string Code { get; set; }
		public string Name { get; set; }
		public string Scale { get; set; }
		public string Rate { get; set; }

		public override string ToString() {
			return String.Format("{0} {1,-20} {2} : {3}", Code, Name, Scale, Rate);
		}
	}
}
