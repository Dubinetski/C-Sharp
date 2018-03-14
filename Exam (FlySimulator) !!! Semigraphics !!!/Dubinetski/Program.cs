using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dubinetski {
	class Program {
		static void Main(string[] args) {
			FlySimulator.ConsoleFlySimulator simulator = new FlySimulator.ConsoleFlySimulator();
			simulator.Go();
		}
	}
}
