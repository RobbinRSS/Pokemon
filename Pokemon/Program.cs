using System.Xml.Linq;

namespace pokemonGame
{

    abstract class Pokemon
    {
        public string name;
        public string battlecry;
        public string type;
        public string weakness;

        public Pokemon(string name, string battlecry, string type, string weakness)
        {
            this.name = name;
            this.battlecry = battlecry;
            this.type = type;
            this.weakness = weakness;
        }

        // Elke pokemon maakt een geluid, maar niet allemaal hetzelfde geluid, daarom word er abstract gebruikt
        public abstract void BattleCry();
        
        public void SetName()
        {
            Console.Write("Geef je charmander een naam ");
            string name = Console.ReadLine();
            this.name = name;
            Console.WriteLine($"Je Charmander heet nu {this.name}!");
        }
    }

    class Charmander : Pokemon
    {
        // base gebruikt de constructor van pokemon
        public Charmander(string name) : base(name, "Char! Char!", "Fire", "Water")
        {
        }

        // hier word de BattleCry override, omdat een pokemon een geluid maakt
        public override void BattleCry()
        {
            Console.WriteLine($"{name}: {battlecry}");
        }
    }

    class Squirtle : Pokemon
    {
        // base gebruikt de constructor van pokemon
        public Squirtle(string name) : base(name, "Squi Squi!", "Water", "Grass")
        {
        }
        public override void BattleCry()
        {
            Console.WriteLine($"{name}: {battlecry}");
        }
    }

    class Bulbasaur : Pokemon
    {
        // base gebruikt de constructor van pokemon
        public Bulbasaur(string name) : base(name, "Bulb Bulb", "Grass", "Fire")
        {
        }

        public override void BattleCry()
        {
            Console.WriteLine($"{name}: {battlecry}");
        }
    }


    class Pokeball
    {
        public Pokemon pokemon;
        public bool isOpen;

        public Pokeball(Pokemon pokemon)
        {
            this.pokemon = pokemon;
            isOpen = false;
        }

        public void Throw()
        {
            if (isOpen){
                Console.WriteLine($"{pokemon.name} was already outside his ball");
            }
            else
            {
                isOpen = true;
                Console.WriteLine($"{pokemon.name} is thrown");
                pokemon.BattleCry();
            }
        }

        public void Return()
        {
            if (isOpen)
            {
                isOpen = false;
                pokemon.BattleCry();
                Console.WriteLine($"{pokemon.name} returned to his ball");
            } else
            {
                Console.WriteLine($"{pokemon.name} was already in his ball");
            }
        }

        public Pokemon GetPokemon()
        {
            return this.pokemon;
        }

    }

    class Trainer
    {
        public string name;
        public List<Pokeball> belt = new List<Pokeball>();

        public Trainer(string name)
        {
            this.name = name;
            for (int i = 0; i < 2; i++)
            {
                belt.Add(new Pokeball(new Charmander($"Charmander {i + 1}")));
                belt.Add(new Pokeball(new Squirtle($"Squirtle {i + 1}")));
                belt.Add(new Pokeball(new Bulbasaur($"Bulbasaur {i + 1}")));

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

    class Battle
    {
        public Trainer trainer1;
        public Trainer trainer2;
        Random rnd = new Random();

        public Battle(Trainer trainer1, Trainer trainer2)
        {
            this.trainer1 = trainer1;
            this.trainer2 = trainer2;

        }

        public void PokemonBattle()
        {

            // get a random pokemon from trainer 1
            int index1 = rnd.Next(0, trainer1.belt.Count);
            Pokemon pokemonTrainer1 = trainer1.belt[index1].GetPokemon();
            // get a random pokemon from trainer 2
            int index2 = rnd.Next(0, trainer2.belt.Count);
            Pokemon pokemonTrainer2 = trainer2.belt[index2].GetPokemon();

            // each player throws the pokemon with the random number



            // create the logic for the rock-paper-scissor style
            // if its a draw each pokemon returns to their pokeball
            // if a pokemon dies, remove him from the list, the winning pokemon stays

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

            Battle test1 = new Battle(trainer1, trainer2);

            test1.PokemonBattle();

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