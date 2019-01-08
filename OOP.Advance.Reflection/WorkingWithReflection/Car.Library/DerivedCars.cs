// Keep reading! This won't compile until you reference a .NET library.

namespace CarLibrary
{
    public class SportsCar : Car
    {
        public SportsCar() { }
        public SportsCar(string name, int maxSp, int currSp)
          : base(name, maxSp, currSp)
        { }

        public override void TurboBoost()
        {
            System.Console.WriteLine("Ramming speed!", "Faster is better...");
        }
    }

    public class MiniVan : Car
    {
        public MiniVan() { }
        public MiniVan(string name, int maxSp, int currSp)
          : base(name, maxSp, currSp)
        { }

        public override void TurboBoost()
        {
            // Minivans have poor turbo capabilities!
            egnState = EngineState.engineDead;
            System.Console.WriteLine("Eek!", "Your engine block exploded!");
        }
    }
}
