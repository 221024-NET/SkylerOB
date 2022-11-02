using System;

namespace RPS
{
    class Program
    {
        // fields
        enum Hands { Rock=1, Paper, Scissors };
        private static int matchCount, winCount, loseCount;

        // constructor

        // methods
        void playerWin()
        {
            matchCount++;
            winCount++;
            Console.WriteLine($"You lost. Player {winCount} :: Robot {loseCount}");
        }

        void robotWin()
        {
            matchCount++;
            loseCount++;
            Console.WriteLine($"You lost. Player {winCount} :: Robot {loseCount}");
        }

        void matchTie()
        {
            Console.WriteLine($"Again!");
        }

        static void Main(string[] args)
        {
            Program result = new Program();
            Random robotBrain = new Random();
            matchCount = 0;
            winCount = 0;
            loseCount = 0;
            Hands playerHand, robotHand;
            string playerInput;

            while (1==1)
            {
                Console.WriteLine("Rock! Paper! Scissors! (Type your choice) ");

                // player choice
                playerInput = Console.ReadLine();
                switch (playerInput)
                {
                    case "Rock":
                    case "rock":
                    case "r":
                        playerHand = Hands.Rock;
                        break;
                    case "Paper":
                    case "paper":
                    case "p":
                        playerHand = Hands.Paper;
                        break;
                    case "Scissors":
                    case "scissors":
                    case "s":
                        playerHand = Hands.Scissors;
                        break;
                    case "Quit":
                    case "quit":
                    case "q":
                        Console.WriteLine("Thanks for Playing! You played " + matchCount + " matches.");
                        Console.WriteLine("=========================================\n\n");
                        matchCount = 0;
                        winCount = 0;
                        loseCount = 0;
                        //continue;
                        return;
                    default:
                        Console.WriteLine("Answer not accepted, Try again.");
                        continue;
                }

                // decide result
                //robotHand = Hands.Rock;
                robotHand = (Hands) robotBrain.Next(1,4);
                //Console.WriteLine($"random = {robotHand}");
                switch (robotHand)
                {
                    case Hands.Rock: // robotHand
                        Console.WriteLine("vs. Rock");
                        switch (playerHand)
                        {
                            case Hands.Rock: // playerHand
                                result.matchTie();
                                break;
                            case Hands.Paper: // player hand
                                result.playerWin();
                                break;
                            case Hands.Scissors: // playerHand
                                result.robotWin();
                                break;
                            default:
                                // you should never get here
                                Console.WriteLine("playerHand comparison mishandled. Hand: {0}", playerHand);
                                return;
                                break;
                        }
                        break;
                    case Hands.Paper: // robotHand
                        Console.WriteLine("vs. Paper");
                        switch (playerHand)
                        {
                            case Hands.Rock: // playerHand
                                result.robotWin();
                                break;
                            case Hands.Paper: // player hand
                                result.matchTie();
                                break;
                            case Hands.Scissors: // playerHand
                                result.playerWin();
                                break;
                            default:
                                // you should never get here
                                Console.WriteLine("playerHand comparison mishandled. Hand: {0}", playerHand);
                                return;
                                break;
                        }
                        break;
                    case Hands.Scissors: // robotHand
                        Console.WriteLine("vs. Scissors");
                        switch (playerHand)
                        {
                            case Hands.Rock: // playerHand
                                result.playerWin();
                                break;
                            case Hands.Paper: // player hand
                                result.robotWin();
                                break;
                            case Hands.Scissors: // playerHand
                                result.matchTie();
                                break;
                            default:
                                // you should never get here
                                Console.WriteLine("playerHand comparison mishandled. Hand: {0}", playerHand);
                                return;
                                break;
                        }
                        break;
                    default: // robotHand
                        // you should never get here
                        Console.WriteLine("robotHand comparison mishandled.Hand: {0}", robotHand);
                        return;
                        break;
                } // end robotHand switch

            }

        }


    }
}
