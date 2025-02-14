using CleanScramble.Models.Settings;

namespace CleanScramble.Models.Requests;

public record TransformRequest<T>(T ObjectToScramble, ITransformSettings<T> Settings);