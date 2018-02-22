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

        //look at a card in the deck without deleting it
        public Card Peek(int cardNumber)
        {
            return cards[cardNumber];
        }

        //if no parameters are pass, deal a card off the top of the deck
        public Card Deal()
        {
            return Deal(0);
        }

        //search through deck for card with certain value
        public bool ContainsValue(Values value)
        {
            foreach (Card card in cards)
            {
                if (card.Value == value)
                {
                    return true;
                }
                return false;
            }
        }

        //build the book of cards from deck
        public Deck PullOutValues(Values value)
        {
            Deck deckToReturn = new Deck(new Card[] { });
            for (int i = cards.Count - 1; i >= 0; i--)
            {
                if (cards[i].Value == value)
                {
                    deckToReturn.Add(Deal(i));
                }
            }
            return deckToReturn;
        }

        //check to see if a book contains 4 cards
        public bool HasBook(Values value)
        {
            int NumberOfCards = 0;
            foreach (Card card in cards)
            {
                if (card.Value == value)
                {
                    NumberOfCards++;
                }
            }
            if (NumberOfCards == 4)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    
        //sort deck
        public void SortByValue()
        {
            cards.Sort(new CardComparer_bySuit());
        }
    }
}
