using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dubinetski_DZ5 {
	enum CardTypes { Diamond, Club, Spade, Heart }
	enum CardValues : int { Six = 6, Seven, Eight, Nine, Ten, Jack, Queen, King, Ace }

	class Card {
		public CardTypes type;
		public CardValues value;

		public Card(CardValues value, CardTypes type) {
			this.value = value;
			this.type = type;
		}

		public static bool operator >(Card card1, Card card2) {
			if ((card1.value == CardValues.Six) && (card2.value == CardValues.Ace))
				return true;
			else if (card1.value > card2.value && !((card1.value == CardValues.Ace) && (card2.value == CardValues.Six))) {
				return true;
			}
			return false;
		}

		public static bool operator <(Card card1, Card card2) {
			if (card2 > card1)
				return true;
			return false;
		}

		public static bool operator ==(Card card1, Card card2) {
			if (card1.value == card2.value)
				return true;
			return false;
		}

		public static bool operator !=(Card card1, Card card2) {
			if (card2 == card1)
				return false;
			return true;
		}

		public override string ToString() {
			string str = "";
			switch (value) {
				case CardValues.Six:
					str = "6";
					break;
				case CardValues.Seven:
					str = "7";
					break;
				case CardValues.Eight:
					str = "8";
					break;
				case CardValues.Nine:
					str = "9";
					break;
				case CardValues.Ten:
					str = "10";
					break;
				case CardValues.Jack:
					str = "J";
					break;
				case CardValues.Queen:
					str = "Q";
					break;
				case CardValues.King:
					str = "K";
					break;
				case CardValues.Ace:
					str = "A";
					break;
				default:
					break;
			}

			switch (type) {
				case CardTypes.Diamond:
					str += "♦";
					break;
				case CardTypes.Club:
					str += "♣";
					break;
				case CardTypes.Spade:
					str += "♠";
					break;
				case CardTypes.Heart:
					str += "♥";
					break;
				default:
					break;
			}
			return str;
		}
	}
}
