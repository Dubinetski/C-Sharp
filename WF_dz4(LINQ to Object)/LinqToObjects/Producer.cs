using System;
using System.Xml.Serialization;

namespace LinqToObjects {
	[Serializable()]
	[XmlType("PRODUCER")]
	public class Producer {
		private byte id;
		private string name;
		private DateTime date;
		private ushort fee;
		[XmlElement("ID")]
		public byte Id { get => id; set => id = value; }
		[XmlElement("NAME")]
		public string Name { get => name; set => name = value; }
		[XmlElement("DATE")]
		public DateTime Date { get => date; set => date = value; }
		[XmlElement("FEE")]
		public ushort Fee { get => fee; set => fee = value; }
	}
}
