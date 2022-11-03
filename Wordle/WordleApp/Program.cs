
using System;

namespace WordleApp
{
    public class Program
    {
        public static void Main()
        {
            Run();
        }

        public static void Run()
        {
            string path = "./words.txt";
            string[] words = File.ReadAllLines(path);

            char[] iSection = "_____".ToCharArray();
            string hidden = GetWord(words,1);
            //char[] hiddenUpper = hidden.ToUpper().ToCharArray();// Console.WriteLine("ToUpper: " + hiddenUpper);
            //Console.WriteLine(hidden);

            // record number of occurances of a letter
            Dictionary<char,int> freq = new Dictionary<char,int>();
            foreach(char c in hidden)
            {
                if(freq.ContainsKey(c))
                {
                    freq[c]++;
                }
                else
                {
                    freq.Add(c,1);
                }
            }
            Dictionary<char,int> fCOPY = new Dictionary<char,int>(freq);
            // foreach (KeyValuePair<char, int> kvp in fCOPY)
            // {
            //     Console.WriteLine("Key = {0}, Value = {1}", kvp.Key, kvp.Value);
            // }



            


            int rounds = 0;
            DateTime StartTime = DateTime.Now;


            /* Start the Game */
            Console.WriteLine("Welcome to ReVVordle");
            do 
            {
                Console.WriteLine("Guess a 5 letter word");
                string UserInput = Console.ReadLine().ToLower();
                rounds++;
                
                /* check if guess contains matching letters */
                for(int i=0; i<5; i++) {
                    if(hidden.Contains(UserInput[i]) && fCOPY[hidden[i]]>0)
                    {
                        fCOPY[hidden[i]] = fCOPY[hidden[i]] - 1;
                        iSection[i] = UserInput[i];
                    }
                }
                fCOPY = new Dictionary<char,int>(freq);
                // Console.WriteLine(iSection);

                /* check if guess contains exact matches */
                for(int i=0; i<5; i++) {
                    if(hidden[i]==iSection[i])
                    {
                        //iSection[i] = (char) ((Int16)iSection[i] - 52);
                        iSection[i] = char.ToUpper(iSection[i]);

                    }
                }
                
                /* check for reoccuring exact matches */
                for(int i=0; i<5; i++) 
                {
                    if(fCOPY.ContainsKey(iSection[i]))
                    {
                        if(fCOPY[iSection[i]]==0) 
                        {
                            iSection[i]='_';
                        }
                        else{
                            fCOPY[iSection[i]]--;
                        }
                    }
                }
                for(int i=0; i<5; i++) 
                {
                    if(fCOPY.ContainsKey(char.ToUpper(iSection[i])))
                    {
                        if(fCOPY[iSection[i]]==0) 
                        {
                            iSection[i]='_';
                        }
                        else{
                            fCOPY[iSection[i]]--;
                        }
                    }
                }
                fCOPY = new Dictionary<char,int>(freq);
                Console.WriteLine(iSection);
                //interSection = iSection
            }
            while (!iSection.SequenceEqual(hidden.ToUpper().ToCharArray()));
            DateTime EndTime = DateTime.Now;

            TimeSpan dur = EndTime - StartTime;
            Console.WriteLine("You took {0} seconds", dur.TotalSeconds);
        }




        private static string GetRandomWord(string[] bigList)
        {
            Random rand = new Random();
            int i = rand.Next(bigList.Length);
            return bigList[i];
        }

        private static string GetWord(string[] bigList, int preset)
        {
            return bigList[preset];
        }
    }
}