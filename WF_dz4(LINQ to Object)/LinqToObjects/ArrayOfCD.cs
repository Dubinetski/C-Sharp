using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace LinqToObjects {
	[Serializable()]
	public class ArrayOfCD {
		private List<CD> cds;
		[XmlElement("CD")]
		public List<CD> CDs { get => cds; set => cds = value; }
	}
}
