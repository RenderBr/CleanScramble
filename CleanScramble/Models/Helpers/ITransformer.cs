using CleanScramble.Models.Requests;

namespace CleanScramble.Models.Helpers;

public interface ITransformer<T>
{
    public T Transform(TransformRequest<T> request);
}