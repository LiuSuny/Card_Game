using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Card_Game
{
    public class Game
    {
        public List<Card> cardDeck;
        public List<Player> players;


        private Random _random;
        private int _cardsAmount = 36;
        public Game(int playersCount = 2)
        {
            _random = new Random();

            players = new List<Player>();
            for (int i = 0; i < playersCount; i++)
            {
                players.Add(new Player());
            }

            cardDeck = createCardDeck();
            shuffleCards(cardDeck);

            dealCardsToPlayers(players, cardDeck);
        }

        public List<Card> createCardDeck()
        {
            cardDeck = new List<Card>();
            int suitCount = _cardsAmount / 4; //4

            for (int i = 0; i < suitCount; i++)
            {
                cardDeck.Add(new Card((CardRank)i, (CardSuit)0));
                cardDeck.Add(new Card((CardRank)i, (CardSuit)1));
                cardDeck.Add(new Card((CardRank)i, (CardSuit)2));
                cardDeck.Add(new Card((CardRank)i, (CardSuit)3));
            }

            return cardDeck;
        }

        public void shuffleCards(List<Card> cards)
        {
            cards.Sort((a, b) => _random.Next(-2, 2));

        }

        public void dealCardsToPlayers(List<Player> players, List<Card> cards)
        {
            int currentPlayer = 0;

            for (int i = 0; i < cards.Count; i++)
            {
                players[currentPlayer].cards.Add(cards[i]);

                currentPlayer++;
                currentPlayer %= players.Count;
            }
        }

        public bool playersTurn()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Players Move:");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Player:\t Number Of Cards: Card Move:");
            Console.ResetColor();
            int maxValue = -1;
            Player playerWithMaxValue = null;
            Stack<Card> cardStack = new Stack<Card>();

            for (int i = 0; i < players.Count; i++)
            {
                Player player = players[i];

                if (player.cards.Count > 0)
                {
                    Card card = player.cards[_random.Next(player.cards.Count)];

                    Console.WriteLine($"{i}\t{player.cards.Count}\t\t{card}"); //($"{i}\t{player.cards.Count}\t\t{card}")
                    player.cards.Remove(card);

                    if ((int)card.rank > maxValue)
                    {
                        maxValue = (int)card.rank;
                        playerWithMaxValue = player;
                 
                    }

                    cardStack.Push(card);

                }
            }
            
            playerWithMaxValue.cards.AddRange(cardStack);
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("*************************************************");
            Console.WriteLine($"Card Picked up by a player {players.IndexOf(playerWithMaxValue)}");
            Console.WriteLine("*************************************************");
            Console.WriteLine("*                                               *");
            Console.WriteLine("*                                               *");
            Console.WriteLine("*                                               *");
            Console.WriteLine("*                                               *");
            Console.ResetColor();
            if (playerWithMaxValue.cards.Count == _cardsAmount)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"Player number {players.IndexOf(playerWithMaxValue)} wins");
                Console.WriteLine("*                                               *");
                Console.WriteLine("*                                               *");
                Console.WriteLine("*************************************************");
                return false;
            }

            return true;
        }
    }
}
