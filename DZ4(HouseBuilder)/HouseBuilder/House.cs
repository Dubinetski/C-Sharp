using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseBuilder {
	class House {
		private IPart[] parts;

		 public House (IPart[] parts) {
			this.parts = parts;
		}
		public IPart[] Parts {
			get { return parts; }
			private set { parts = value; }
		}

		public override string ToString() {
			string str = "House";
			for (int i = 0; i < parts.Length; i++) {
				str += "\n";
				str += parts[i].ToString();
			}
			return str;
		}
	}						
}
