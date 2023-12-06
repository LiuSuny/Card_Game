using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Card_Game
{

    public class Card
    {
        public readonly CardRank rank;
        public readonly CardSuit suit;

        public Card(CardRank rank, CardSuit suit)
        {
            this.rank = rank;
            this.suit = suit;
        }

        public override string ToString()
        {
            return $"{rank, 5} {suit, 5}";
        }
    }
}
