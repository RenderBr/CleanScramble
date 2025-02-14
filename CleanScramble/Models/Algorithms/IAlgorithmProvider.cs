namespace CleanScramble.Models.Algorithms;

public interface IAlgorithmProvider
{
    RandomWordShuffler BasicWordShuffler { get; }
    CaesarCipher CaesarCipher { get; }
    
    CaesarCipher Rot13 { get; }
}