using CleanScramble.Models.Algorithms.Conversions.PlainText;

namespace CleanScramble.Models.Algorithms;

public interface IAlgorithmProvider
{
    RandomWordShuffler BasicWordShuffler { get; }
    CaesarCipher CaesarCipher { get; }
    
    CaesarCipher Rot13 { get; }

    RailFenceCipher RailFenceCipher { get; }
    Repeater Repeater { get; }
    
    BinaryConversion BinaryConversion { get; }
}