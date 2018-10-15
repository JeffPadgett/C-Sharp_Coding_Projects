using System;
using System.Collections.Generic;


namespace TwentyOne
{
    class Program
    {
        static void Main(string[] args)
        {
            Deck blueDeck = new Deck();
            blueDeck.Shuffle();

            foreach (Card card in blueDeck.Cards)
            {
                Console.WriteLine(card.Face + " of " + card.Suit);
            }
            Console.WriteLine(blueDeck.Cards.Count);
            Console.ReadLine();
        }


        
    }
}

