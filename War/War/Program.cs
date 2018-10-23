using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace War
{
    class Program
    {
        static void Main(string[] args)
        {
            WarDeck blueWarDeck = new WarDeck();
            Console.WriteLine(blueWarDeck);
            Console.ReadLine();
            Console.WriteLine("Welcome to War! \nHow many players are there? ");
            int numberOfPlayers = Convert.ToInt32(Console.ReadLine());
            if (numberOfPlayers > 1)
            {
                Console.WriteLine("I am sorry, we can only have one player at this time"); //Just to make it playable for now until I add additonal player functionality.
            }
            Console.WriteLine("What is your name?");
            string playerName = Console.ReadLine();
            Console.WriteLine("How many chips are you buying in for?");
            int chipStack = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Would you like to play War right now {0}?", playerName);
            string answer = Console.ReadLine().ToLower();
            if (answer == "yes" || answer == "ya" || answer == "yes please" || answer =="y")
            {
                Player player = new Player(playerName, chipStack);
                Game game = new WarGame();
                game += player;
                player.isActivelyPlaying = true;
                while (player.isActivelyPlaying && player.Balance > 0)
                {
                    game.Play();
                }
            }
            


            
        }
    }
}
