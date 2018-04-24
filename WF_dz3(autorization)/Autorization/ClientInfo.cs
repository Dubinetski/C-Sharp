using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Security.Cryptography;

namespace Autorization {
	[Serializable]
	public class ClientInfo {
		private string login;
		private Guid password;
		private Guid email;
		private string name;
		private string surname;

		private Regex regex;

		public ClientInfo(string login, string password, string email, string surname, string name) {
			regex = new Regex(@"\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,6}");
			Login = login;
			SetPassword(password);
			SetEmail(email);
			Surname = surname;
			Name = name;
		}
		public ClientInfo(string login, string password, string email) : this(login, password, email, "unknown", "unknown") { }

		/// <summary>
		/// Устанавливает E-mail адрес
		/// </summary>
		/// <param name="email">E-mail адрес</param>
		public void SetEmail(string email) {
			if (regex.Match(email).Length == email.Length)
				this.email = EncriptInMD5(email);
			else
				throw new LoginDataExeption("Некорректный E-mail адрес");
		}
		/// <summary>
		/// Проверка e-mail адреса
		/// </summary>
		/// <param name="email">Проверяемый e-mail адрес</param>
		/// <returns></returns>
		public bool CheckEmail(string email) {
			return this.email == EncriptInMD5(email);
		}
		/// <summary>
		/// Устанавливает пароль
		/// </summary>
		/// <param name="pass">Пароль</param>
		public void SetPassword(string pass) {
			if (pass.Length >= 6)
				password = EncriptInMD5(pass);
			else
				throw new LoginDataExeption("Пароль должен содержать не менее 6 символов");
		}
		/// <summary>
		/// Проверка пароля
		/// </summary>
		/// <param name="pass">Проверяемый пароль</param>
		/// <returns></returns>
		public bool CheckPassword(string pass) {
			return password == EncriptInMD5(pass);
		}

		public string Login {
			get { return login; }
			private set { login = value; }
		}
		public string Name { get => name; set => name = value; }
		public string Surname { get => surname; set => surname = value; }

		/// <summary>
		/// Шифрование строки по алгоритму MD5
		/// </summary>
		/// <param name="s">строка, которую необходимо зашифровать</param>
		/// <returns>зашифрованная строка</returns>
		private Guid EncriptInMD5(string s) {
			byte[] bytes = Encoding.Unicode.GetBytes(s);    //переводим строку в байт-массим
			MD5CryptoServiceProvider CSP = new MD5CryptoServiceProvider();  //объект со средствами шифрования
			byte[] byteHash = CSP.ComputeHash(bytes);       //хеш-представление в байтах
			string hash = string.Empty;
			foreach (byte b in byteHash)                    //формируем одну цельную строку из массива
				hash += string.Format("{0:x2}", b);
			return new Guid(hash);
		}
	}
}
