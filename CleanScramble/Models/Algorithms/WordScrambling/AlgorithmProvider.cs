using CleanScramble.Models.Algorithms.Conversions.PlainText;
using CleanScramble.Models.Algorithms.Logic;
using CleanScramble.Models.Settings;

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
        RailFenceCipher = new RailFenceCipher(RailFenceCipherSettings.FromRails(3));
        Repeater = new Repeater(new Randomizer());
        BinaryConversion = new BinaryConversion();
    }

    public RandomWordShuffler BasicWordShuffler { get; }
    public CaesarCipher CaesarCipher { get; }
    public CaesarCipher Rot13 { get; }
    public RailFenceCipher RailFenceCipher { get; }
    public Repeater Repeater { get; }

    public BinaryConversion BinaryConversion { get; }
}