using System;

namespace PokemonApp
{
    abstract class Animal
    {
        // Fields
        int age;
        string color;
        string habitat;
        public int numLegs { get; set; }
        string genus;

        // Constructors
        public Animal (string color = "blue", string habitat = "ocean", int age = 3, int numLegs = 4, string genus = "K9")
        {
            this.age = age;
            this.color = color;
            this.habitat = habitat;
            this.numLegs = numLegs;
            this.genus = genus;
        }

        public Animal()
        {
            this.age = 3;
            this.color = "purple";
            this.habitat = "arctic";
            this.numLegs = 300;
            this.genus = "mammal";
        }
        // Methods

        public void Introduce()
        {
            Console.WriteLine($"Hello! I am a {this.genus} with {this.numLegs} legs, I'm {this.color}, and I live in the {this.habitat}.");
        }

        public abstract int CountLegs();

        public virtual string FindColor()
        {
            return this.color;
        }
    }
}