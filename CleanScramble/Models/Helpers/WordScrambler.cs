using CleanScramble.Models.Algorithms;

namespace CleanScramble.Models.Helpers;

public class WordScrambler(IAlgorithm<string> algorithm, int maxAttempts = 10) : IScrambler<string>
{
    private IAlgorithm<string> Algorithm { get; } = algorithm ?? throw new ArgumentNullException(nameof(algorithm));
    
    public string Scramble(string unscrambledWord, bool enforceDifference = true)
    {
        if (unscrambledWord is null)
        {
            throw new ArgumentNullException(nameof(unscrambledWord));
        }
        
        if (string.IsNullOrWhiteSpace(unscrambledWord) || unscrambledWord.Length < 2)
        {
            return unscrambledWord; // This word has no scramble opportunities
        }

        return enforceDifference ? ScrambleAndEnsureDifference(unscrambledWord) : algorithm.Execute(unscrambledWord);
    }

    private string ScrambleAndEnsureDifference(string unscrambledWord)
    {
        for (var attempts = 0; attempts < maxAttempts; attempts++)
        {
            var scrambledWord = Algorithm.Execute(unscrambledWord);
            if (scrambledWord != unscrambledWord)
            {
                return scrambledWord;
            }
        }
        return unscrambledWord;
    }
}