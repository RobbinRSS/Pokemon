sealed class Pokeball
{
    public Pokemon pokemon { get; }

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