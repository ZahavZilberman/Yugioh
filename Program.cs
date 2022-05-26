using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Media;

namespace yugioh
{
    class Program
    {
        public static void Main()
        {
            Console.Title = "Yugioh";
            Console.SetWindowSize(110, 58);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.BackgroundColor = ConsoleColor.Green;

            for (int repeat = 0; repeat < double.MaxValue; repeat++)
            {
                Console.WriteLine("Welcome to Yugioh.");
                Console.WriteLine("Do you want a duel or match? (duel = 1 game, match = best of 3)");
                Console.WriteLine("Click d for duel, m for match");
                ConsoleKeyInfo duelChoice = Console.ReadKey(true);
                while (duelChoice.Key.ToString().ToUpper() != "D" && duelChoice.Key.ToString().ToUpper() != "M")
                {
                    Console.WriteLine("Press only d or m");
                    duelChoice = Console.ReadKey(true);
                }
                bool IsDuel = true;
                string choice = duelChoice.ToString();
                if (choice.ToUpper() == "D")
                {
                    IsDuel = true;
                }
                else if (choice.ToUpper() == "M")
                {
                    IsDuel = false;
                }

                Console.Clear();
                List<string> PlayersWonDuels = new List<string>();
                if (IsDuel == true)
                {
                    Console.WriteLine("So then, that's a single duel. Let's begin.");
                }
                if (IsDuel == false)
                {
                    Console.WriteLine("So then, that's a the best of 3. Let's begin.");
                    for (int countAdd = 0; countAdd < 3; countAdd++)
                    {
                        PlayersWonDuels.Add("unknown");
                    }
                }
                Console.WriteLine("(press Enter to continue.)");
                Console.ReadLine();

                Console.Clear();
                Player kaiba = new Player();
                Player2 yugi = new Player2();
                Duel duel = new Duel(kaiba, yugi, IsDuel);
                DuelFunction(duel);
            }
        }

