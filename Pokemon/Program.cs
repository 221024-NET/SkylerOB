using System;
using PokemonApp;

namespace Program{

    class Program{

        static void Main(string[] args)
        {
            //Initializing an object
            //We call the constructor, and pass it the desired values for this object
            Pokemon pikachu = new Pokemon("Pikachu", 25, "Electric", "Static");
            Pokemon pikachu2 = new Pokemon("Pikachu", 25, "Electric");
            Bulbasaur starter = new Bulbasaur("Bulba",10,10,10,10);

            //Calling an Instance method - belongs to the object itself.
            //Called by using object.method() 
            pikachu.PrintName();
            pikachu.PrintName();
            starter.PrintName();

            //Calling a Static method - belongs to the class.
            //Called by using Class.method()
            Pokemon.PrintMessage();
            Bulbasaur.PrintMessage();

            //Accessing a Static field - belongs to the class.
            //Called by referencing the class itself.
            Console.WriteLine(Pokemon.isPokemon);
            Console.WriteLine(Bulbasaur.isPokemon);
            Console.WriteLine(Bulbasaur.isBulbasaur);


            Console.WriteLine(pikachu.ToString());
            Console.WriteLine(starter.ToString());
        }
        

    }

}