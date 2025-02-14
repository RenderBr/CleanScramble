using CleanScramble.Models.Algorithms;
using CleanScramble.Models.Factories;
using CleanScramble.Models.Helpers;
using CleanScramble.Models.Requests;

namespace CleanScramble.Tests;

public class WordScramblerTests(ITestOutputHelper testOutputHelper)
{
    private readonly WordScrambler _wordScrambler = new();

    private readonly IAlgorithm<string>[] _algorithms =
    [
        AlgorithmProvider.Instance.BasicWordShuffler,
        AlgorithmProvider.Instance.CaesarCipher
    ];

    [Fact]
    public void GetScramble_UseNullValueRequest()
    {
        Assert.Throws<ArgumentNullException>(() => _wordScrambler.Scramble(null));
    }

    [Theory]
    [InlineData("")]
    [InlineData("\n")]
    [InlineData("          ")]
    public void GetScramble_UseEdgeCases(string input)
    {
        DoForEachAlgorithm((algorithm) =>
        {
            var request =
                ScrambleRequestFactory.UseCustomScramblerAlgorithm(input, algorithm);

            var result = _wordScrambler.Scramble(request);
            OutputResult(algorithm, result);
            Assert.Equal(request.ObjectToScramble, result);
        });
    }

    [Theory]
    [InlineData("dog\n")]
    [InlineData("average")]
    [InlineData("a e c v")]
    public void GetScramble_UseValidInputs(string input)
    {
        DoForEachAlgorithm((algorithm) =>
        {
            var request = ScrambleRequestFactory.UseCustomScramblerAlgorithm(input, algorithm);

            var result = _wordScrambler.Scramble(request);
            OutputResult(algorithm, result);
            Assert.True(input != result);
        });
    }

    private void DoForEachAlgorithm(Action<IAlgorithm<string>> action)
    {
        foreach (var algorithm in _algorithms)
        {
            action(algorithm);
        }
    }

    private void OutputResult<T>(IAlgorithm<T> algorithm, string result)
    {
        testOutputHelper.WriteLine($"Scramble Result {algorithm.GetType().Name}: {result}");
    }
}