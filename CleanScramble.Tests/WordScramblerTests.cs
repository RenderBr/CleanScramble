using CleanScramble.Models.Algorithms;
using CleanScramble.Models.Algorithms.Logic;
using CleanScramble.Models.Factories;
using CleanScramble.Models.Helpers;
using CleanScramble.Models.Requests;
using CleanScramble.Models.Settings;
using Xunit.Abstractions;

namespace CleanScramble.Tests;

public class WordScramblerTests(ITestOutputHelper testOutputHelper)
{
    private readonly WordScrambler _wordScrambler = new();

    [Fact]
    public void GetScramble_UseNullString()
    {
        Assert.Throws<ArgumentNullException>(() => _wordScrambler.Scramble(null));
    }

    [Theory]
    [InlineData("")]
    [InlineData("\n")]
    [InlineData("          ")]
    public void GetScramble_UseEdgeCases(string input)
    {
        var request = ScrambleRequestFactory.CreateWordScramble(input);

        var result = _wordScrambler.Scramble(request);
        testOutputHelper.WriteLine("Scramble Result: " + result);
        Assert.Equal(request.ObjectToScramble, result);
    }

    [Theory]
    [InlineData("dog\n")]
    [InlineData("average")]
    [InlineData("杂志等中区别于图片的")]
    [InlineData("a e c v")]
    public void GetScramble_UseValidInputs(string input)
    {
        var request = ScrambleRequestFactory.CreateWordScramble(input);
            
        var result = _wordScrambler.Scramble(request);
        testOutputHelper.WriteLine("Scramble Result: " + result);
        Assert.True(input != result);
    }
}
