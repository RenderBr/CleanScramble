using CleanScramble.Models.Algorithms;
using CleanScramble.Models.Algorithms.Logic;
using CleanScramble.Models.Requests;
using CleanScramble.Models.Settings;

namespace CleanScramble.Models.Factories;

public static class ScrambleRequestFactory
{
    public static ScrambleRequest<string> CreateWordScramble(string objectToScramble)
    {
        var defaultSettings = new WordScramblerSettings(new RandomWordScramblingAlgorithm(new Randomizer()));
        return new ScrambleRequest<string>(objectToScramble, defaultSettings);
    }
}