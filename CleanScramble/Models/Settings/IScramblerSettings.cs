using CleanScramble.Models.Algorithms;

namespace CleanScramble.Models.Settings;

public interface IScramblerSettings<T>
{
    public IAlgorithm<T> Algorithm { get; }
    public bool EnforceDifference { get; }
    public int MaxAttempts { get; }
}