using System.Text;

namespace CleanScramble.Models.Algorithms;

public class CaesarCipher : IAlgorithm<string>
{
    private const int CaesarShift = 3;
    private const int AlphabetLength = 26;

    public string Execute(string input)
    {
        StringBuilder sb = new();

        foreach (var letter in input)
        {
            if (char.IsAsciiLetter(letter))
            {
                int startingAsciiValue = GetStartingAsciiValue(char.IsUpper(letter));

                char shiftedCharacter = GetShiftedCharacter(startingAsciiValue, letter);

                sb.Append(shiftedCharacter);
                continue;
            }

            sb.Append(letter);
        }

        return sb.ToString();
    }

    private static int GetStartingAsciiValue(bool isUpperCase) => isUpperCase ? 'A' : 'a';

    private static char GetShiftedCharacter(int startingAsciiValue, char letter)
    {
        var letterAsciiValue = (int)letter;
        
        var shiftedValue = (letterAsciiValue - startingAsciiValue + CaesarShift)
                                    % AlphabetLength + startingAsciiValue;

        return (char)shiftedValue;
    }
}