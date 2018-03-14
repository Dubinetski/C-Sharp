using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseBuilder {
	interface IWorker {
		void Work(IPart[] parts);
		int Salary { get; set; }
	}
}
