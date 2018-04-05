using System;

namespace Mobile_Store.Model.Entities {
	[Serializable]
	public class Option {
		private int id;
		private string name;

		public Option(int id, string option) {
			Id = id;
			Name = option;
		}
		public int Id { get => id; set => id = value; }
		public string Name { get => name; set => name = value; }


		public override string ToString() {
			return name;
		}
	}
}
