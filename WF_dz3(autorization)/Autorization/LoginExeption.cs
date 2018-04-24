using System;

namespace Autorization {
	[System.Serializable]
	public class LoginDataExeption : Exception {
		public LoginDataExeption() { }
		public LoginDataExeption(string message) : base(message) { }
		public LoginDataExeption(string message, Exception inner) : base(message, inner) { }
		protected LoginDataExeption(
		  System.Runtime.Serialization.SerializationInfo info,
		  System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
	}
}
