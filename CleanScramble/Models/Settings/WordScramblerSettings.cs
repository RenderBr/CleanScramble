using CleanScramble.Models.Algorithms;

namespace CleanScramble.Models.Settings;

public class WordTransformSettings(IAlgorithm<string> algorithm) : ITransformSettings<string>
{
    public IAlgorithm<string> Algorithm { get; } = algorithm ?? throw new ArgumentNullException(nameof(algorithm));
    public bool EnforceDifference => true;
    public int MaxAttempts => 10;
}