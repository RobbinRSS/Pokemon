class Trainer
{
    public const int PokeballsPerType = 2;
    public string name { get; }
    public List<Pokeball> belt { get; } = new List<Pokeball>();

    public Trainer(string name)
    {
        this.name = name;
        for (int i = 0; i < PokeballsPerType; i++)
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