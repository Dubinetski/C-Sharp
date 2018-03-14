using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dubinetski_DZ5 {
	class Game {
		private List<Player> players;
		private List<Card> cardsDeck;

		public Game(int playersCount) {
			players = new List<Player>(playersCount);
			for (int i = 1; i <= playersCount; i++) {
				players.Add(new Player(i.ToString()));
			}
			TakeCardDesk();
		}
		public Game(List<Player> players) {
			this.players = players;
		}
		/// <summary>
		/// Раздать карты игрокам
		/// </summary>
		private void GiveOut() {
			Random rnd = new Random();
			int cardIndex;

			while (true) {
				for (int i = 0; i < players.Count; i++) {
					cardIndex = rnd.Next(cardsDeck.Count);
					players[i].TakeCard(cardsDeck[cardIndex]);
					cardsDeck.RemoveAt(cardIndex);
					if (cardsDeck.Count == 0) {
						return;
					}
				}
			}
		}
		/// <summary>
		/// Формирует колоду карт
		/// </summary>
		private void TakeCardDesk() {
			Array types = Enum.GetValues(typeof(CardTypes));
			Array values = Enum.GetValues(typeof(CardValues));
			cardsDeck = new List<Card>();
			for (int i = 0; i < types.Length; i++) {
				for (int j = 0; j < values.Length; j++) {
					Card newCard = new Card((CardValues)values.GetValue(j), (CardTypes)types.GetValue(i));
					cardsDeck.Add(newCard);
				}
			}
		}

		public void Play() {
			GiveOut();

			Card maxCard = null;          // наибольшая карта на данном ходу
			List<Card> bank = new List<Card>();   // карты со всех этапов данного хода
			List<Card> cardOnTable = new List<Card>();  // карты на столе
			Dictionary<Player, int> playersLoos = new Dictionary<Player, int>();  // информаия о выбывших из игры игроках

			int bPlayersLoosGame = 0;       // для отметки статуса игроков в виде битов
			int bPlayersLoosTurn = 0;       // для отметки статуса игроков на данном ходу в виде битов

			int playersCountGame = players.Count;   // число оставшихся игроков в игре
			int playersCountTurn = playersCountGame; // число оставшихся игроков на данном ходу

			Card lastCard;    // последняя положенная на стол карта

			int playerWin = -1;  // индекс победителя на данном ходу
			int turn = 0;        // номер хода

			while (playersCountGame > 1) {
				for (int i = 0; i < players.Count; i++) {
					if (((bPlayersLoosGame & (1 << i)) == 0) && ((bPlayersLoosTurn & (1 << i)) == 0)) {
						if (players[i].Cards.Count == 0) {
							if (playersCountTurn == 1) {
								playerWin = i;
								break;
							}
							playersLoos.Add(players[i], turn);
							bPlayersLoosGame |= (1 << i);
							bPlayersLoosTurn |= (1 << i);
							playersCountGame--;
							playersCountTurn--;
							Console.WriteLine("Player {0} is loos on turn {1}.", players[i].Name, turn);
							if (playersCountGame == 1)
								break;
							continue;
						}
						lastCard = players[i].GetCard();
						cardOnTable.Add(lastCard);

						if ((cardOnTable.Count == 1) || (lastCard > maxCard)) {
							maxCard = lastCard;
							playerWin = i;
							for (int j = 0; j < i; j++) {
								if ((bPlayersLoosTurn & (1 << j)) == 0) {
									bPlayersLoosTurn |= (1 << j);
									playersCountTurn--;
								}
							}
						} else if (lastCard < maxCard) {
							bPlayersLoosTurn |= (1 << i);
							playersCountTurn--;
						} else {
							playerWin = i;
						}
					}
				}
				bank.AddRange(cardOnTable);
				cardOnTable.Clear();

				if (playersCountTurn == 1) {
					players[playerWin].TakeCard(bank);
					bank.Clear();
					bPlayersLoosTurn = bPlayersLoosGame;
					playersCountTurn = playersCountGame;
					turn++;

					Console.Write(System.DateTime.Now.ToLongTimeString());
					Console.SetCursorPosition(0, Console.CursorTop);

					//foreach (Player player in players) {
					//	Console.WriteLine(player);
					//}
					//Console.WriteLine();
				}
			}
			Console.WriteLine("Player {0} is won", players[playerWin].Name);
		}
	}
}
