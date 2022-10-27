using System;

namespace PokemonApp{

    class Pokemon {
        
        //Fields - by default they are Private. 
        public string name {get; set;}
        public int DexNumber {get; set;}
        public string type {get; set;}
        public string ability {get; set;}

        //Static field - every pokemon shares this field and it's value
        public static string isPokemon = "This is a static field. I'm in fact a pokemon.";
        
        //Constructor - method used for object initialization. We pass it the values we want 
        //to set for the object we are creating.

        public Pokemon(string PokemonName, int PokemonNum, string PokemonType, string PokemonAbility = "default?"){
            this.name = PokemonName;
            this.DexNumber = PokemonNum;
            this.type = PokemonType;
            this.ability = PokemonAbility;
        }

        public Pokemon() {
            //this.name = "Milky Way";
            //this.DexNumber = 14000000;
            //this.type = "galaxy";
            //this.ability = "black hole";
        }

        //Instance method - depends on the state of an instance of that class. Belongs to the object. 
        public void PrintName(){
            Console.WriteLine("My name is " + this.name + "." + " My number is " + this.DexNumber + ". My ability is " + this.ability);

        }

        //Static method - belongs to the class itself
        public static void PrintMessage(){
            Console.WriteLine("This is a static method, and I am a pokemon.");
        }

        //Method Overriding - ToString()
        public override string ToString(){
            return this.name + " " + this.type;
        }
    }


}