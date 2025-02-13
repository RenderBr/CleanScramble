namespace CleanScramble.Models.Algorithms.Logic;

public class Randomizer : IRandomizer
{
    private readonly Random _random = new();
    public bool GetRandomBool() => _random.Next(0, 2) == 0;
}