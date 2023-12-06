using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Card_Game
{
    public class Player
    {
        private List<Card> cards;
        public string Name { get; }

        public Player(string name)
        {
            Name = name;
            cards = new List<Card>();
        }

        public void AddCard(Card card)
        {
            cards.Add(card);
        }

        public void AddCardsToDeck(List<Card> cardsToAdd)
        {
            cards.AddRange(cardsToAdd);
        }

        public Card PlayCard()
        {
            Card card = cards.First();
            cards.RemoveAt(0);
            return card;
        }

        public Card GetTopCard()
        {
            if (cards.Any())
            {
                return cards.First();
            }
            else
            {
                // Return a special card or null when there are no cards left
                return null;
            }
        }

        public bool HasCards()
        {
            return cards.Any();
        }

        public bool HasAllCards()
        {
            return cards.Count == 36;
        }

        public int GetCardCount()
        {
            return cards.Count;
        }
    }

}
