using System;

namespace FlySimulator {
	class Warning : Exception {
		public Warning() { }
		public Warning(string Message) : base(Message) { }
		public Warning(string Message, Exception ex) : base(Message, ex) { }
	}
	class GameOver : Exception {
		public GameOver() { }
		public GameOver(string Message) : base(Message) { }
		public GameOver(string Message, Exception ex) : base(Message, ex) { }
	}
}
