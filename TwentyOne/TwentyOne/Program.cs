using System;
using System.Collections.Generic;


namespace TwentyOne
{
    class Program
    {
        static void Main(string[] args)
        {

            Game game = new TwentyOneGame();
            game.Players = new List<Player>();
            Player player = new Player();
            player.Name = "Jesse";
            game = game + player;
            game = game - player;

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

