using System;
using System.Collections.Generic;


namespace TwentyOne
{
    class Program
    {
        static void Main(string[] args)
        {
            Deck blueDeck = new Deck();
            int timesShuffled = 0;
            blueDeck = Shuffle(blueDeck, out timesShuffled, 3); 

            foreach (Card card in blueDeck.Cards)
            {
                Console.WriteLine(card.Face + " of " + card.Suit);
            }
            Console.WriteLine(blueDeck.Cards.Count);
            Console.WriteLine("Times Shuffled: {0}", timesShuffled);
            Console.ReadLine();
        }

        public static Deck Shuffle(Deck deck, out int timesShuffled,int times = 1) //Contains the out paramater that outputs the value to the var timesShuffled
        {
            timesShuffled = 0;
            for (int i = 0; i < times; i++)
            {
                timesShuffled++;
                List<Card> TempList = new List<Card>();
                Random random = new Random();

                while (deck.Cards.Count > 0)
                {
                    int randomIndex = random.Next(0, deck.Cards.Count);
                    TempList.Add(deck.Cards[randomIndex]);
                    deck.Cards.RemoveAt(randomIndex);
                }
                deck.Cards = TempList;

            }
            return deck;
        }

        //public static Deck Shuffle(Deck deck, int times)
        //{
        //    for (int i = 0; i < times; i++)
        //    {
        //        deck = Shuffle(deck);
        //    }
        //    return deck;
        //}
    }
}
