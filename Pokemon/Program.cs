using System.Runtime.CompilerServices;
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
            Arena.GetRounds();
            while (trainer1.belt.Count > 0 && trainer2.belt.Count > 0)
            {
                int index1 = rnd.Next(0, trainer1.belt.Count);
                Pokemon pokemonTrainer1 = trainer1.belt[index1].GetPokemon();

                int index2 = rnd.Next(0, trainer2.belt.Count);
                Pokemon pokemonTrainer2 = trainer2.belt[index2].GetPokemon();

                trainer1.ThrowPokeball(index1);
                trainer2.ThrowPokeball(index2);

                if (pokemonTrainer1.type == "Fire" && pokemonTrainer2.type == "Grass" ||
                    pokemonTrainer1.type == "Water" && pokemonTrainer2.type == "Fire" ||
                    pokemonTrainer1.type == "Grass" && pokemonTrainer2.type == "Water")
                {
                    Console.WriteLine($"{trainer1.name} wins this round!");
                    trainer2.ReturnPokeball(index2);
                    trainer2.belt.RemoveAt(index2);
                    Arena.GetBattles();
                }
                else if (pokemonTrainer2.type == "Fire" && pokemonTrainer1.type == "Grass" ||
                         pokemonTrainer2.type == "Water" && pokemonTrainer1.type == "Fire" ||
                         pokemonTrainer2.type == "Grass" && pokemonTrainer1.type == "Water")
                {
                    Console.WriteLine($"{trainer2.name} wins this round!");
                    trainer1.ReturnPokeball(index1);
                    trainer1.belt.RemoveAt(index1);
                    Arena.GetBattles();
                }
                else
                {
                    Console.WriteLine("It's a draw! Both Pokémon are removed!");
                    trainer1.ReturnPokeball(index1);
                    trainer2.ReturnPokeball(index2);
                    trainer1.belt.RemoveAt(index1);
                    trainer2.belt.RemoveAt(index2);
                    Arena.GetBattles();
                }
                Arena.GetRounds();
            }

            if (trainer1.belt.Count == 0 && trainer2.belt.Count == 0)
                Console.WriteLine("It's a tie! Both trainers ran out of Pokémon.");
            else if (trainer1.belt.Count == 0)
                Console.WriteLine($"{trainer2.name} wins the battle!");
            else
                Console.WriteLine($"{trainer1.name} wins the battle!");
            Console.ReadKey();
        }
    }

    class Arena
    {
        static int rounds;
        static int battles;
        static Arena()
        {
            rounds = 0;
            battles = 0;
        }

        public static void GetRounds()
        {
            rounds = rounds + 1;
            Console.WriteLine($"Current round {rounds}");
        }

        public static void GetBattles()
        {
            battles = battles + 1;
            Console.WriteLine($"Amount of battles fought {battles}");

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

            Battle currentBattle = new Battle(trainer1, trainer2);

            currentBattle.PokemonBattle();
           

        }
    }

}