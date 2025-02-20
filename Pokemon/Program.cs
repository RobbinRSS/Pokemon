using System.Runtime.CompilerServices;
using System.Text;
using System.Xml.Linq;

namespace pokemonGame
{

    enum PokemonType
    {
        fire,
        water,
        grass
    }
    abstract class Pokemon
    {
        public readonly string name;
        public readonly string battlecry;

        public readonly PokemonType type; // make this an enum LATER
        public readonly PokemonType weakness; // make this an enum LATER

        public Pokemon(string name, string battlecry, PokemonType type, PokemonType weakness)
        {
            this.name = name;
            this.battlecry = battlecry;
            this.type = type;
            this.weakness = weakness;
        }

        // Elke pokemon maakt een geluid, maar niet allemaal hetzelfde geluid, daarom word er abstract gebruikt
        public abstract void BattleCry();
        
    }

    class Charmander : Pokemon
    {
        // base gebruikt de constructor van pokemon
        public Charmander(string name) : base(name, "Char! Char!", PokemonType.fire, PokemonType.water)
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
        public Squirtle(string name) : base(name, "Squi Squi!", PokemonType.water, PokemonType.grass)
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
        public Bulbasaur(string name) : base(name, "Bulb Bulb", PokemonType.grass, PokemonType.fire)
        {
        }

        public override void BattleCry()
        {
            Console.WriteLine($"{name}: {battlecry}");
        }
    }


    sealed class Pokeball
    {
        public readonly Pokemon pokemon;

        public Pokeball(Pokemon pokemon)
        {
            this.pokemon = pokemon;
        }

        public void Throw()
        {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"{pokemon.name} is thrown");
                pokemon.BattleCry();
                Console.ResetColor();
        }

        public void Return()
        {
                Console.ForegroundColor = ConsoleColor.Red;
                pokemon.BattleCry();
                Console.WriteLine($"{pokemon.name} returned to his ball");
                Console.ResetColor();
        }

        public Pokemon GetPokemon()
        {
            return this.pokemon;
        }

    }

    class Trainer
    {
        public string name;
        public readonly List<Pokeball> belt = new List<Pokeball>();

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

                if (pokemonTrainer1.type == PokemonType.fire && pokemonTrainer2.type == PokemonType.grass ||
                    pokemonTrainer1.type == PokemonType.water && pokemonTrainer2.type == PokemonType.fire ||
                    pokemonTrainer1.type == PokemonType.grass && pokemonTrainer2.type == PokemonType.water)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"{trainer1.name} wins this round!");
                    Console.ResetColor();

                    trainer2.ReturnPokeball(index2);
                    trainer2.belt.RemoveAt(index2);
                    Arena.GetBattles();
                }
                else if (pokemonTrainer2.type == PokemonType.fire && pokemonTrainer1.type == PokemonType.grass ||
                         pokemonTrainer2.type == PokemonType.water && pokemonTrainer1.type == PokemonType.fire ||
                         pokemonTrainer2.type == PokemonType.grass && pokemonTrainer1.type == PokemonType.water)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"{trainer2.name} wins this round!");
                    Console.ResetColor();

                    trainer1.ReturnPokeball(index1);
                    trainer1.belt.RemoveAt(index1);
                    Arena.GetBattles();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("It's a draw!");
                    Console.ResetColor();
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