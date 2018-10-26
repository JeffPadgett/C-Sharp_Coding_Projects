using System;
using System.Collections.Generic;
using Poker;
using Poker.TwentyOne;


namespace TwentyOne
{
    class Program
    {
        static void Main(string[] args)
        {
            const string pokerRoomName = "BestBet";
            Console.WriteLine("Welcome to {0}! Let's start by telling me your name. ", pokerRoomName);
            string playerName = Console.ReadLine();

            bool validAnswer = false;
            int chips = 0;
            while (!validAnswer)
            {
                Console.WriteLine("How much money did you bring today?");
                validAnswer = int.TryParse(Console.ReadLine(), out chips);
                if (!validAnswer) Console.WriteLine("Please enter digits only, and no decimals");
            }
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
                    try
                    {
                        game.Play();
                    }
                    catch (FraudExcepetion)
                    {
                        Console.WriteLine("You were thrown out by security");
                        Console.ReadLine();
                        return;
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("An error has occured. Please contact your System Administrator.");
                        Console.ReadLine();
                        return;
                    }
                }
                game -= player;
                Console.WriteLine("Thank you for playing!");
            }
            Console.WriteLine("Feel free to look around the casino. Bye for now.");
            Console.Read();
        }


        
    }
}

