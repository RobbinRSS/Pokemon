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
                pokemonTrainer1.type == PokemonType.grass && pokemonTrainer2.type == PokemonType.water) // If trainer 1 wins
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{trainer1.name} wins this round!");
                Console.ResetColor();

                trainer2.ReturnPokeball(index2);
                trainer2.belt.RemoveAt(index2);
                Arena.GetBattles();
            }
            else if (pokemonTrainer2.type == pokemonTrainer1.type) // DRAW
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
            else // If trainer 2 wins
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{trainer2.name} wins this round!");
                Console.ResetColor();

                trainer1.ReturnPokeball(index1);
                trainer1.belt.RemoveAt(index1);
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