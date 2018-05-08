using System;
using System.Xml.Serialization;

namespace LinqToObjects {
	[Serializable()]
	[XmlType("CD")]
	public class CD {
		private string title;
		private string artist;
		private string country;
		private string company;
		private decimal price;
		private ushort year;
		private byte producer;
		[XmlElement("TITLE")]
		public string Title { get => title; set => title = value; }
		[XmlElement("ARTIST")]
		public string Artist { get => artist; set => artist = value; }
		[XmlElement("COUNTRY")]
		public string Country { get => country; set => country = value; }
		[XmlElement("COMPANY")]
		public string Company { get => company; set => company = value; }
		[XmlElement("PRICE")]
		public decimal Price { get => price; set => price = value; }
		[XmlElement("YEAR")]
		public ushort Year { get => year; set => year = value; }
		[XmlElement("PRODUCER")]
		public byte Producer { get => producer; set => producer = value; }
	}
}
