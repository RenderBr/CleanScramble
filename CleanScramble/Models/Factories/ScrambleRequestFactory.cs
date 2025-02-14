using CleanScramble.Models.Algorithms;
using CleanScramble.Models.Algorithms.Logic;
using CleanScramble.Models.Requests;
using CleanScramble.Models.Settings;

namespace CleanScramble.Models.Factories;

public static class ScrambleRequestFactory
{
    public static ScrambleRequest<string> CreateWordScramble(string objectToScramble)
    {
        var defaultSettings = new WordScramblerSettings(new RandomWordShuffler(new Randomizer()));
        return new ScrambleRequest<string>(objectToScramble, defaultSettings);
    }

    public static ScrambleRequest<string> UseCustomScramblerAlgorithm(string objectToScramble,
        IAlgorithm<string> algorithm)
    {
        return new ScrambleRequest<string>(objectToScramble, new WordScramblerSettings(algorithm));
    }
}