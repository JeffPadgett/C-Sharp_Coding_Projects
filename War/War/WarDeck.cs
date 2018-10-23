using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace War
{
    class WarDeck : Deck
    {
        public WarDeck()
        {
            Deck deck1 = new Deck();
            Deck deck2 = new Deck();
            Deck deck3 = new Deck();
            Deck deck4 = new Deck();
            Deck deck5 = new Deck();
            Deck deck6 = new Deck();
            List<Deck> blueWarDeck = new List<Deck>();
            blueWarDeck[0] = deck1;
            blueWarDeck[1] = deck2;
            blueWarDeck[2] = deck3;
            blueWarDeck[3] = deck4;
            blueWarDeck[4] = deck5;
            blueWarDeck[5] = deck6;
            List<Deck> tempWarDeck = new List<Deck>();

            foreach (Deck deck in blueWarDeck)
            {
                deck.Shuffle(2);
                tempWarDeck.Add(deck);
            }

            blueWarDeck = tempWarDeck;
        }
       
        

        private void shuffle(List<Deck> warDeck)
        {




        }
    }
}
