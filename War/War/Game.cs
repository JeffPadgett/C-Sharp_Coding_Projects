using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace War
{
    public abstract class Game
    {
        private List<Player> _players = new List<Player>();
        private Dictionary<Player, int> _bets = new Dictionary<Player, int>();
        

        public List<Player> Players { get { return _players; } set { _players = value; } }
        public string Name { get; set; }
        public Dictionary<Player,int> Bets { get { return _bets; } set { _bets = value; } }

        public abstract void Play();

        public virtual void ListPlayers()
        {
            foreach (Player player in Players)
            {
                
                Console.WriteLine(player.Name);

            }
        }

        public void RemovePlayer(Player p)
        {
            p.isActivelyPlaying = false;
            if (AllPlayersLost())
            {
                Console.WriteLine("All players were thrown out by security. Would you like to play again? \n Y or N?");
                string answer = Console.ReadLine();
                if (answer.ToLower() == "y")
                {
                    Program.StartGame();
                }
                else if (answer.ToLower() == "n")
                {
                    System.Environment.Exit(0);
                }
            }
        }

        public bool AllPlayersLost()
        {
            bool allLost = true;
            foreach (Player p in Players)
            {
                if (p.isActivelyPlaying)
                {
                    allLost = false;
                }
            }
            return allLost;
        }
    


    }
}
