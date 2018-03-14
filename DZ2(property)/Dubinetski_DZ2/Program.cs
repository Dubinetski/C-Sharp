using System;

namespace Dubinetski {
	class Program {
		static void Main(string[] args) {
			Console.WriteLine("            SmartAray           ");
			Console.WriteLine();
			Console.WriteLine();

			Console.WriteLine("Create the new SmartAray with indexes from 5 to 10 and fill them some items.");
			SmartArray newArray = new SmartArray(5, 10);
			newArray.Values = new int[] { 5, 6, 7, 8, 9, 10 };

			Console.Write("Items in SmartAray: ");
			Console.WriteLine(newArray.ToStr());

			Console.WriteLine("{0}{1}", "Length SmartArray: ", newArray.Length);
			Console.WriteLine();

			Console.Write("Change the length SmartAray to 10: ");
			newArray.Length = 10;
			Console.WriteLine("{0}{1}", "New length SmartArray: ", newArray.Length);

			Console.Write("Items in SmartAray: ");
			Console.WriteLine(newArray.ToStr());
			Console.WriteLine();

			Console.Write("Set the item with index 7 on number 99: ");
			newArray[7] = 99;
			Console.WriteLine(newArray.ToStr());
			Console.WriteLine();

			Console.WriteLine("Try set the item with index 50 on number 15: ");
			newArray[50] = 15;
			Console.WriteLine(newArray.ToStr());
			Console.WriteLine();

			Console.WriteLine("Create the second SmartAray with another designer (first_index, array)");
			SmartArray newArray2 = new SmartArray(5, new int[] { 1, 2, 3, 4, 5 });
			Console.WriteLine(newArray2.ToStr());
			Console.WriteLine();


			Console.WriteLine("=================================");
			Console.WriteLine("               MAP               ");
			Console.WriteLine();

			Map myShop = new Map();
			myShop.Add("Xiaomi Mi5", 530);
			myShop.Add("Samsung Galaxy S8", 1450);
			Console.WriteLine("Try the add the item already exist in the shop.");
			try {
				myShop.Add("Samsung Galaxy S8", 1450);
			} catch (System.ArgumentException ex) {
				Console.WriteLine(ex.Message);
			}
			Console.WriteLine();

			Console.WriteLine("{0}{1}{2}", "In the shop is ", myShop.Count, " phones.");
			Console.WriteLine();

			string[] models = myShop.Keys;
			double[] prices = myShop.Values;

			Console.WriteLine("Phone models in the shop:");
			foreach (var item in models) {
				Console.WriteLine(item);
			}
			Console.WriteLine();

			Console.WriteLine("Phone price in the shop:");
			foreach (var item in prices) {
				Console.WriteLine(item);
			}
			Console.WriteLine();

			if (myShop.ContainsKey("Samsung Galaxy S8")) {
				Console.WriteLine("{0}{1}", "Cost Samsung Galaxy S8: ", myShop["Samsung Galaxy S8"]);
				myShop["Samsung Galaxy S8"] = 1300;
				Console.WriteLine("{0}{1}", "New cost Samsung Galaxy S8: ", myShop["Samsung Galaxy S8"]);
			}

			try {
				myShop["Samsung"] = 1300;
			} catch (KeyNotExistException ex) {
				Console.WriteLine(ex.Message);
			}

			Console.WriteLine("Delete Samsung Galaxy S8 from shop.");
			myShop.Remove("Samsung Galaxy S8");
			Console.WriteLine("{0}{1}{2}", "In shop is ", myShop.Count, " phones.");
			Console.WriteLine();

			double cost;
			if (myShop.TryGetValue("Xiaomi Mi5", out cost)) {
				Console.WriteLine("{0}{1}", "The price Xiaomi Mi5: ", cost);
			}
			Console.WriteLine();

			if (!myShop.TryGetValue("iPhone", out cost)) {
				Console.WriteLine("iPhone is'n in shop.");
			}

			Console.WriteLine("Clear the shop.");
			Console.WriteLine();

			myShop.Clear();
			Console.WriteLine("{0}{1}{2}", "In shop is ", myShop.Count, " phones.");

			Console.ReadKey();
		}
	}
}
