using CleanScramble.Models.Algorithms.Logic;

namespace CleanScramble.Models.Algorithms;

public class RandomWordScramblingAlgorithm(IRandomizer randomizer) : IAlgorithm<string>
{
    public string Execute(string input)
    {
        return new string(input.OrderBy(_ => randomizer.GetRandomBool()).ToArray());
    }
}