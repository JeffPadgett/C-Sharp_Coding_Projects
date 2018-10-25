using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace War
{
    public class Player
    {
        public Game Game { get; set; }
        public Player(string name, int beginningBalance)
        {
            Hand = new List<Card>();
            Balance = beginningBalance;
            Name = name;
        }
        private List<Card> _hand = new List<Card>();
        public List<Card> Hand { get { return _hand; } set { _hand = value; } }
        public int Balance { get; set; }
        public string Name { get; set; }
        public bool isActivelyPlaying { get; set; }
        public int CurrentBet { get; set; }

        public bool Bet(int amount)
        {
            if (Balance - amount < 0)
            {
                Console.WriteLine("You do not have enough chips");
                return false;
            }
            else
            {
                Balance -= amount;
                CurrentBet = amount;
                return true;
            }
        }

        public void AddMoney()
        {
            Balance += CurrentBet * 2;
        }

        public void LostHand()
        {
            if (Balance == 0)
            {
                Game.RemovePlayer(this);
                Console.WriteLine(this.Name + " Lost all their money, tries to flip the table, and securty throws them out.");
            }
        }

        public static Game operator +(Game game, Player player)
        {
            game.Players.Add(player);
            return game;
        }

        public static Game operator -(Game game, Player player)
        {
            game.Players.Remove(player);
            return game;
        }
    }
}
