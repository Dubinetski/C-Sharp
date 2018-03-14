using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseBuilder {
	class TeamLeader : IWorker {
		private int salary;

		public int Salary {
			get { return salary; }
			set { salary = value; }
		}


		public void Work(IPart[] parts) {
			int totalWork = 0;
			int leftWork = 0;
			decimal cost = 0;

			string str = "Build: ";
			for (int i = 0; i < parts.Length; i++) {
				totalWork += parts[i].FullBuildDuration;
				leftWork += parts[i].LostBuildDuration;
				cost += (parts[i].Cost * (decimal)parts[i].Completing);
				str += "\n";
				str += parts[i].ToString();
			}
			str += String.Format("\n\nFinished by {0:P2}", 1.0 - (double)leftWork / totalWork);
			str += String.Format("\nSpend: {0:0}$", cost);

			if (leftWork==0) {
			   			str += String.Format("\nWork complit on {0:0} piple*hours\n", totalWork);
			}

			Console.WriteLine(str);

			int curs_y = Console.CursorTop;

			if (parts[1].Completing >= 1) {
				Console.SetCursorPosition(0, curs_y + 8);
				Console.WriteLine(@"
    _______________
  /               /|
 /               //
/_______________//
||||||||||||||||/");
			}
			if (parts[1].Completing >= 1) {
				Console.SetCursorPosition(0, curs_y + 1);
				Console.WriteLine(@"
   /|
  / |
 /  |
|   |
|   |
|   |
|   |
|   |
|  /
| /
|/");
			}
			if (parts[1].Completing >= 2) {
				Console.SetCursorPosition(0, curs_y );
				Console.WriteLine(@"
    ________________
   /|              |
  / |              |
 /  |              |
|   |              |
|   |              |
|   |              |
|   |              |
|   |______________|");
			}
			if (parts[1].Completing >= 3) {
				Console.SetCursorPosition(0, curs_y );
				Console.WriteLine(@"
    
   /|             /
  / |            / 
 /  |           /  
|   |          |   
|   |          |   
|   |          |   
|   |          |   
|   |__________|   
|  /           |  /
| /            | /
|/_____________|/");
			}
			if (parts[1].Completing >= 4) {
				Console.SetCursorPosition(0, curs_y );
				Console.WriteLine(@"
    
  /| 
 / |  
/__|____________
|     
|    
|    
|    
|              
|    
|   
|____");
			}
			if (parts[2].Completing >= 1) {
				Console.SetCursorPosition(0, curs_y + 8);
				Console.WriteLine(@"
|           __
|          |  |
|          |  |
|__________|__|");
			}
			if (parts[3].Completing >= 1) {
				Console.SetCursorPosition(0, curs_y + 8);
				Console.WriteLine(@"
|  _ 
| |_|");
			}
			if (parts[3].Completing >= 2) {
				Console.SetCursorPosition(0, curs_y + 8);
				Console.WriteLine(@"
|  _    _ 
| |_|  |_|");
			}
			if (parts[3].Completing >= 3) {
				Console.SetCursorPosition(0, curs_y + 5);
				Console.WriteLine(@"
|  _  
| |_|");
			}
			if (parts[3].Completing >= 4) {
				Console.SetCursorPosition(0, curs_y + 5);
				Console.WriteLine(@"
|  _    _   
| |_|  |_|");
			}
			if (parts[4].Completing >= 1) {
				Console.SetCursorPosition(0, curs_y );
				Console.WriteLine(@"
   _________________
  / / / / / / / / /
 / / / / / / / / / 
/_/_/_/_/_/_/_/_/");
			}
		}
	}
}
