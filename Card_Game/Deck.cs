using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Card_Game
{
    public class Deck
    {
            public List<Card> Cards { get; private set; }

            public Deck()
            {
                Cards = GenerateDeck();
            }

            private List<Card> GenerateDeck()
            {
                List<Card> deck = new List<Card>();

                string[] suits = { "Hearts", "Diamonds", "Clubs", "Spades" };
                string[] ranks = { "6", "7", "8", "9", "10", "Jack", "Queen", "King", "Ace" };

                foreach (var suit in suits)
                {
                    foreach (var rank in ranks)
                    {
                        deck.Add(new Card(suit, rank));
                    }
                }

                return deck;
            }

            public void Shuffle()
            {
                Random random = new Random();
                Cards = Cards.OrderBy(card => random.Next()).ToList();
            }
    }
    
}
