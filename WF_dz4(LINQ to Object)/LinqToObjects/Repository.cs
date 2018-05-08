using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace LinqToObjects {
	class Repository {
		private static ArrayOfCD cdCatalog;
		private static ArrayOfPRODUCER producers;
		public static ArrayOfCD CdCatalog { get => cdCatalog; set => cdCatalog = value; }
		public static ArrayOfPRODUCER Producers { get => producers; set => producers = value; }

		static Repository() {
			cdCatalog = new ArrayOfCD();
			producers = new ArrayOfPRODUCER();
		}
		public static void Save() {
			using (FileStream fs = new FileStream(@".\XMLs\cdCatalog.xml", FileMode.Create)) {
				XmlSerializer xmlFormatter = new XmlSerializer(typeof(ArrayOfCD));
				xmlFormatter.Serialize(fs, cdCatalog);
			}
			using (FileStream fs = new FileStream(@".\XMLs\producers.xml", FileMode.Create)) {
				XmlSerializer xmlFormatter = new XmlSerializer(typeof(ArrayOfPRODUCER));
				xmlFormatter.Serialize(fs, producers);
			}
		}

		public static void Load() {
			using (FileStream fs = new FileStream(@".\XMLs\cdCatalog.xml", FileMode.Open)) {
				XmlSerializer xmlFormatter = new XmlSerializer(typeof(ArrayOfCD));
			cdCatalog=	xmlFormatter.Deserialize(fs) as ArrayOfCD;
			}
			using (FileStream fs = new FileStream(@".\XMLs\producers.xml", FileMode.Open)) {
				XmlSerializer xmlFormatter = new XmlSerializer(typeof(ArrayOfPRODUCER));
				producers = xmlFormatter.Deserialize(fs) as ArrayOfPRODUCER;
			}
		}
	}
}
