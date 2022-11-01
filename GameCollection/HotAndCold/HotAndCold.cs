using System;

namespace HotAndColdGame
{
    public class HotAndCold
    {
        // fields
        // constructor
        public HotAndCold() { }

        // methods
        public static void Main()
        {
            Guessing game = new Guessing();

            Console.WriteLine("Number Guesser started:");

            int secretNum = game.GenerateSecretNumber();
            
            int userNum = 0;

            do
            {
                userNum = game.GetUserNumber();

                Console.WriteLine( game.PrintResult( secretNum, userNum ) );
                
            } while (secretNum != userNum);

            Console.WriteLine("Thanks for playing!");

            return;
        }
    }
}