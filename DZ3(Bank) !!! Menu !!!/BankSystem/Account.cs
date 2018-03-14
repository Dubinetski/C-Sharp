using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem {
	public enum Currency { BYN = 0, RUB, USD, EUR };
	public class Account {
		private int accountCurrency;
		public int Number { get; set; }
		public decimal Summ { get; private set; }
		public double WithdrawalPercent { get; set; }

		/// <summary>
		/// Аккаунт клиента
		/// </summary>
		/// <param name="currency">Валюта, в которой хранятся деньги на данном счете</param>
		public Account(Currency currency) {
			Number = Bank.GetNewAccauntNumber();
			Summ = 0;
			WithdrawalPercent = Bank.BaseWithdrawalPercent;
			accountCurrency = (int)currency;
		}
		/// <summary>
		/// Попытаться снять деньги со счета
		/// </summary>
		/// <param name="withdraw">Снимаемая сумма</param>
		/// <returns>Успешность выполнения операции</returns>
		public bool TryWithdrawal(decimal withdraw) {
			decimal withdrawSumm = withdraw * (decimal)(1 + WithdrawalPercent);
			if (withdrawSumm < Summ) {
				Summ -= withdrawSumm;
				return true;
			}
			return false;
		}
		/// <summary>
		/// Внесение денег на счет
		/// </summary>
		/// <param name="deposit">Сумма, вносимая на счет</param>
		public void Deposit(decimal deposit) {
			Summ += deposit;
		}
		/// <summary>
		/// Получить валюту счета
		/// </summary>
		/// <returns>Название валюты</returns>
		public string GetAccountCurrency() {
			return Enum.GetNames(typeof(Currency))[accountCurrency];
		}

		public override string ToString() {
			return String.Format("{0} ({1} {2})", Number, Summ, GetAccountCurrency());
		}
	}
}
