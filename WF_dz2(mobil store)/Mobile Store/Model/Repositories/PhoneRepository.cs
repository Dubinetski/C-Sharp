using Mobile_Store.Model.Entities;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Mobile_Store.Model.Repositories {
	class PhoneRepository {
		private static StoreInfo store;
		internal static StoreInfo Store { get => store; set => store = value; }
		static PhoneRepository() {
			store = new StoreInfo();
		}
		public static void Save() {
			using (FileStream file = new FileStream("data.dat", FileMode.Create)) {
				BinaryFormatter binFormatter = new BinaryFormatter();
				binFormatter.Serialize(file, Store);
			}
		}
		public static void Load() {
			using (FileStream file = new FileStream("data.dat", FileMode.Open)) {
				BinaryFormatter binFormatter = new BinaryFormatter();
				Store = binFormatter.Deserialize(file) as StoreInfo;
			}
		}
	}
}
