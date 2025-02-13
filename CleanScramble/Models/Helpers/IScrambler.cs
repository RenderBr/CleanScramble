namespace CleanScramble.Models.Helpers;

public interface IScrambler<T>
{
    public T Scramble(T objectToScramble, bool enforceDifference = true);
}