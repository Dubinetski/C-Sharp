using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dubinetski_DZ5 {
	class Player {
		private string name;
		private Queue<Card> cards;
		public Player(string name) {
			Name = name;
			Cards = new Queue<Card>();
		}

		public string Name { get => name; private set => name = value; }
		internal Queue<Card> Cards { get => cards; private set => cards = value; }

		public void TakeCard(List<Card> cards) {
			for (int i = 0; i < cards.Count; i++) {
				Cards.Enqueue(cards[i]);
			}
		}
		public void TakeCard(Card card) {
			Cards.Enqueue(card);
		}

		public Card GetCard() {
			if (Cards.Count > 0) {
				return Cards.Dequeue();
			} else {
				return null;
			}
		}
		public override string ToString() {
			string str = String.Format("Player {0}: ", Name);
			foreach (var item in Cards) {
				str += item;
				str += " ";
			}
			return str;
		}
	}
}
