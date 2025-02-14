namespace CleanScramble.Models.Settings;

public class RailFenceCipherSettings : IRailFenceCipherSettings
{
    private RailFenceCipherSettings(int rails)
    {
        Rails = rails;
    }
    
    public int Rails { get; }

    public static RailFenceCipherSettings FromRails(int rails) => new(rails);
}