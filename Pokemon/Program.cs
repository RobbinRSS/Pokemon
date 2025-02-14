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

    class Pokeball
    {
        public Charmander charmander;
        public bool isOpen;

        public Pokeball(Charmander charmander)
        {
            this.charmander = charmander;
            isOpen = false;
        }

        public void Throw()
        {
            if (isOpen){
                Console.WriteLine($"{charmander.name} was already outside his ball");
            }
            else
            {
                isOpen = true;
                Console.WriteLine($"{charmander.name} is thrown");
            }
        }

        public void Return()
        {
            if (isOpen)
            {
                isOpen = false;
                Console.WriteLine($"{charmander.name} returned to his ball");
            } else
            {
                Console.WriteLine($"{charmander.name} was already in his ball");
            }
        }

    }

    class Trainer
    {
        public string name;
        public List<Pokeball> belt = new List<Pokeball>();

        public Trainer(string name)
        {
            this.name = name;
            for (int i = 0; i < 6; i++)
            {
                belt.Add(new Pokeball(new Charmander($"Charmander {i + 1}", "Char Char")));
            }
        }

        public void ThrowPokeball(int index)
        {
            if (index < belt.Count)
            {
                Console.WriteLine($"{name} throws Pokeball {index + 1}!");
                belt[index].Throw();
            }
        }

        public void ReturnPokeball(int index)
        {
            if (index < belt.Count)
            {
                Console.WriteLine($"{name} returns Pokeball {index + 1}!");
                belt[index].Return();
            }
        }

    }

    class Program
    {

        public static void Main(string[] args)
        {
            Console.WriteLine("Geef je eerste trainer een naam");
            string trainer1Name = Console.ReadLine();
            Trainer trainer1 = new Trainer(trainer1Name);

            Console.WriteLine("Geef je tweede trainer een naam");
            string trainer2Name = Console.ReadLine();
            Trainer trainer2 = new Trainer(trainer2Name);

            for(int i = 0;i < 6; i++)
            {
                trainer1.ThrowPokeball(i);
                trainer2.ThrowPokeball(i);
                trainer1.ReturnPokeball(i);
                trainer2.ReturnPokeball(i);
            }


        }
    }

}