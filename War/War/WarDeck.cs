using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace War
{
    class WarDeck : Deck
    {
        List<Card> masterDeck;
        public WarDeck()
        {
            masterDeck = new List<Card>();
            Deck deck1 = new Deck();
            Deck deck2 = new Deck();
            Deck deck3 = new Deck();
            Deck deck4 = new Deck();
            Deck deck5 = new Deck();
            Deck deck6 = new Deck();
            List<Deck> blueWarDeck = new List<Deck>();
            blueWarDeck.Add(deck1);
            blueWarDeck.Add(deck2);
            blueWarDeck.Add(deck3);
            blueWarDeck.Add(deck4);
            blueWarDeck.Add(deck5);
            blueWarDeck.Add(deck6);


            foreach (Deck deck in blueWarDeck)
            {

                deck.Shuffle<Card>();
                foreach (Card c in deck.Cards)
                    masterDeck.Add(c);

            }


        }


        public bool CanDraw()
        {
            return masterDeck.Count > 25;
        }




        public Card DrawCard()
        {
            Card c = masterDeck[0];
            masterDeck.Remove(c);
            masterDeck.TrimExcess();
            return c;
        }
      
    }
}
