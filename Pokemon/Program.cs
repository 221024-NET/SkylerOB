using System;
using PokemonApp;

namespace Program{

    class Program{

        static void Main(string[] args)
        {
            //Initializing an object
            //We call the constructor, and pass it the desired values for this object
            Pokemon pikachu = new Pokemon("Pikachu", 25, "Electric", 12, "Static");
            Pokemon pikachu2 = new Pokemon("Pikachu", 25, "Electric", 12);
            Pikachu starter = new Pikachu("Pika",10,10,10,10);

            //Calling an Instance method - belongs to the object itself.
            //Called by using object.method() 
            pikachu.PrintName();
            pikachu2.PrintName();
            //starter.PrintName();

            //Calling a Static method - belongs to the class.
            //Called by using Class.method()
            Pokemon.PrintMessage();
            //Pikachu.PrintMessage();

            //Accessing a Static field - belongs to the class.
            //Called by referencing the class itself.
            Console.WriteLine(Pokemon.isPokemon);
            //Console.WriteLine(Pikachu.isPokemon);
            //Console.WriteLine(Pikachu.isPikachu);


            Console.WriteLine(pikachu.ToString());
           // Console.WriteLine(starter.ToString());
        }
        

    }

}