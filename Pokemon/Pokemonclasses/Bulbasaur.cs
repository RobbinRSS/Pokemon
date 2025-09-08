class Bulbasaur : Pokemon
{
    public Bulbasaur(string name) : base(name, "Bulb Bulb", PokemonType.grass, PokemonType.fire)
    {
    }

    public override void BattleCry()
    {
        Console.WriteLine($"{name}: {battlecry}");
    }
}