using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoFish

{
    public class Deck
    {

        //deck stores its cards in a list-but uses encapsulation
        private List<Card> cards;
        private Random random = new Random();

        //adding parameters to keep it from making a complete deck
        public Deck()
        {
            cards = new List<Card>();
            for (int suit = 0; suit <= 3; suit++)
            {
                for (int value = 1; value <= 13; value++)
                {
                    cards.Add(new Card((Suit)suit, (Value)value));
                }
            }
        }

        //overload constructor to make the inital deck
        public Deck(IEnumerable<Card> initialCards)
        {
            cards = new List<Card>(initialCards);
        }

        public int Count { get { return cards.Count; } }

        public void Add(Card cardToAdd)
        {
            cards.Add(cardToAdd);
        }

        //deal a card out of the deck, remove the card object and return a reference to it.
        public Card Deal(int index)
        {
            Card CardToDeal = cards[index];
            cards.RemoveAt(index);
            return CardToDeal;
        }

        //shuffle cards
        public void Shuffle()
        {
            List<Card> newCards = new List<Card>();
            while (cards.Count > 0)
            {
                int CardToMove = random.Next(cards.Count);
                newCards.Add(cards[CardToMove]);
                cards.RemoveAt(CardToMove);
            }
        }

        //return a string array that contains each card's name
        public IEnumerable<string> GetCardNames()
        {
            string[] CardNames = new string[cards.Count];
            for (int i = 0; i < cards.Count; i++)
            {
                CardNames[i] = cards[i].Name;
            }
            return CardNames;
        }

        public void Sort()
        {
            cards.Sort(new CardComparer_bySuit());
        }
    }
}
