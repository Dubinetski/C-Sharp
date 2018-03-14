/*
Ввести с клавиатуры номер трамвайного билета (6-значное число) и проверить является ли данный билет счастливым
Eсли на билете напечатано шестизначное число, и сумма первых трёх цифр равна сумме последних трёх, то этот билет считается счастливым).
*/


using System;

namespace DZ_1._2 {
	class Program {
		static void Main(string[] args) {
			const UInt32 max_number = 999999;	// максимальный номер билета

			uint number;

			while (true) {
				try {
					Console.Write("Enter the number of ticket (6 ciphers): ");
					number = Convert.ToUInt32(Console.ReadLine());
				} catch (Exception) {
					Console.WriteLine("Incorrect number. Please try again.");
					continue;
				}
				if (number / 100000 < 1 || number > max_number)
					continue;
				break;
			}

			byte first_three_summ = (byte)(number / 100000 + number / 10000 % 10 + number / 1000 % 10);	// сумма первых трех цифр
			byte second_three_summ = (byte)(number / 100 % 10 + number / 10 % 10 + number % 10);		// сумма последних трех цифр

			Console.Write("{0}{1}{2}", "The ticket #", number, first_three_summ == second_three_summ ? " is lucky" : " is not lucky");

			Console.ReadKey();
		}
	}
}
