using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Spring2022SteelwoodProject
{
    class DiceBurst
    {
        //All Private Attributes
        private Random RNG = new Random();
        private int[] PlayerHand = new int[10];
        private int HandSize = 0, playerscore = 0, opponentscore = 0;
        private decimal funds = 1000, bet = 0;


        //Getters
        public int[] GetPlayerHand()
        {
            return PlayerHand;
        }

        public decimal GetFunds()
        {
            return funds;
        }

        public decimal GetBet()
        {
            return bet;
        }

        public int GetHandSize()
        {
            return HandSize;
        }

        public int GetPlayerScore()
        {
            return playerscore;
        }

        public int GetOpponentScore()
        {
            return opponentscore;
        }

        //Setters
        public void SetFunds(decimal SetFunds)
        {
            funds = SetFunds;
        }

        public void SetBet(decimal SetBet)
        {
            bet = SetBet;
        }

        public void SetHandSize(int SetHandSize)
        {
            HandSize = SetHandSize;
        }

        public void SetPlayerHand(int[] SetPlayerHand)
        {
            PlayerHand = SetPlayerHand;
        }

        public void SetPlayerScore(int SetPlayerScore)
        {
            playerscore = SetPlayerScore;
        }

        public void SetOpponentScore(int SetOppScore)
        {
            opponentscore = SetOppScore;
        }

       
        //Score Method
        public void Score(int playerscore)
        {
            for (int i = 0; i < GetPlayerHand().Length; i++)
            {
                playerscore = PlayerHand[i] + playerscore;
            }
        }
        //Roll Method
        public void Roll(int index)
        {
            PlayerHand[index] = RNG.Next(1, 7);
        }

        //Reset Method
        public void Reset(int[] HandArray)
        {
            for (int i = 0; i < HandArray.Length; i++)
            {
                HandArray[i] = 0;
            }
        }

        //Play Method
        public void Play(decimal bet, DiceBurst Opponent)
        {
            bool tie = false;

            {
                int count = 2;
                //Dice roll for Players
                Console.WriteLine("Rolling for you!");
                for (int i = 0; i < GetPlayerHand().Length; i++)
                {
                    if (i < count)
                        Roll(i);
                    playerscore += PlayerHand[i];
                    if (PlayerHand[i] != 0)
                    {
                        Console.WriteLine(PlayerHand[i]);
                    }
                    if (PlayerHand[i] == 6)
                    {
                        count++;
                    }
                }
                SetPlayerScore(playerscore);
                Console.WriteLine($"Your score is: {playerscore}");

                Console.WriteLine("Rolling for your opponent!");
                count = 2;
                for (int i = 0; i < Opponent.GetPlayerHand().Length; i++)
                {
                    if (i < count)
                        Opponent.Roll(i);
                    Opponent.opponentscore += Opponent.PlayerHand[i];
                    if (Opponent.PlayerHand[i] != 0)
                    {
                        Console.WriteLine(Opponent.PlayerHand[i]);
                    }
                    if (Opponent.PlayerHand[i] == 6)
                    {
                        count++;
                    }
                }
                Opponent.SetOpponentScore(Opponent.opponentscore);
                Console.WriteLine($"Your opponent's score is: {Opponent.opponentscore}");

                //Money disbursement
                if (GetPlayerScore() > Opponent.GetOpponentScore())
                {
                    SetFunds(GetFunds() + GetBet());
                    Opponent.SetFunds(Opponent.GetFunds() - GetBet());
                }

                else if (Opponent.GetOpponentScore() > GetPlayerScore())
                {
                    SetFunds(GetFunds() - GetBet());
                    Opponent.SetFunds(Opponent.GetFunds() + GetBet());
                }

            }
        }
    }
}

