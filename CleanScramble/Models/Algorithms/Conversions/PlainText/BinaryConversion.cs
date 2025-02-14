using System.Text;

namespace CleanScramble.Models.Algorithms.Conversions.PlainText;

public class BinaryConversion : IAlgorithm<string>
{
    public string Execute(string input)
    {
        StringBuilder result = new StringBuilder();
        List<bool> bits;
        
        foreach (char letter in input)
        {
            bits = [];
            
            var asciiValue = (int)letter;

            int quotient = asciiValue;
            
            while (quotient != 0)
            {
                bits.Add(quotient % 2 == 1);
                quotient /= 2;
            }

            result = OutputBitsFromList(bits, result);
        }

        return result.ToString();
    }

    private StringBuilder OutputBitsFromList(List<bool> bits, StringBuilder resultSet)
    {
        bits.Reverse();
        foreach (bool bit in bits)
        {
            if (bit)
            {
                resultSet.Append(1);
            }
            else
            {
                resultSet.Append(0);
            }
        }

        resultSet.Append(" ");

        return resultSet;
    }
}