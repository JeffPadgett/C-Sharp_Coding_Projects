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

            StartGame();



        }

        public static void StartGame()
        {
            System.Console.Clear();
            Console.WriteLine("Welcome to War! \nHow many players are there? ");
            int numberOfPlayers = Convert.ToInt32(Console.ReadLine());
            if (numberOfPlayers > 6)
            {
                Console.WriteLine("There are too many players, The max amount of players allowed is 6");
                Console.WriteLine("Press any key to restart...");
                Console.ReadLine();
                StartGame();              
            }

            List<Player> tempPlayers = new List<Player>();
            for (int i = 0; i < numberOfPlayers; i++)
            {
                Console.WriteLine("What is the name of player {0}", i+1);
                string playerName = Console.ReadLine();
                Console.WriteLine("How many chips is this player buying in for?");
                int chipStack = Convert.ToInt32(Console.ReadLine());
                tempPlayers.Add(new Player(playerName, chipStack));
            }
            Console.WriteLine("Would you like to play War right now?");
            string answer = Console.ReadLine().ToLower();
            if (answer == "yes" || answer == "ya" || answer == "yes please" || answer == "y")
            {                
                Game game = new WarGame();
                foreach (Player player in tempPlayers)
                {
                    player.Game = game;
                game += player;
                player.isActivelyPlaying = true;
                }
                while (game.Players.Count() > 0)
                {
                    game.Play();
                }
            }
        }


    }
}
