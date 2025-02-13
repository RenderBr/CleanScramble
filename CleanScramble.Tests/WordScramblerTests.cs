using CleanScramble.Models.Algorithms;
using CleanScramble.Models.Algorithms.Logic;
using CleanScramble.Models.Helpers;
using Xunit.Abstractions;

namespace CleanScramble.Tests;

public class WordScramblerTests(ITestOutputHelper testOutputHelper)
{
    private readonly WordScrambler _wordScrambler = new(new RandomWordScramblingAlgorithm(new Randomizer()));

    [Fact]
    public void GetScramble_UseNullString()
    {
        Assert.Throws<ArgumentNullException>(() => _wordScrambler.Scramble(null));
    }

    [Fact]
    public void GetScramble_UseEmptyString()
    {
        var emptyString = string.Empty;

        var result = _wordScrambler.Scramble(emptyString);
        Assert.Equal(emptyString, result);
    }

    [Fact]
    public void GetScramble_UseSpecialCharacter()
    {
        var specialCharacter = "\n";

        var result = _wordScrambler.Scramble(specialCharacter);
        testOutputHelper.WriteLine("Scramble Result: " + result);
        Assert.Equal(specialCharacter, result);
    }

    [Fact]
    public void GetScramble_UseValidWordWithSpecialCharacter()
    {
        var word = "dog\n";

        var result = _wordScrambler.Scramble(word);
        testOutputHelper.WriteLine("Scramble Result: " + result);
        Assert.True(word != result);
    }

    [Fact]
    public void GetScramble_UseValidWord()
    {
        var word = "average";

        var result = _wordScrambler.Scramble(word);
        testOutputHelper.WriteLine("Scramble Result: " + result);
        Assert.True(word != result);
    }
}