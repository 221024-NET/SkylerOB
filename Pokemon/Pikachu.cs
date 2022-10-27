using System;

namespace PokemonApp {

    class Pikachu {
        
        //Fields - by default they are Private. 
        string nickname {get; set;}
        int health {get; set;}
        int speed {get; set;}
        int attack {get; set;}
        int defense {get; set;}

        //Static field - every pokemon shares this field and it's value
        public static string isPikachu = "This is a static field. I'm in fact a Pikachu.";
        
        //Constructor - method used for object initialization. We pass it the values we want 
        //to set for the object we are creating.
        public Pikachu(string nickname, int health, int speed, int attack, int defense) {
            this.nickname = nickname;
            this.health = health;
            this.speed = speed;
            this.attack = attack;
            this.defense = defense;
        }

        //public Pikachu();
        // more methods
    }
}
