using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CardGame.Models
{
    public class DeckModel
    {
        public bool ShowFirstCard = false;
        CardModel[] cards = new CardModel[52];
        string[] numbers = new string[] { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };
        public DeckModel()
        {
            int i = 0;
            foreach (string s in numbers)
            {
                foreach (ValuesModel suit in Enum.GetValues(typeof(ValuesModel)))
                {
                    cards[i] = new CardModel(suit, s);
                    i++;
                }
            }
        }
        public void RemoveCard()
        {
            var firstCard = cards.First();
            cards = cards.Where(x => x != firstCard).ToArray();
        }
        public CardModel[] Cards
        {
            get
            {
                return cards;
            }
            set
            {
                cards = new CardModel[52];
                int i = 0;
                foreach (string s in numbers)
                {
                    foreach (ValuesModel suit in Enum.GetValues(typeof(ValuesModel)))
                    {
                        cards[i] = new CardModel(suit, s);
                        i++;
                    }
                }
            }
        }
        public CardModel card
        {
            get
            {
                return cards.First();
            }
        }
    }
}