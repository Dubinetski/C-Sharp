using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Autorization {
	class ClientsRepository {
		private static Clients clients;

		internal static Clients Clients { get => clients; set => clients = value; }

		static ClientsRepository() {
			clients = new Clients();
		}
		public static void Save() {
			using (FileStream file = new FileStream("data.dat", FileMode.Create)) {
				BinaryFormatter binFormatter = new BinaryFormatter();
				binFormatter.Serialize(file, clients);
			}
		}
		public static void Load() {
			using (FileStream file = new FileStream("data.dat", FileMode.Open)) {
				BinaryFormatter binFormatter = new BinaryFormatter();
				clients = binFormatter.Deserialize(file) as Clients;
			}
		}
	}
}
