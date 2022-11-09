using System.Text;
using System.IO;
using System.Xml.Serialization;

namespace Wordle
{
    public class User : IEquatable<User>
    {
        // Fields
        [XmlAttribute]
        public int UserId { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
        public int wins { get; set; }
        public int losses { get; set; }
        public double averageTurns {get; set; }
        public int[] turns { get; set; } // turns to win by index

        public XmlSerializer Serializer { get; } = new XmlSerializer(typeof(List<User>));

        // Costructors
        public User (){}

        public User (User toCopy)
        {
            userName = toCopy.userName;
            password = toCopy.password;
            wins = toCopy.wins;
            losses = toCopy.losses;
            averageTurns = toCopy.averageTurns;
            turns = toCopy.turns;
        }
        public User(string userName, string password)
        {
            this.userName = userName;
            this.password = password;
            this.wins = 0;
            this.losses = 0;
            this.averageTurns = 0;
            this.turns = new int[]{0,0,0,0,0,0,0};
        }

        public User (string userName, string password, int wins, int losses, double averageTurns, int[] turns) 
        {
            this.userName = userName;
            this.password = password;
            this.wins = wins;
            this.losses = losses;
            this.averageTurns = averageTurns;
            this.turns = turns;
        }

        // Methods
        public void UpdateRecord(bool win, int turn)
        {
            if(win)
            {
                this.wins++;
                this.turns[turn]++;
                this.averageTurns = FindAverage();//turn);                
            }

            else
                this.losses++;
        }

        public double FindAverage()//int turn)
        {
            int sum = 0;
            int count = 0;
            
            for (int i = 1; i <= 6; i++)
            {
                sum += (turns[i] * i);
                count += turns[i];
            }
            return sum/count;
        }

        public string DisplayRecord(List<User> records)
        {
            StringBuilder result = new StringBuilder();
            
            result.AppendLine("Player \t\t Wins \t\t Losses \t\t Average turns to win");
            foreach (User record in records)
            {                   
                result.AppendLine($"{record.userName} \t{record.wins}\t\t {record.losses}\t\t {record.averageTurns}");
            }
            return result.ToString();
        }

        public void SerializeAsXml(List<User> records)
        {

            var newStringWriter = new StringWriter();
            Serializer.Serialize(newStringWriter, records);
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.Parent.FullName;
            File.WriteAllText(projectDirectory + "./Userzone/xml", newStringWriter.ToString());
           
            newStringWriter.Close();
        }

        public List<User> ReadFromXml()
        {
            //StreamReader reader = new StreamReader("C:/Users/TOWER/Desktop/revrev/SkylerOB/WordleTrC/Userzone/xml");// "./xml");
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.Parent.FullName;
            StreamReader reader = new StreamReader(projectDirectory + "./Userzone/xml");
            var records = (List<User>?)Serializer.Deserialize(reader);
            reader.Close();
            return records;
        }


         /** my additions  **/
        /* override Equals */
        public override bool Equals(object? obj2)
        {
            // check incoming object
            if (obj2 == null || GetType() != obj2.GetType())
            {
                Console.WriteLine("bad");
                return false;
            }

            User? user2 = obj2 as User;
            if (this.userName == user2.userName)
            {
                Console.WriteLine("name same");
                if (this.password == user2.password)
                {
                    Console.WriteLine("pass same");
                    return (1 == 1);
                }
                else Console.WriteLine("pass what");
            }
            Console.WriteLine("who's that");
            return (1 == 0);
        }
        
        public override int GetHashCode()
        {
            return userName.GetHashCode();
        }
        
        public bool Equals(User other)
        {
            if (other == null) return false;
            return (this.userName.Equals(other.userName) && this.password.Equals(other.password));
        }

        /* Search List for the given player(which may only be a name and pass) and return the full info */
        public User FindExistingPlayerByCred(List<User> list, User player)
        {
            if(!list.Contains(player)) return null;
            return list[list.IndexOf(player)];
        }

        public bool CheckExistingPlayerByCred(List<User> list, User player)
        {
            if(!list.Contains(player)) return false;
            return true;
        }

        /* adds either
         * a new player with a new playthrough or
         * the new playthrough of a reoccuring player
         */
        public void AddNewPlaythrough(List<User> list)
        {
            User found = FindExistingPlayerByCred(list,this);
            if(found != null)
            {
                list.Remove(found);
                found.wins += this.wins;
                found.losses += this.losses;
                for(int i=1;i<=6;i++) found.turns[i] += this.turns[i];
                found.averageTurns = FindAverage();
                list.Add(found);
            }
            else
            {
                list.Add(this);
            }
        }

        /* Main for unit testing */
        public static void Main()
        {
            Console.WriteLine("Let's begin");
            List<User> players = new List<User>();
            User player1 = new User("name","pass");
            User player2 = new User(player1);
            Console.WriteLine(player1 == player2 ? "same" : "who?");
            Console.WriteLine(player1.Equals(player2) ? "same" : "who?");

            return;

            players.Add(player1);
            foreach (User U in players) Console.WriteLine(U.userName);
            Console.WriteLine(player1.CheckExistingPlayerByCred(players, player2) ? "same" : "who?");
            player1.UpdateRecord(true, 5);
            Console.WriteLine(player1.wins);
            player1.AddNewPlaythrough(players);
            foreach(User U in players) Console.WriteLine(U.DisplayRecord(players));
        }
    }
}