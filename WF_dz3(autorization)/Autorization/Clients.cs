using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autorization {
	[Serializable]
	class Clients {
		private Dictionary<string, ClientInfo> clients;

		public Clients() {
			clients = new Dictionary<string, ClientInfo>();
		}
		public Clients(Dictionary<string, ClientInfo> clients) {
			this.clients = clients;
		}
		public ClientInfo GetClient(string login) {
			ClientInfo client;
			clients.TryGetValue(login, out client);
			return client;
		}
		public void Add(ClientInfo newClient) {
			if (!clients.ContainsKey(newClient.Login)) {
				clients.Add(newClient.Login, newClient);
			} else {
				throw new LoginDataExeption("This login already exist.");
			}
		}
	}
}
