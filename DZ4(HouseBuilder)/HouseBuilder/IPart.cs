using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseBuilder {
	interface IPart {
		void Build();
		decimal Cost { get; }
		int FullBuildDuration { get; }
		int LostBuildDuration { get; }
		double Completing { get; }
		int Count { get; }
	}
}
