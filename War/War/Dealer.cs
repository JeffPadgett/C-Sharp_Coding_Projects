using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace War
{
    class Dealer
    {
        public string Name { get; set; }
        public WarDeck Deck { get; set; }
        public int Balance { get; set; }
        public List<Card> Hand { get; set; }

        
        public Dealer()
        {
            Deck = new WarDeck();
            Hand = new List<Card>();
        }
        public void DealCard(Player p)
        {
            Card c = Deck.DrawCard();
            p.Hand.Add(c);
            Console.WriteLine(p.Name + " gets " + c.ToString());

        }

        public void DealSelf()
        {
            Card c = Deck.DrawCard();
            this.Hand.Add(c);
            Console.WriteLine("Dealer gets a " + c.ToString());
        }


        public bool CompareHands(Player p)
        {
            if (p.Hand[0].Face > Hand[0].Face)
            {
                p.AddMoney();
                Console.WriteLine(p.Name + " wins!");
                
            }

            else if (p.Hand[0].Face < Hand[0].Face)
            {
                Console.WriteLine("Dealer wins against {0}.",p.Name);
                p.LostHand();
            }
            else
            {
                Console.WriteLine("Do you want to go to war? Y or N \n If you choose no it will cut half your bet. \n If you choose yes you will need to match your bet and we will draw for a new card to see who wins." );
                return true;

            }
            return false;
        }

        public void ClearHand(Player p)
        {
            foreach (Card c in p.Hand)
            {               
                WarGame.disCards.Add(c);
            }
            p.Hand.Clear();
            p.Hand.TrimExcess();
        }

        public void ClearSelf()
        {
            foreach (Card c in Hand)
            {
                WarGame.disCards.Add(c);
            }
            Hand.Clear();
            Hand.TrimExcess();
        }






        public void BurnCard()
        {
            WarGame.disCards.Add(Deck.DrawCard());
        }
    }
}
