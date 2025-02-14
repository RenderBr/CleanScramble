using CleanScramble.Models.Algorithms.Logic;

namespace CleanScramble.Models.Algorithms;

public sealed class AlgorithmProvider : IAlgorithmProvider
{
    private static readonly Lazy<AlgorithmProvider> LazyInstance = new(() => new AlgorithmProvider());

    public static AlgorithmProvider Instance => LazyInstance.Value;
    
    private AlgorithmProvider()
    {
        BasicWordShuffler = new RandomWordShuffler(new Randomizer());
        CaesarCipher = new CaesarCipher();
        Rot13 = new Rot13();
    }

    public RandomWordShuffler BasicWordShuffler { get; }
    public CaesarCipher CaesarCipher { get; }
    public CaesarCipher Rot13 { get; }
}