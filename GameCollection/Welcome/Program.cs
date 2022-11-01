using System;
//using HotAndColdGame;

namespace Welcome
{
    class Program
    {
        public static void Main(string[] args)
        {
            bool run = true;
            while (run)
            {
                int userInput = -1;
                do
                {
                    Console.WriteLine("Choose the game you want to play by typing the number and pressing 'enter'");
                    Console.WriteLine("1 - CoinFlipper");
                    Console.WriteLine("2 - Hot and Cold");
                    Console.WriteLine("Any other number to exit Game Collection");
                } while (!Int32.TryParse(Console.ReadLine(), out userInput));

                // 
                switch (userInput)
                {
                    case 1:
                        //CoinFlipper();
                        Console.WriteLine("Coin Flipper selected");
                        break;
                    case 2:
                        //HotAndCold();
                        Console.WriteLine("Hot and Cold selected");
                        break;
                    default:
                        // player opted to exit
                        Console.WriteLine("Opted to leave Game Collection");
                        run = false;
                        break;
                }
            }
        }
    }
}
