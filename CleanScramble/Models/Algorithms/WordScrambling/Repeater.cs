using System.Text;
using CleanScramble.Models.Algorithms.Logic;

namespace CleanScramble.Models.Algorithms;

public class Repeater(IRandomizer randomizer) : IAlgorithm<string>
{
    public string Execute(string input)
    {
        StringBuilder result = new();

        var exclusives = new char[] { ' ', '\n' };
        
        foreach (char letter in input)
        {
            if (randomizer.GetRandomBool() && !exclusives.Contains(letter))
            {
                result.Append(new string(letter, randomizer.GetRandomInteger()));
                continue;
            }
            
            result.Append(letter);
        }

        return result.ToString();
    }
}