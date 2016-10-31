using CardGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace CardGame.Controllers
{
    public class HomeController : Controller
    {
        public static List<DeckModel> _decks = new List<DeckModel>();
        public ActionResult Index(List<DeckModel> deck)
        {
            deck = _decks;
            return View(deck);
        }

        [HttpPost]
        public ActionResult ConfirmChoice()
        {
            var val = Request.Form["Choices"].ToString();
            if (val == "1")
            {
                foreach (DeckModel deck in _decks)
                {
                    HidePulledCard();
                    FisherYates.Shuffle(deck.Cards);
                }
            }
            if (val == "2")
            {
                var dm = new DeckModel();
                foreach (DeckModel deck in _decks)
                {
                    HidePulledCard();
                    deck.Cards = dm.Cards;
                }
            }
            if (val == "3")
            {
                foreach (DeckModel deck in _decks)
                {
                    TempData["Card"] = deck.card;
                    deck.ShowFirstCard = true;
                    deck.RemoveCard();
                }
            }
            if (val == "4")
            {
                HidePulledCard();
                var newDeck = new DeckModel();
                _decks.Add(newDeck);
            }
            return RedirectToAction("Index", "Home");
        }

        static public class FisherYates
        {
            static Random r = new Random();
            // Baserat på Fisher-Yates shuffle algoritmen
            // http://en.wikipedia.org/wiki/Fisher-Yates_shuffle
            static public void Shuffle(CardModel[] deck)
            {
                for (int n = deck.Length - 1; n > 0; --n)
                {
                    int k = r.Next(n + 1);
                    CardModel temp = deck[n];
                    deck[n] = deck[k];
                    deck[k] = temp;
                }
            }
        }
        public void HidePulledCard()
        {
            foreach (DeckModel deck in _decks)
            {
                deck.ShowFirstCard = false;
            }
        }
    }
}