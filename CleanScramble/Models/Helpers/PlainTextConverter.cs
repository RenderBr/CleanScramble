using CleanScramble.Models.Requests;

namespace CleanScramble.Models.Helpers;

public class PlainTextConverter : ITransformer<string>
{
    public string Transform(TransformRequest<string> request)
    {
        ArgumentNullException.ThrowIfNull(request);
        ArgumentNullException.ThrowIfNull(request.ObjectToScramble);
        ArgumentNullException.ThrowIfNull(request.Settings);

        return string.IsNullOrWhiteSpace(request.ObjectToScramble)
            ? request.ObjectToScramble // If nothing, no need to perform tasks
            : request.Settings.Algorithm.Execute(request.ObjectToScramble);
    }
}