        public static void DuelFunction(Duel duel)
        {
            Console.WriteLine("Now player has draw 5 cards. Each turn you will draw 1 card from the deck.");
            Console.WriteLine("press Enter to continue");
            Console.ReadLine();
            Console.WriteLine("The duel is begining! it's kaiba's turn to start, but you can't attack at your first turn.");
            Console.WriteLine();

            while (duel.CurrentGameState != duel.GameStates.ElementAt(11))
            {
                Console.Clear();
                if (duel.CurrentTurn.ToUpper() == "KAIBA")
                {
                    duel.CurrentGameState = duel.GameStates.ElementAt(1);
                    duel.kaiba2.Hand.Add(duel.kaiba2.Deck.ElementAt(0));
                    duel.kaiba2.Deck.Remove(duel.kaiba2.Deck.ElementAt(0));
                    Console.Clear();
                    Console.WriteLine("It's kaiba's turn!");
                    Console.WriteLine();
                    Console.WriteLine("You've already drawed a card from your deck.");
                    Console.WriteLine();
                    Console.WriteLine("Press enter to continue.");
                    Console.ReadLine();
                    while (duel.CurrentGameState != duel.GameStates.ElementAt(5))
                    {
                        Console.Clear();
                        Console.WriteLine();
                        Console.WriteLine("Press s to summon a monster, a to attack, v to view all your cards and game information, e to end your turn");
                        Console.WriteLine();
                        ConsoleKeyInfo TurnChoice = Console.ReadKey(true);
                        while (TurnChoice.Key.ToString().ToUpper() != "D" && TurnChoice.Key.ToString().ToUpper() != "M")
                        {
                            Console.WriteLine("Press only d or m");
                            TurnChoice = Console.ReadKey(true);
                        }
                    }

                }
                else if (duel.CurrentTurn.ToUpper() == "YUGI")
                {
                    duel.CurrentGameState = duel.GameStates.ElementAt(6);
                    duel.yugi2.Hand.Add(duel.yugi2.Deck.ElementAt(0));
                    duel.yugi2.Deck.Remove(duel.yugi2.Deck.ElementAt(0));
                    Console.Clear();
                    Console.WriteLine("It's yugi's turn!");
                    Console.WriteLine();
                    Console.WriteLine("You've already drawed a card from your deck.");
                    Console.WriteLine();
                    Console.WriteLine("Press enter to continue.");
                    Console.ReadLine();
                    while (duel.CurrentGameState != duel.GameStates.ElementAt(10))
                    {
                        Console.Clear();
                        Console.WriteLine();
                        Console.WriteLine("Press s to summon a monster, a to attack, v to view all your cards and game information, e to end your turn");
                        Console.WriteLine();
                    }
                }
            }
            #region Rock paper scicors
            // wrote here an epic function for rock paper scicors, but then realized its useless in this case, here it is
            /*
            public static bool DidKaibaWinAtRockPaperScicors()
            {
                Console.Clear();
                Console.WriteLine("To decide who starts, we'll play Rock Paper Scicors.");
                Console.WriteLine("Each player will chose one of those 3 options each round. Rock beats scicors, Scicors beat paper and paper beats rock");
                Console.WriteLine("If you choose the same option, it's a draw and the game continues until someone wins.");
                Console.WriteLine("The winner gets to be the first to start the duel.");
                Console.WriteLine("press Enter to continue. to start this little game..");
                Console.ReadLine();
                List<string> choices = new List<string>();
                choices.Add("rock");
                choices.Add("paper");
                choices.Add("scicors");
                string KaibaChoice = null;
                string YugiChoice = null;
                bool IsKaibaTurn = true;
                bool DidSomeoneWin = false;
                bool whoWon = true;

                while (!DidSomeoneWin)
                {
                    Console.Clear();
                    if(IsKaibaTurn)
                    {
                        Console.WriteLine("It's kaiba's turn");
                        Console.WriteLine("Click p for paper, r for rock, s for scicors.");
                        Console.WriteLine();
                        ConsoleKeyInfo kaibaChoice = Console.ReadKey(true);
                        while (kaibaChoice.Key.ToString().ToUpper() != "p" && kaibaChoice.Key.ToString().ToUpper() != "r" && kaibaChoice.Key.ToString().ToUpper() != "s")
                        {
                            Console.WriteLine("Press only r or p or s");
                            kaibaChoice = Console.ReadKey(true);
                        }
                        KaibaChoice = kaibaChoice.ToString();
                        if(KaibaChoice == "s")
                        {
                            Console.WriteLine("Kaiba chooses scicors.");
                            Console.WriteLine("Now wait for end of yugi's turn.");
                        }
                        else if(KaibaChoice == "p")
                        {
                            Console.WriteLine("Kaiba chooses paper.");
                            Console.WriteLine("Now wait for end of yugi's turn.");
                        }
                        else if (KaibaChoice == "r")
                        {
                            Console.WriteLine("Kaiba chooses rock.");
                            Console.WriteLine("Now wait for end of yugi's turn.");
                        }

                        Console.WriteLine("press Enter to continue.");
                        Console.ReadLine();
                        IsKaibaTurn = false;
                    }
                    if (!IsKaibaTurn)
                    {
                        Console.WriteLine();
                        Console.WriteLine("It's yugi's turn");
                        Console.WriteLine("Click p for paper, r for rock, s for scicors.");
                        Console.WriteLine();
                        ConsoleKeyInfo yugiChoice = Console.ReadKey(true);
                        while (yugiChoice.Key.ToString().ToUpper() != "p" && yugiChoice.Key.ToString().ToUpper() != "r" && yugiChoice.Key.ToString().ToUpper() != "s")
                        {
                            Console.WriteLine("Press only r or p or s");
                            yugiChoice = Console.ReadKey(true);
                        }
                        YugiChoice = KaibaChoice.ToString();
                        Console.WriteLine();

                        if (YugiChoice == "s")
                        {
                            Console.WriteLine("yugi chooses scicors.");
                        }
                        else if (YugiChoice == "p")
                        {
                            Console.WriteLine("yugi chooses paper.");
                        }
                        else if (YugiChoice == "r")
                        {
                            Console.WriteLine("yugi chooses rock.");
                        }

                        Console.WriteLine();
                        Console("Press enter to continue.");
                        Console.ReadLine();
                        Console.WriteLine();

                        if (YugiChoice.ToUpper() == KaibaChoice.ToUpper())
                        {
                            Console.WriteLine("Looks like it's a draw. So let's continue this until someone wins");
                            Console.WriteLine("Press enter to continue.");
                            Console.ReadLine();
                            DidSomeoneWin = false;
                        }
                        else
                        {
                            DidSomeoneWin = true;
                            if (YugiChoice.ToUpper() == "s" && KaibaChoice.ToUpper() == "p")
                            {
                            Console.WriteLine("Yugi wins. ")
                            }
                        } 
                    }
                }
                return whoWon;
                */
            #endregion
        }
    }
}
