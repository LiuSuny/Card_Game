using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Card_Game
{
    public class Game
    {
        private List<Player> players;
        private Deck deck;

        public Game(int numPlayers)
        {
            if (numPlayers < 2)
            {
                throw new ArgumentException("At least two players are required.");
            }

            players = new List<Player>();
            for (int i = 0; i < numPlayers; i++)
            {
                players.Add(new Player($"Player {i + 1}"));
            }

            deck = new Deck();
        }

        public void Start()
        {
            // Shuffle the deck
            deck.Shuffle();

            // Distribute cards to players
            int playerIndex = 0;
            foreach (var card in deck.Cards)
            {
                players[playerIndex].AddCard(card);
                playerIndex = (playerIndex + 1) % players.Count;
            }
        }

        public void PlayRound()
        {

            List<Card> cardsInPlay = new List<Card>();
            foreach (var player in players)
            {
                if (player.HasCards())
                {
                    Card card = player.PlayCard();
                    Console.WriteLine($"{player.Name} plays {card.GetCardDisplay()}");
                    cardsInPlay.Add(card);
                }
            }

            // Check if any player played a card
            if (cardsInPlay.Any())
            {
                // Find the player with the highest card
                Player winner = players
                    .Where(p => p.GetTopCard() != null)
                    .OrderByDescending(p => cardsInPlay.Contains(p.GetTopCard()))
                    .First();

                // The winner takes all the cards
                winner.AddCardsToDeck(cardsInPlay);

                // Display the result
                Console.WriteLine($"{winner.Name} wins the round!");
                Console.WriteLine($"Player 1 has {players[0].GetCardCount()} cards, Player 2 has {players[1].GetCardCount()} cards");
                Console.WriteLine();
            }
            else
            {
                // No cards were played, the game might be over
                Console.WriteLine("No cards were played. The game might be over.");
            }
        }

        public bool HasWinner()
        {
            return players.Any(p => p.HasAllCards());
        }

        public int GetWinner()
        {
            for (int i = 0; i < players.Count; i++)
            {
                if (players[i].HasAllCards())
                {
                    return i + 1;
                }
            }
            return -1; // No winner yet
        }
    }
}
