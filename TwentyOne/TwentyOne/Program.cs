using System;
using System.Collections.Generic;


namespace TwentyOne
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to BestBet! Let's start by telling me your name. ");
            string playerName = Console.ReadLine();
            Console.WriteLine("How many chips do you want?");
            int chips = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Hello, {0}. Would you like to play Black Jack right now?", playerName);
            string answer = Console.ReadLine().ToLower();

            if (answer == "yes" || answer == "yeah" || answer == "y" || answer == "ya")
            {
                Player player = new Player(playerName, chips);
                Game game = new TwentyOneGame();
                game += player;

                player.isActivelyPlaying = true;
                while (player.isActivelyPlaying && player.Balance > 0)
                {
                    game.Play();
                }
                game -= player;
                Console.WriteLine("Thank you for playing!");
            }
            Console.WriteLine("Feel free to look around the casino. Buy for now.");
            Console.Read();
        }


        
    }
}

