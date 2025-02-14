using CleanScramble.Models.Algorithms;
using CleanScramble.Models.Algorithms.Logic;
using CleanScramble.Models.Requests;
using CleanScramble.Models.Settings;

namespace CleanScramble.Models.Factories;

public static class ScrambleRequestFactory
{
    public static TransformRequest<string> CreateWordScramble(string objectToScramble)
    {
        var defaultSettings = new WordTransformSettings(new RandomWordShuffler(new Randomizer()));
        return new TransformRequest<string>(objectToScramble, defaultSettings);
    }

    public static TransformRequest<string> UseCustomScramblerAlgorithm(string objectToScramble,
        IAlgorithm<string> algorithm)
    {
        return new TransformRequest<string>(objectToScramble, new WordTransformSettings(algorithm));
    }

    public static TransformRequest<string> CreateRailFenceCyper(string objectToScramble, int numberOfRails)
    {
        return new TransformRequest<string>(objectToScramble,
            new WordTransformSettings(new RailFenceCipher(RailFenceCipherSettings.FromRails(numberOfRails))));
    }
}