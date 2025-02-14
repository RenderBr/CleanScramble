using CleanScramble.Models.Algorithms;
using CleanScramble.Models.Factories;
using CleanScramble.Models.Helpers;
using CleanScramble.Models.Requests;
using Microsoft.Extensions.Logging;

namespace CleanScramble.Tests;

public class WordScramblerTests
{
    private readonly WordScrambler _wordScrambler = new();

    private readonly IAlgorithm<string>[] _algorithms =
    [
        AlgorithmProvider.Instance.BasicWordShuffler,
        AlgorithmProvider.Instance.CaesarCipher,
        AlgorithmProvider.Instance.Rot13,
        AlgorithmProvider.Instance.RailFenceCipher,
        AlgorithmProvider.Instance.Repeater,
        AlgorithmProvider.Instance.BinaryConversion
    ];

    private readonly ILogger _logger;
    private readonly ITestOutputHelper _testOutputHelper;

    private void LogOutput(string message)
    {
        _logger.LogInformation(message);
        _testOutputHelper.WriteLine(message);
    }

    public WordScramblerTests(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
        
        using var loggerFactory = LoggerFactory.Create(builder =>
        {
            builder.AddProvider(new FileLoggerProvider("testlog.txt"));
            builder.SetMinimumLevel(LogLevel.Information);
        });

        _logger = loggerFactory.CreateLogger<WordScramblerTests>();

        LogOutput("Test setup complete.");
    }

    [Fact]
    public void GetScramble_UseNullValueRequest()
    {
        Assert.Throws<ArgumentNullException>(() => _wordScrambler.Transform(null));
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

            var result = _wordScrambler.Transform(request);
            OutputResult(algorithm, result);
            Assert.Equal(request.ObjectToScramble, result);
        });
    }

    [Theory]
    [InlineData("Average", 3)]
    [InlineData("Hey guys whats up", 10)]
    [InlineData(PlaceholderText.LoremIpsumParagraph, 50)]
    public void GetRailFenceCipher_UseValidInputs(string input, int rails)
    {
        var request = ScrambleRequestFactory.CreateRailFenceCyper(input, rails);

        var result = _wordScrambler.Transform(request);
        OutputResult(request.Settings.Algorithm, result);
        Assert.True(input != result);
    }

    [Theory]
    [InlineData("dog\n")]
    [InlineData("average")]
    [InlineData("tim")]
    [InlineData("beano999")]
    [InlineData("a e c v")]
    [InlineData(PlaceholderText.LoremIpsumParagraph)]
    public void GetScramble_UseValidInputs(string input)
    {
        DoForEachAlgorithm((algorithm) =>
        {
            var request = ScrambleRequestFactory.UseCustomScramblerAlgorithm(input, algorithm);

            var result = _wordScrambler.Transform(request);
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
        LogOutput($"{algorithm.GetType().FullName}" +
                  $"\n\t| Result: {(algorithm.GetType() != typeof(RailFenceCipher) ? $"{result}" :
                      $"\n{result}")}\n"
        );
    }
}