using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace War
{
   public class WarGame : Game
    {
        Dealer warDealer = new Dealer();
        public static List<Card> disCards;
        bool atWar { get; set; }
        
          
        public WarGame()
        {
            disCards = new List<Card>();
            warDealer.BurnCard(); //Evertime the game is started the dealer burns a card
        }

        public void WarBet(Player player)
        {
            if (!player.Bet(Int32.Parse(Console.ReadLine())))
                {
                Console.Write(player.Name + " Place your bet: $ ");
                WarBet(player);
                }

                
        }

        public void GoToWar(Player p)
        {
            warDealer.ClearHand(p);
            warDealer.ClearSelf();
            warDealer.BurnCard();
            warDealer.BurnCard();
            warDealer.BurnCard();
            warDealer.DealCard(p);
            warDealer.BurnCard();
            warDealer.BurnCard();
            warDealer.BurnCard();
            warDealer.DealSelf();
            warDealer.CompareHands(p, true);
        }


        public override void Play()
        {
         
            foreach (Player player in Players)
            {
                if (!player.isActivelyPlaying)
                    continue;
                Console.WriteLine(player.Name + " has $" + player.Balance);
                Console.Write(player.Name + " Place your bet: $ ");
                WarBet(player);

            }

            foreach (Player player in Players)
            {
                if (!player.isActivelyPlaying)
                    continue;
                warDealer.DealCard(player);

            }

            warDealer.DealSelf();
            
            
            foreach (Player player in Players)
            {
                if (!player.isActivelyPlaying)
                    continue;
                if (warDealer.CompareHands(player, false))
                {
                    if(atWar)
                    {
                        //atWar = true;
                        Console.WriteLine("{0} goes to war.", player.Name);
                        GoToWar(player);
                    }
                    string answer = Console.ReadLine();
                    if (answer.ToLower() == "y")
                    {
                        atWar = true;
                        Console.WriteLine("{0} goes to war.",player.Name);
                        player.Balance -= player.CurrentBet;
                        Console.WriteLine("Balance: " + player.Balance);
                        player.CurrentBet = player.CurrentBet * 2;
                        Console.WriteLine("Bet: " + player.CurrentBet);
                        GoToWar(player);
                    }
                    else
                    {
                        atWar = false;
                        Console.WriteLine("{0} chooses to chop",player.Name);
                        player.Balance += Convert.ToInt32(player.CurrentBet * 0.5);
                    }

                }

            }
            foreach (Player player in Players)
            {
                warDealer.ClearHand(player);
            }

            warDealer.ClearSelf();         
        }

    }
}
