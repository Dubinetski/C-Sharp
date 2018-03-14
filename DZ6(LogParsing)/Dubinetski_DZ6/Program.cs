using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace Dubinetski_DZ6 {
	class Program {
		static void Main(string[] args) {

			if (args.Length < 2) {
				Console.WriteLine("Please enter a IN and OUT files.");
				return;
			}
			string fileIn = args.Length == 2 ? args[0] : args[1];
			string fileOut = args.Length == 2 ? args[1] : args[2];
			int countOfTop;
			try {
				countOfTop = args.Length == 2 ? -1 : Int32.Parse(args[0]);
			} catch (Exception) {
				countOfTop = -1;
			}
			Dictionary<string, int> urls = new Dictionary<string, int>();
			Dictionary<string, int> domains = new Dictionary<string, int>();

			string inStr;
			try {
				inStr = File.ReadAllText(fileIn);
			} catch (Exception) {
				Console.WriteLine("Incorrect IN file path.");
				Console.ReadKey();
				return;
			}

			Regex regex = new Regex(@"https?://([A-z.]+)/?([A-z.,/+]*)");

			using (StreamWriter file2 = new StreamWriter(fileOut)) {
				MatchCollection col = regex.Matches(inStr);

				foreach (Match item in col) {
					if (domains.ContainsKey(item.Groups[1].Value)) {
						domains[item.Groups[1].Value] += 1;
					} else {
						domains.Add(item.Groups[1].Value, 1);
					}

					if (urls.ContainsKey(item.Value)) {
						urls[item.Value] += 1;
					} else {
						urls.Add(item.Value, 1);
					}
				}
				file2.WriteLine("Total urls {0}, domains {1}, paths {2}\n", col.Count, domains.Count, urls.Count);

				List<KeyValuePair<string, int>> domainsList = domains.ToList();
				List<KeyValuePair<string, int>> pathsList = new List<KeyValuePair<string, int>>();

				foreach (var url in urls) {
					pathsList.Add(new KeyValuePair<string, int>(regex.Match(url.Key).Groups[2].Value, url.Value));
				}

				domainsList.Sort(ComparePairValue);
				pathsList.Sort(ComparePairValue);

				file2.WriteLine("Top domains:");
				for (int i = 0; i < (countOfTop >= 0 && countOfTop < domainsList.Count ? countOfTop : domainsList.Count); i++) {
					file2.WriteLine("{0} {1}", domainsList[i].Value, domainsList[i].Key);
				}
				file2.WriteLine();

				file2.WriteLine("Top paths:");
				for (int i = 0; i < (countOfTop >= 0 && countOfTop < pathsList.Count ? countOfTop : pathsList.Count); i++) {
					file2.WriteLine("{0} /{1}", pathsList[i].Value, pathsList[i].Key);
				}
			}
		}
		static int ComparePairValue(KeyValuePair<string, int> pair1, KeyValuePair<string, int> pair2) {
			if (pair1.Value == pair2.Value) {
				return pair1.Key.CompareTo(pair2.Key);
			} else {
				return pair1.Value.CompareTo(pair2.Value) * -1;
			}
		}
	}
}
