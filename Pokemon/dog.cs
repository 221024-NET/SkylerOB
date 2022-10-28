namespace PokemonApp
{
    class Dog : Animal , IAnimal
    {
        // Fields
        public int wagsPerMin;
        public string Bark;

        // Constructor
        public Dog (int wags, string bark) : base ()
        {
            this.wagsPerMin = wags;
            this.Bark = bark;
        }

        public override int CountLegs()
        {
           return this.numLegs;
        }

        public void Speak()
        {
            Console.WriteLine(Bark);
        }
    }
}