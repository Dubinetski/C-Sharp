using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem {
	public class Client {
		private const int ACCOUNT_MAX_COUNT = 4;
		private const byte PASSWORD_MAX_TRY_ENTER = 3;
		private const byte PASSWORD_MIN_LENGTH = 6;

		private string login;
		private string password;
		public bool IsLogined {	get;private set; }
		public int AccountCount { get; set; }
		public Account[] Accounts { get; set; }
		public string Name { get; set; }
		public string Surname { get; set; }
		public string PasportIDNO { get; set; }
		public int TryCountLeft { get; private set; }
		/// <summary>
		/// Клиент
		/// </summary>
		/// <param name="login">Логин клиента</param>
		/// <param name="password">Пароль клиента</param>
		public Client(string login, string password) {
			Login = login;
			Password = password;
			Surname = "";
			Name = "";
			PasportIDNO = "";
			AccountCount = 0;
			TryCountLeft = PASSWORD_MAX_TRY_ENTER;
			Accounts = new Account[ACCOUNT_MAX_COUNT];
			IsLogined = false;
		}
		public string Login {
			get { return login; }
			private set {
				if (String.IsNullOrWhiteSpace(value)) {
					throw new ArgumentException("Login is null or empty");
				}
				login = value;
			}
		}
		private string Password {          
			get { return password; }
			set {
				if (String.IsNullOrWhiteSpace(value)) 
					throw new PasswordCorrectExeption("Error in password", new ArgumentNullException("Password is null or white spase"));
				if (value.Length < PASSWORD_MIN_LENGTH)
					throw new PasswordCorrectExeption(String.Format("Error in password. Password is short then {0}", PASSWORD_MIN_LENGTH));
				password = value;
			}
		}
		/// <summary>
		/// Попытаться войти в учетную запись клиента
		/// </summary>
		/// <param name="password">Пароль</param>
		/// <returns>Успешность входа</returns>
		public bool TryLogin(string password) {     
			if (TryCountLeft > 0) {
				if (Password == password) {
					TryCountLeft = PASSWORD_MAX_TRY_ENTER;
					IsLogined = true;
					return true;
				} else {
					IsLogined = false;
					TryCountLeft--;
					if (TryCountLeft == 0)
						throw new PasswordCorrectExeption(String.Format("Incorrect password entered {0} times. User accaunt is blocked.", PASSWORD_MAX_TRY_ENTER));
				}
			} else {
				throw new PasswordCorrectExeption(String.Format("Incorrect password entered {0} times. User accaunt is blocked.", PASSWORD_MAX_TRY_ENTER));
			}
			return false;
		}

		/// <summary>
		/// Сменить пароль клиента
		/// </summary>
		/// <exception cref="PasswordCorrectExeption">Генерируется в случае ввода не верного текущего пароля </exception>
		/// <param name="NewPassword">Новый пароль</param>
		public void ChangePassword(string old_password, string newPassword) {
			if (old_password == Password)                      
				Password = newPassword;
			else
				throw new PasswordCorrectExeption("Error in password. Entered old password is incorrect");
		}
		/// <summary>
		/// Попытаться добавить новый аккаунт
		/// </summary>
		/// <param name="acc">Новый аккаунт</param>
		/// <returns>Успешность добавления аккаунта</returns>
		public bool TryAddAccount(Account acc) {
			if (AccountCount < Accounts.Length) {
				Accounts[AccountCount++] = acc;
				return true;
			} else {
				return false;
			}
		}
		public override string ToString() {
			return String.Format("{0} - {1}", Login, Password);
		}
	}
}
