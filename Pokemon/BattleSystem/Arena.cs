class Arena
{
    static int rounds { get; set; }
    static int battles { get; set; }
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