namespace Wordle{
    public class Program 
    {
        public static void Main(string[] args)
        {
            //string fpath = "C:/Users/TOWER/Desktop/revrev/SkylerOB/WordleTrC/Game/testFile.txt";
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            string fpath = projectDirectory + "./testFile.txt";
            string playerHistory = projectDirectory + "./.history";

            string[] words = File.ReadAllLines(fpath);

            var rand = new Random();
           
            bool solved=false;
            int turns=0;
            string guess;

            ConsoleColor[] feedback = {ConsoleColor.Gray,ConsoleColor.Gray,ConsoleColor.Gray,ConsoleColor.Gray,ConsoleColor.Gray};
            
            // create the user for the round  
            Console.WriteLine("Please enter your username:");
            string userName = Console.ReadLine();

            Console.WriteLine("Please enter your password:");
            string password = Console.ReadLine();

            User player = new User(userName, password);  

            List<User> records = player.ReadFromXml();

            bool loop = true;

            do //game loop
            {
                turns = 0;
                string secret = words[rand.Next(words.Length)].ToLower().Trim(); //random word from the list

// display the secret word for testing
Console.WriteLine(secret);

                while(turns<6){
                    Console.WriteLine("Guess: ");
                    guess = Console.ReadLine().ToLower();
                    if (guess==null || guess.Length!=5){
                        Console.WriteLine("Invalid guess. Must be a 5-letter word");
                        continue;
                    }//end of if
                    //guesses[turns].S=guess;
                    turns++;

                    //wrong guess, give feedback
                    for (int i=0;i<5;i++){
                        //guessed letter in the right place
                        if (guess[i]==secret[i]) {
                            Console.WriteLine("This {0} is in the right place",guess[i]);  
                            feedback[i]=ConsoleColor.Green;   
                            //guess[turns].setCharColor(ConsoleColor.Green,i);
                        }            
                        
                        //guessed letter wrong
                        //letter is or isn't in the word
                        else {
                            Console.WriteLine("The word {0} contain {1}",secret.Contains(guess[i])?"does":"does not",guess[i]);
                            feedback[i]=secret.Contains(guess[i])?ConsoleColor.Yellow:ConsoleColor.Gray;
                            /*
                            if secret.Contains(guess[i]) guesses[turns].setCharColor(ConsoleColor.Yellow,i);
                            //default color is gray so no need to set there 
                            */
                        }
                    }//end of for
                    //print the colored guess
                    /*If ColorString works just use the given method instead*/
                    for (int i=0;i<5;i++){
                        printcolor(guess[i],feedback[i]);
                        Console.BackgroundColor=ConsoleColor.Black;
                    }
                    Console.Write("\n");

                    //correct guess
                    if (guess==secret) {
                        solved=true;
                        break;
                    }//end of if
                }//end of while

                Console.Write(solved?"Solved ":"Not solved ");
                Console.WriteLine("within {0} turn(s). The word was: {1}",turns,secret);

        // update information about the user
            // win/loss, number of turns
                player.UpdateRecord(solved, turns);

                Console.WriteLine("Play Again? (Y or N)");
                string choice = Console.ReadLine();

                if(choice.ToUpper() != "Y")
                    loop = false;

                } while (loop);

// end loop here______________________________________
    // display player history

// replace adding the player to the records list with checking if the player is already on the list.
// we should be able to use some method call to accomplish this. 
//records.Add(player);
            player.AddNewPlaythrough(records);

            player.SerializeAsXml(records);
            Console.WriteLine(player.DisplayRecord(records));

        }

        //Print a char with a specific background color
        private static void printcolor(char c, ConsoleColor cc){
            Console.BackgroundColor=cc;
            Console.Write("{0}",c);
        }
    }
        
 }




