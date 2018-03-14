using System;
using System.Runtime.Serialization;

namespace BankSystem {
	[Serializable]
	public class PasswordCorrectExeption : Exception {
		public PasswordCorrectExeption() {
		}
		public PasswordCorrectExeption(string message) : base(message) {
		}
		public PasswordCorrectExeption(string message, Exception innerException) : base(message, innerException) {
		}
	}
}