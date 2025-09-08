class Squirtle : Pokemon
{
    public Squirtle(string name) : base(name, "Squi Squi!", PokemonType.water, PokemonType.grass)
    {
    }
    public override void BattleCry()
    {
        Console.WriteLine($"{name}: {battlecry}");
    }
}