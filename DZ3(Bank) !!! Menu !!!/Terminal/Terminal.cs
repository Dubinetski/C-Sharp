using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem {
	class Terminal {
		/// <summary>
		/// Работа с меню банка
		/// </summary>
		public static void BankMenu() {
			Menu startMenu = new Menu("Welcom to BankSystem!", null, new string[] { "REGISTRATION", "LOGIN", "EXIT" });

			while (true) {
				startMenu.Show();
				switch (startMenu.ButtonPressedIndex()) {
					case 0:
						GetRegMenu();
						break;
					case 1:
						GetLoginMenu();
						break;
					case 2:
						Environment.Exit(0);
						break;
					default:
						break;
				}
			}
		}
		/// <summary>
		/// Работа с меню регистрации нового клиента 
		/// </summary>
		protected static void GetRegMenu() {
			string[] filds = new string[] { "Login", "Password", "Surname", "Name", "Pasport IDNO" };
			string[] buttons = new string[] { "REGISTRATION", "CANCEL", "EXIT" };
			string title = "Registration data";
			Menu regMenu = new Menu(title, filds, buttons);
			Client newClient;

			while (true) {
				regMenu.Show();
				try {
					newClient = new Client(regMenu.FildsDict["Login"], regMenu.FildsDict["Password"]) {
						Surname = regMenu.FildsDict["Surname"],
						Name = regMenu.FildsDict["Name"],
						PasportIDNO = regMenu.FildsDict["Pasport IDNO"],
					};
					if (Bank.TryAddNewClient(newClient)) {
						if (regMenu.ButtonPressedIndex() == 0) {
							ClientMenu(newClient);
							return;
						} else if (regMenu.ButtonPressedIndex() == 2) {
							Environment.Exit(0);
						}
					} else {
						regMenu.Title = "Accaunt whith this login already exist. Choice another login.";
					}
				} catch (PasswordCorrectExeption ex) {
					regMenu.Title = ex.Message;
				}
			}
		}
		/// <summary>
		/// Работа с меню авторизации клиента банка
		/// </summary>
		protected static void GetLoginMenu() {
			Menu loginMenu = new Menu("Enter you registration data for enter:",
				new string[] { "Login", "Password" },
				new string[] { "ENTER", "BACK", "EXIT" });
			Client client;

			while (true) {
				loginMenu.Show();
				if (loginMenu.ButtonPressedIndex() == 0 && loginMenu.FildsDict["Login"] != null && loginMenu.FildsDict["Password"] != null) {
					try {
						client = Bank.GetClient(loginMenu.FildsDict["Login"], loginMenu.FildsDict["Password"]);
						if (client != null) {
							if (client.IsLogined) {
								ClientMenu(client);
								return;
							} else {
								loginMenu.Title = String.Format("Incorrect password. Remain {0} trying.", client.TryCountLeft);
							}
						} else {
							loginMenu.Title = "Incorrect login. Verify corrections of login entering.";
						}
					} catch (PasswordCorrectExeption ex) {
						loginMenu.Title = ex.Message;
					}
				} else if (loginMenu.ButtonPressedIndex() == 1) {
					return;
				} else if (loginMenu.ButtonPressedIndex() == 2) {
					Environment.Exit(0);
				} else {
					loginMenu.Title = "Please enter the login and password";
				}
				loginMenu.FildsDict["Password"] = null;
			}
		}
		/// <summary>
		/// Меню клиента банка
		/// </summary>
		/// <param name="client"></param>
		protected static void ClientMenu(Client client) {
			string[] buttons;
			Menu clientMenu;

			while (true) {
				buttons = new string[(client.Accounts == null ? 0 : client.AccountCount) + 3];
				if (client.Accounts != null && client.AccountCount > 0) {
					Array.ConvertAll(client.Accounts, n => n?.ToString() ?? null).CopyTo(buttons, 0);
				}
				buttons[buttons.Length - 3] = "Add new accaunt";
				buttons[buttons.Length - 2] = "BACK";
				buttons[buttons.Length - 1] = "EXIT";
				clientMenu = new Menu(String.Format("Hello, {0}. Choice the account.", ((client?.Name ?? "") == "") ? "client" : client.Name), null, buttons);
				clientMenu.Show();
				if (clientMenu.ButtonPressedIndex() == buttons.Length - 3) {
					RegAccauntMenu(client);
				} else if (clientMenu.ButtonPressedIndex() == buttons.Length - 2) {
					return;
				} else if (clientMenu.ButtonPressedIndex() == buttons.Length - 1) {
					Environment.Exit(0);
				} else {
					ClientAccauntMenu(client, client.Accounts[clientMenu.ButtonPressedIndex()]);
				}
			}
		}
		/// <summary>
		/// Меню добавления нового аккаунта клиента
		/// </summary>
		/// <param name="client"></param>
		protected static void RegAccauntMenu(Client client) {
			string[] carrency = Enum.GetNames(typeof(Currency));
			string[] buttons = new string[carrency.Length + 2];
			Array.Copy(carrency, buttons, carrency.Length);
			buttons[buttons.Length - 2] = "CANCEL";
			buttons[buttons.Length - 1] = "EXIT";

			Menu regAccauntMenu = new Menu(String.Format("Client: {0}. Choice currency for new accaunt.", client.Login), null, buttons);
			Account newAccount;

			while (true) {
				regAccauntMenu.Show();

				if (regAccauntMenu.ButtonPressedIndex() < buttons.Length - 2) {
					newAccount = new Account((Currency)regAccauntMenu.ButtonPressedIndex());
					client.TryAddAccount(newAccount);
					ClientAccauntMenu(client, client.Accounts[client.AccountCount - 1]);
				} else if (regAccauntMenu.ButtonPressedIndex() == buttons.Length - 1) {
					Environment.Exit(0);
				} else {
					return;
				}
			}
		}
		/// <summary>
		/// Работа с аккаунтом клиента
		/// </summary>
		/// <param name="client"></param>
		/// <param name="accaunt"></param>
		protected static void ClientAccauntMenu(Client client, Account accaunt) {
			Menu accauntMenu = new Menu("",
				new string[] { "Summ" },
				new string[] { "DEPOSIT", "WITHDRAW", "BACK", "EXIT" });
			decimal changeSumm;
			string status = "";

			while (true) {
				accauntMenu.Title = String.Format("Client: {0}. Accaunt: {1}. ({2})", client.Login, accaunt.ToString(), status);
				accauntMenu.Show();

				switch (accauntMenu.ButtonPressedIndex()) {
					case 0:
						if (Decimal.TryParse(accauntMenu.FildsDict["Summ"], out changeSumm)) {
							accaunt.Deposit(changeSumm);
							status = String.Format("OK. Deposit {0} {1}", changeSumm, accaunt.GetAccountCurrency());
						} else {
							status = "EROOR. Incorrect format";
						}
						break;
					case 1:
						if (Decimal.TryParse(accauntMenu.FildsDict["Summ"], out changeSumm)) {
							if (accaunt.TryWithdrawal(changeSumm)) {
								status = String.Format("OK. Withdraw {0} {1}", changeSumm, accaunt.GetAccountCurrency());
							} else {
								status = String.Format("EROOR. Insufficient funds.");
							}
						} else {
							status = "EROOR. Incorrect format";
						}
						break;
					case 2:
						return;
					default:
						break;
				}
				accauntMenu.FildsDict["Summ"] = null;
			}
		}
	}
}
