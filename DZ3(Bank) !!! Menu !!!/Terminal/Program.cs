/*
 Написать приложение, имитирующее работу банковской системы.
 Реализовать регистрацию, вход в систему и работу с расчетным счетом.
 Отделить логику работы приложения от визуальной составляющей. 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BankSystem {
	class Program {
		static void Main(string[] args) {
			Terminal.BankMenu();
		}
	}
}