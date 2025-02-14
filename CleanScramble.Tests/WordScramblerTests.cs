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

    [Fact]
    public void GetScramble_UseEmptyString()
    {
        var request = ScrambleRequestFactory.CreateWordScramble("");

        var result = _wordScrambler.Scramble(request);
        Assert.Equal(request.ObjectToScramble, result);
    }

    [Fact]
    public void GetScramble_UseSpecialCharacter()
    {
        var request = ScrambleRequestFactory.CreateWordScramble("\n");

        var result = _wordScrambler.Scramble(request);
        testOutputHelper.WriteLine("Scramble Result: " + result);
        Assert.Equal(request.ObjectToScramble, result);
    }

    [Fact]
    public void GetScramble_UseValidWordWithSpecialCharacter()
    {
        var word = "dog\n";
        var request = ScrambleRequestFactory.CreateWordScramble(word);
            
        var result = _wordScrambler.Scramble(request);
        testOutputHelper.WriteLine("Scramble Result: " + result);
        Assert.True(word != result);
    }

    [Fact]
    public void GetScramble_UseValidWord()
    {
        var word = "average";
        var request = ScrambleRequestFactory.CreateWordScramble(word);

        var result = _wordScrambler.Scramble(request);
        testOutputHelper.WriteLine("Scramble Result: " + result);
        Assert.True(word != result);
    }
}
