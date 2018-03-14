using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseBuilder {
	class Program {
		static void Main(string[] args) {
			IPart[] parts = { new Basement(100, 150, 1), new Walls(50, 50, 4), new Doors(20, 10, 1), new Windows(20, 10, 4), new Roof(30, 100, 1) };
			House house = new House(parts);

			Worker worker = new Worker();
			TeamLeader teamLeader = new TeamLeader();
			Team team = new Team(teamLeader, worker, 2);

			team.Work(parts, 350);

			Console.ReadKey();

		}
	}
}
