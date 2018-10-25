using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace War
{
    class Deck
    {
        public Deck()
        {
            Cards = new List<Card>();

            for (int i = 0; i < 13; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Card card = new Card();
                    card.Face = (Face)i;
                    card.Suit = (Suit)j;
                    Cards.Add(card);
                }
            }
        }
        public List<Card> Cards { get; set; }


        public void Shuffle<T>() //Best shuffle, Other shuffle runs off the CPUs clock, This is an algrathom that is closest to true random that uses cryptography. 
        {
            IList<Card> list = this.Cards;
            RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider();
            int n = list.Count;
            while (n > 1)
            {
                byte[] box = new byte[1];
                do provider.GetBytes(box);
                while (!(box[0] < n * (Byte.MaxValue / n))); int k = (box[0] % n); n--;
                Card value = list[k];
                list[k] = list[n]; list[n] = value;
            }
        }

    }
}
