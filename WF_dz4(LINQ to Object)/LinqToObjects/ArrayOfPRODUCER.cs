using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace LinqToObjects {
	[Serializable()]
	public class ArrayOfPRODUCER {
		private List<Producer> producersList;
		[XmlElement("PRODUCER")]
		public List<Producer> ProducersList { get => producersList; set => producersList = value; }
	}
}