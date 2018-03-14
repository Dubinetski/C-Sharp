using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseBuilder {
	class Walls : IPart {
		private decimal cost;
		private int fullBuildDuration;
		private int lostBuildDuration;
		private int count;

		public Walls(int durationItemBuild, decimal costItem, int count) {
			Count = count;
			Cost = costItem * Count;
			FullBuildDuration = durationItemBuild * Count;
			LostBuildDuration = FullBuildDuration;
		}
		public Walls(int durationItemBuild, decimal costItem) : this(durationItemBuild, costItem, 1) { }

		public int Count {
			get { return count; }
			private set {
				if (value > 0)
					count = value;
			}
		}
		public double Completing {
			get { return Count * (1.0 - (double)LostBuildDuration / FullBuildDuration); }
		}

		public int LostBuildDuration {
			get { return lostBuildDuration; }
			private set {
				if (value >=0)
					lostBuildDuration = value;
			}
		}

		public int FullBuildDuration {
			get { return fullBuildDuration; }
			private set {
				if (value > 0)
					fullBuildDuration = value;
			}
		}

		public decimal Cost {
			get { return cost * Count; }
			set {
				if (value > 0)
					cost = value;
			}
		}

		public void Build() {
			if (LostBuildDuration > 0)
				LostBuildDuration--;
		}
		public override string ToString() {
			if (Completing == 0) {
				return String.Format("{0,-10} (not started)", "Walls");
			}
			return String.Format("{0,-10} (complit {1:N1} from {2})", "Walls", Completing, Count);
		}
	}
}
