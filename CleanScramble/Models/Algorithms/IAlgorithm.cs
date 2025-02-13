namespace CleanScramble.Models.Algorithms;

public interface IAlgorithm<T>
{
    T Execute(T input);
}