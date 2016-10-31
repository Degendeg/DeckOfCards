using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CardGame.Models
{
    public class CardModel
    {
        protected ValuesModel suit;
        protected string cardValue;
        public void Card()
        {
        }
        public CardModel(ValuesModel suit2, string cardValue2)
        {
            suit = suit2;
            cardValue = cardValue2;
        }
        public override string ToString()
        {
            return string.Format("{0} of {1}", cardValue, suit);
        }
    }
}