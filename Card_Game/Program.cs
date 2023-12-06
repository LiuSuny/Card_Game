using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Card_Game
{
    public enum CardRank
    {

        SIX = 0, SEVEN, EIGHT, NINE, TEN, JACK, QUEEN, KING, ACE
    }

    public enum CardSuit
    {
        HEARTS = 0, DIAMONDS, CLUBS, SPADES
    }

    class Program
    {
        
        static void Main()
        {
            Game game = new Game(6);
            while (game.playersTurn()) { }
            
        }
    }
}

