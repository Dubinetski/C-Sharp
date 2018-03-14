using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseBuilder {
	class Team {
		private IWorker teamLeader;

		private IWorker worker;
		private int workersCount;

		public Team(IWorker teamLeader, IWorker worker, int workersCount) {
			this.teamLeader = teamLeader;
			this.worker = worker;
			this.workersCount = workersCount;
		}

		public void Work(IPart[] parts, int hours) {
			for (int i = 0; i < workersCount*hours; i++) {
				worker.Work(parts);
			}
			teamLeader.Work(parts);
		}										 
	}
}
