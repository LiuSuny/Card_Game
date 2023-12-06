using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Card_Game
{
    
    class Program
    {
        
        static void Main()
        {
            //Create a new game with two players
             Game game = new Game(2);

            // Start the game
            game.Start();

            // Play the game until a player wins
            while (!game.HasWinner())
            {
                game.PlayRound();
            }

            // Display the winner
            Console.WriteLine($"Player {game.GetWinner()} wins!");
        }
    }
}

