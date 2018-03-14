using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseBuilder {
	class Worker : IWorker {
		private int salary;

		public int Salary {
			get { return salary; }
			set { salary = value; }
		}
		public void Work(IPart[] parts) {
			for (int i = 0; i < parts.Length; i++) {
				if (parts[i].LostBuildDuration >0) {
					parts[i].Build();
					return;
				}
			}			   
		}
	}
}
