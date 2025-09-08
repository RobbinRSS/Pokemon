abstract class Pokemon
{
    public string name { get; }
    public string battlecry { get; }

    public PokemonType type { get; }
    public PokemonType weakness { get; }

    protected Pokemon(string name, string battlecry, PokemonType type, PokemonType weakness)
    {
        this.name = name;
        this.battlecry = battlecry;
        this.type = type;
        this.weakness = weakness;
    }

    // Elke pokemon maakt een geluid, maar niet allemaal hetzelfde geluid, daarom word er abstract gebruikt
    public abstract void BattleCry();

}