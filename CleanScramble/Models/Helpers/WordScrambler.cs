using CleanScramble.Models.Requests;

namespace CleanScramble.Models.Helpers;

public class WordScrambler : ITransformer<string>
{
    public string Transform(TransformRequest<string> request)
    {
        ArgumentNullException.ThrowIfNull(request);
        ArgumentNullException.ThrowIfNull(request.ObjectToScramble);
        ArgumentNullException.ThrowIfNull(request.Settings);

        if (string.IsNullOrWhiteSpace(request.ObjectToScramble) || request.ObjectToScramble.Length < 2)
        {
            return request.ObjectToScramble; // This word has no scramble opportunities
        }

        return request.Settings.EnforceDifference
            ? ScrambleAndEnsureDifference(request)
            : request.Settings.Algorithm.Execute(request.ObjectToScramble);
    }

    private static string ScrambleAndEnsureDifference(TransformRequest<string> request)
    {
        for (var attempts = 0; attempts < request.Settings.MaxAttempts; attempts++)
        {
            var scrambledWord = request.Settings.Algorithm.Execute(request.ObjectToScramble);
            if (scrambledWord != request.ObjectToScramble)
            {
                return scrambledWord;
            }
        }

        return request.ObjectToScramble;
    }
}