namespace CleanScramble.Models.Settings;

public class CaesarCipherSettings : ICaesarCipherSettings
{
    private CaesarCipherSettings(int rotations)
    {
        Rotations = rotations;
    }
    
    public int Rotations { get; }

    public static CaesarCipherSettings FromRotations(int rotations) => new(rotations);
}