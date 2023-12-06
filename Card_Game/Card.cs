using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Card_Game
{

    public class Card
    {
        public string Suit { get; }
        public string Rank { get; }

        public Card(string suit, string rank)
        {
            Suit = suit;
            Rank = rank;
        }

        public string GetCardDisplay()
        {
            string suitSymbol = GetSuitSymbol();
            return $"{Rank} {suitSymbol}";
        }
        public void DisplayCard()
        {
            Console.WriteLine($"┌───────┐");
            Console.WriteLine($"| {Rank,-2}    |");
            Console.WriteLine($"|       |");
            Console.WriteLine($"|   {GetSuitSymbol(),-1}   |");
            Console.WriteLine($"|       |");
            Console.WriteLine($"|    {Rank,2} |");
            Console.WriteLine($"└───────┘");
        }
        private string GetSuitSymbol()
        {
            switch (Suit)
            {
                case "Hearts": return "♥";
                case "Diamonds": return "♦";
                case "Clubs": return "♣";
                case "Spades": return "♠";
                default: return "";
            }
        }



    }
}
