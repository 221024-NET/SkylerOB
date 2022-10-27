using System;

namespace PokemonApp {

    class Bulbasaur : Pokemon{
        
        //Fields - by default they are Private. 
        string nickname {get; set;}// = "Bulbasaur"
        int health {get; set;}
        int speed {get; set;}
        int attack {get; set;}
        int defense {get; set;}

        //Static field - every pokemon shares this field and it's value
        public static string isBulbasaur = "This is a static field. I'm in fact a Bulbasaur.";
        
        //Constructor - method used for object initialization. We pass it the values we want 
        //to set for the object we are creating.
        public Bulbasaur(string nickname, int health, int speed, int attack, int defense)
            : base("Bulbasaur",1,"electric","static")
        {
            this.nickname = nickname;
            this.health = health;
            this.speed = speed;
            this.attack = attack;
            this.defense = defense;
        }

        public new void PrintName()
        {
            Console.WriteLine("You can call me " + nickname);
        }

        //public Bulbasaur();
        // more methods
    }
}
