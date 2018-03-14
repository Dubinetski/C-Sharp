using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem {
	public static class Bank {
		private const int minClientsCount = 10;
		private const byte koefUpResize = 2;
		private const byte koefDownResize = 3;

		private static int lastAccauntNumber;
		public static int BaseWithdrawalPercent { get; private set; }
		private static Client[] clients;
		public static int  ClientsCount { get; set; }
		/// <summary>
		/// Банк
		/// </summary>
		static Bank() {
			clients = new Client[minClientsCount];
			ClientsCount = 0;
			BaseWithdrawalPercent = 0;
		}
		/// <summary>
		/// Получить новый номер аккаунта
		/// </summary>
		/// <returns>Следующий свободный номер аккаунта</returns>
		public static int GetNewAccauntNumber() {
			return ++lastAccauntNumber;
		}
		/// <summary>
		/// Получение клиента банка
		/// </summary>
		/// <param name="login">Логин клиента</param>
		/// <param name="password">Пароль клиента</param>
		/// <returns>Клиент банка</returns>
		public static Client GetClient(string login, string password) {
			for (int i = 0; i < ClientsCount; i++) {
				if (clients[i].Login == login) {
					clients[i].TryLogin(password);
					return clients[i];
				}
			}
			return null;
		}
		/// <summary>
		/// Попытаться добавить нового клиента
		/// </summary>
		/// <param name="newClient">Клиент, который хотел бы зарегистрироваться в банке</param>
		/// <returns>Успешность регистрации</returns>
		public static bool TryAddNewClient(Client newClient) {
			if (Array.IndexOf(clients, newClient.Login) == -1) {
				if (ClientsCount < clients.Length) {
					clients[ClientsCount++] = newClient;
				} else {
					Array.Resize(ref clients, ClientsCount * koefUpResize);
				}
				return true;
			} else {
				return false;
			}
		}
	}
}
