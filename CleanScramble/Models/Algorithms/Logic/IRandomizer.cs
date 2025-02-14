namespace CleanScramble.Models.Algorithms.Logic;

public interface IRandomizer
{
    bool GetRandomBool();

    int GetRandomInteger(int min = 0, int max = 100);
}