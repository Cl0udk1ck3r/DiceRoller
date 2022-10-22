using System;
using System.Threading;

namespace Spring2022SteelwoodProject
{
    class Program

    {


        static void Main(string[] args)

        { /*2022
		   *Steelwood, Mars
		   *Diceburst
		   */

            DiceBurst player = new DiceBurst();
            DiceBurst player2 = new DiceBurst();
            bool Continue = false;
            decimal betvar = 0;

            //Wincon Booleans
  
   


            do //Matches (while funds <= 0)
            {
                do //Games (while funds > 0)
                {
                    
                    bool flag2 = true;
                    Console.WriteLine("Welcome to DiceBurst!");
                    Thread.Sleep(1500);
                    Console.WriteLine($"Your current funds: {player.GetFunds():c}. " +
                        $"\nOpponent's current funds: {player2.GetFunds():c}");
                    Thread.Sleep(850);
                    Console.WriteLine("Get ready to play!");

                    //Bet assignment

                    Continue = false;
                    
                    
                    do
                    {
                        Console.WriteLine("Place your bet now! \nWager wisely, and don't bet more than you have!");
                        flag2 = decimal.TryParse(Console.ReadLine(), out betvar);
                    } while (betvar > player.GetFunds() || betvar <= 0 || !flag2);
                    player.SetBet(betvar);
                    Console.WriteLine($"You bet {player.GetBet():C}. Let's play!");


                    //Game Time
                    
                    player.Play(betvar, player2);
                    
                    bool playerwin = (player.GetPlayerScore() > player2.GetOpponentScore());
                    bool playerloss = (player.GetPlayerScore() < player2.GetOpponentScore());

                    //Game Wincons
                    if (playerwin)
                    {
                        Console.WriteLine($"Current funds: \n You: {player.GetFunds():c} \n Opponent: {player2.GetFunds():c}");
                        Console.WriteLine("You win! \n Press Y to play again, or anything else to quit.");
                        char playagain = char.ToUpper(Console.ReadKey().KeyChar);
                        if (playagain != 'Y')
                        {
                            Console.WriteLine("Thanks for playing!");
                            Continue = false;
                        }

                        else
                        {
                            Console.WriteLine("Get ready for a new game!");
                            Continue = true;
                            player.Reset(player.GetPlayerHand());
                            player2.Reset(player2.GetPlayerHand());
                            player.SetPlayerScore(0);
                            player2.SetOpponentScore(0);
                        }
                    }
                    else if (playerloss)
                    {
                        Console.WriteLine($"Current funds: \n You: {player.GetFunds():c} \n Opponent: {player2.GetFunds():c}");
                        Console.WriteLine("You lose. \n Press Y to play again, or anything else to quit.");
                        char playagain = char.ToUpper(Console.ReadKey().KeyChar);
                        if (playagain != 'Y')
                        {
                            Console.WriteLine("Thanks for playing!");
                            Continue = false;
                        }

                        else
                        {
                            Console.WriteLine("Get ready for a new game!");
                            Continue = true;
                            player.Reset(player.GetPlayerHand());
                            player2.Reset(player2.GetPlayerHand());
                            player.SetPlayerScore(0);
                            player2.SetOpponentScore(0);
                        }
                    }

                    else if (player.GetPlayerScore() == player2.GetOpponentScore()) //Tie
                    {
                        Console.WriteLine("Tie! It happens sometimes. \n Press Y for a tiebreaker, or anything else to quit");
                        char playagain = char.ToUpper(Console.ReadKey().KeyChar);
                        if (playagain != 'Y')
                        {
                            Console.WriteLine("Thanks for playing!");
                            Continue = false;
                        }

                        else
                        {
                            Console.WriteLine("Time for tiebreaker!"); //No reset
                            Continue = true;
                        }
                    }




                } while (Continue == true && (player.GetFunds() > 0 && player2.GetFunds()>0));

                //Match Wincons
                Console.WriteLine($"Your funds: {player.GetFunds():c} \nOpponent funds: {player2.GetFunds():c}");
                if (player.GetFunds() <=0)
                {
                    Console.WriteLine("Game over. You lose. \n If you'd like to play again press Y, or press anything else to quit");
                    char playagain = char.ToUpper(Console.ReadKey().KeyChar);
                    if (playagain != 'Y')
                    {
                        Console.WriteLine("Thanks for playing!");
                        Continue = false;
                    }
                    else
                    {
                        Console.WriteLine("Get ready for a new game!");
                        player.SetFunds(1000);
                        player2.SetFunds(1000);
                        Continue = true;
                        player.Reset(player.GetPlayerHand());
                        player2.Reset(player2.GetPlayerHand());
                        player.SetPlayerScore(0);
                        player2.SetOpponentScore(0);
                    }
                }
                else if (player2.GetFunds()<=0)
                {
                    Console.WriteLine("Game over. You win! \n If you'd like to play again press Y, or press anything else to quit.");
                    char playagain = char.ToUpper(Console.ReadKey().KeyChar);
                    if (playagain != 'Y')
                    {
                        Console.WriteLine("Thanks for playing!");
                        Continue = false;
                    }

                    else
                    {
                        Console.WriteLine("Get ready for a new game!");
                        player.SetFunds(1000);
                        player2.SetFunds(1000);
                        Continue = true;
                        player.Reset(player.GetPlayerHand());
                        player2.Reset(player2.GetPlayerHand());
                        player.SetPlayerScore(0);
                        player2.SetOpponentScore(0);
                    }
                }



            } while (Continue == true);


        }
    }
}


