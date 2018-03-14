/*
«Курсы валют»
Получить и просмотреть информацию об официальном курсе белорусского рубля по отношению к иностранным валютам.
Информацию о валютах брать по ссылке http://www.nbrb.by/Services/XmlExRates.aspx
 */

using System;

namespace RateOfExchange {
	class Program {
		static void Main(string[] args) {
			string url = @"http://www.nbrb.by/Services/XmlExRates.aspx";
			try {
				BankRatesLib.BankRates rates = new BankRatesLib.BankRates(url);
				Console.WriteLine(rates);
			} catch (Exception ex) {
				Console.WriteLine(ex.Message);
			}
			Console.ReadKey();
		}
	}
}
