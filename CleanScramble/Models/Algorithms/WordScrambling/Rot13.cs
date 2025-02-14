using CleanScramble.Models.Settings;

namespace CleanScramble.Models.Algorithms;

public class Rot13() : CaesarCipher(CaesarCipherSettings.FromRotations(13));