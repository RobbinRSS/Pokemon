using System.Xml.Linq;

namespace pokemon
{

    class Charmander
    {
        public string name;
        public string battlecry;

        public Charmander(string name, string battlecry)
        {
            this.name = name;
            this.battlecry = battlecry;
        }

        public void BattleCry()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"{name}: {battlecry}");
            }
        }

        public void SetName()
        {
            Console.Write("Geef je charmander een naam ");
            string name = Console.ReadLine();
            this.name = name;
            Console.WriteLine($"Je Charmander heet nu {this.name}!");
        }
    }

    class Program
    {

        public static void Main(string[] args)
        {        
            Charmander charmander1 = new Charmander("Charmander", "Char Char");

            charmander1.SetName();
            charmander1.BattleCry();

            while (true)
            {
                Console.WriteLine("Wil je een nieuwe naam aan je charmander geven (ja/nee)");
                string input = Console.ReadLine().ToLower();
                
                // guard clause
                if (input == "nee") break;

                charmander1.SetName();
                charmander1.BattleCry();


            }

        }
    }

}