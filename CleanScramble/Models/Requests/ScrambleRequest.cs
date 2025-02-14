using CleanScramble.Models.Algorithms;
using CleanScramble.Models.Algorithms.Logic;
using CleanScramble.Models.Settings;

namespace CleanScramble.Models.Requests;

public record ScrambleRequest<T>(T ObjectToScramble, IScramblerSettings<T> Settings);