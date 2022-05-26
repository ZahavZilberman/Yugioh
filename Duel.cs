using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Media;

namespace yugioh
{
    public class Duel
    {
        #region ctor

        public Duel(Player kaiba, Player2 yugi, bool IsDuelOrMatch)
        {
            GameStates = new List<string>();
            GameStates.Add("Start");
            GameStates.Add("DrawPlayer1");
            GameStates.Add("SummonPlayer1");
            GameStates.Add("AttackCardPlayer1");
            GameStates.Add("AttackPlayer2");
            GameStates.Add("EndTurnPlayer1");
            GameStates.Add("DrawPlayer2");
            GameStates.Add("SummonPlayer2");
            GameStates.Add("AttackCardPlayer2");
            GameStates.Add("AttackPlayer1");
            GameStates.Add("EndTurnPlayer2");
            GameStates.Add("EndGame");
            CurrentGameState = GameStates.ElementAt(0);
            IsDuel = IsDuelOrMatch;
            WhoWonAtDuels = new List<string>();
            kaiba2 = kaiba;
            yugi2 = yugi;
            for (int CardIndex = 0; CardIndex < 5; CardIndex++)
            {

                kaiba2.Hand.Add(kaiba2.Deck.ElementAt(CardIndex));
                yugi2.Hand.Add(yugi2.Deck.ElementAt(CardIndex));
            }
            for (int CardIndex = 0; CardIndex < 5; CardIndex++)
            {

                kaiba2.Deck.Remove(kaiba2.Hand.ElementAt(CardIndex));
                yugi2.Deck.Remove(yugi2.Hand.ElementAt(CardIndex));
            }
            CurrentTurn = "kaiba";
            CanPlayerAttack = false;
        }

        #endregion

        #region properties

        public List<string> GameStates { get; set; }
        public string CurrentGameState { get; set; }
        public bool IsDuel { get; set; }
        public Player kaiba2 { get; set; }
        public Player2 yugi2 { get; set; }
        public string CurrentTurn { get; set; }
        bool CanPlayerAttack { get; set; }
        List<string> WhoWonAtDuels { get; set; }

        #endregion
    }
}
