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