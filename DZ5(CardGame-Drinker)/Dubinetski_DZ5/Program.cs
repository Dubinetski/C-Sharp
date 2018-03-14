/*
Карточная игра "Пьяница"

Игроки кладут по одной карте. У кого карта больше, то тот игрок забирает все карты и кладет их в конец своей колоды.
При одинаковых картах каждый игрок кладет еще по одной карте, шестерка забирает туза. 
Выигрывает игрок, который забрал все карты.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dubinetski_DZ5 {
	class Program {
		static void Main(string[] args) {
			Game newGame = new Game(6);

			newGame.Play();

			Console.ReadKey();
		}
	}
}
