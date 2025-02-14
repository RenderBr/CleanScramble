using CleanScramble.Models.Requests;

namespace CleanScramble.Models.Helpers;

public interface IScrambler<T>
{
    public T Scramble(ScrambleRequest<T> request);
}