using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Media;

namespace yugioh
{
    public class Player2
    {
        #region ctor

        public Player2()
        {
            LifePoints = 8000;
            KaibaOrYugi = "Yugi";
            DeckFile = XDocument.Load(@"C:\Users\USER\Documents\Visual Studio 2015\Projects\yugioh\yugioh\Deck1.xml");
            Graveyard = new List<Card>();
            Hand = new List<Card>();
            FieldATK = new List<Card>();
            FieldDEF = new List<Card>();
            DeckCardCount = int.Parse(DeckFile.Root.Element("CardCount").Value);
            Deck = new List<Card>();
            for (int DeckPosition = 0; DeckPosition < DeckCardCount; DeckPosition++)
            {
                Card card = new Card(DeckFile.Root.Elements("card").ElementAt(DeckCardCount));
                Deck.Add(card);
            }
            Deck = shuffling(Deck);
        }

        #endregion

        #region shuffling

        public List<Card> shuffling(List<Card> deck)
        {
            // the suffleing
            Random rnd = new Random(1);
            int newDeckPosition = 0;
            for (int deckPosition = 1; deckPosition <= DeckCardCount; deckPosition++)
            {
                int position = Deck.ElementAt(deckPosition).CurrentDeckPosition;
                newDeckPosition = rnd.Next(1, 30);
                int positionCount = 0;
                for (int deckCheck = 1; deckCheck <= DeckCardCount; deckCheck++)
                {
                    if (newDeckPosition == deckCheck)
                    {
                        positionCount = positionCount + 1;
                    }
                }
                while (positionCount > 1)
                {
                    DeckFile.Root.Elements("card").ElementAt(deckPosition);
                    newDeckPosition = rnd.Next(1, 30);
                    positionCount = 0;
                    for (int deckCheck = 1; deckCheck <= DeckCardCount; deckCheck++)
                    {
                        if (newDeckPosition == deckCheck)
                        {
                            positionCount = positionCount + 1;
                        }
                    }
                }
                Deck.ElementAt(deckPosition).CurrentDeckPosition = newDeckPosition;
            }
            return Deck;
        }

        #endregion

        #region properties

        public int LifePoints { get; set; }
        public string KaibaOrYugi { get; set; }
        XDocument DeckFile { get; set; }
        public List<Card> Deck { get; set; }
        public List<Card> Graveyard { get; set; }
        public List<Card> Hand { get; set; }
        public List<Card> FieldATK { get; set; }
        public List<Card> FieldDEF { get; set; }
        public int DeckCardCount { get; set; }

        #endregion
    }
}
