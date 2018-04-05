using System;
using System.Collections.Generic;

namespace Mobile_Store.Model.Entities {
	[Serializable]
	class PhoneInfo {
		private int id;
		private string manufacturer;
		private string model;
		private decimal screen;
		private decimal price;
		private string system;
		private decimal memory;
		private string photo;
		private List<int> optionsId;

		public PhoneInfo() {
			optionsId = new List<int>();
		}
		public int Id { get => id; set => id = value; }
		public string Manufacturer { get => manufacturer; set => manufacturer = value; }
		public string Model { get => model; set => model = value; }
		public decimal Screen { get => screen; set => screen = value; }
		public string System { get => system; set => system = value; }
		public decimal Memory { get => memory; set => memory = value; }
		public string Photo { get => photo; set => photo = value; }
		public List<int> OptionsId { get => optionsId; set => optionsId = value; }
		public decimal Price { get => price; set => price = value; }

		public override string ToString() {
			return String.Format("{0} {1} ({2:N2})", manufacturer, model, price);
		}
	}
}

