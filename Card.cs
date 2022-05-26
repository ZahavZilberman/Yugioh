using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Media;

namespace yugioh
{
    public class Card
    {
        #region ctor

        public Card(XElement card)
        {
            Name = card.Element("Name").Value;
            star = int.Parse(card.Element("Star").Value);
            Owner = card.Element("Owner").Value;
            ATK = int.Parse(card.Element("ATK").Value);
            DEF = int.Parse(card.Element("DEF").Value);
            StartingDeckPosition = int.Parse(card.Element("DeckPosition").Value);
            CurrentDeckPosition = StartingDeckPosition;
            PossibleStates = new List<string>();
            PossibleStates.Add("Deck");
            PossibleStates.Add("Hand");
            PossibleStates.Add("Battlefield");
            PossibleStates.Add("Graveyard");
            State = PossibleStates.ElementAt(0);
        }

        #endregion

        #region Properties

        public int ATK { get; set; }
        public int DEF { get; set; }
        public int star { get; set; }
        public string Name { get; set; }
        public string Owner { get; set; }
        public int StartingDeckPosition { get; set; }
        public int CurrentDeckPosition { get; set; }
        public string State { get; set; }
        List<string> PossibleStates { get; set; }

        #endregion
    }
}
