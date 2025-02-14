using System.Numerics;
using System.Text;
using CleanScramble.Models.Settings;

namespace CleanScramble.Models.Algorithms;

public class RailFenceCipher(RailFenceCipherSettings settings) : IAlgorithm<string>
{
    public string Execute(string input)
    {
        string[] filteredText = [" ", "\n", "\t"];
        foreach (var text in filteredText)
        {
            input = input.Replace(text, "");
        }
        
        bool movingDown = true;
        int matrixWidth = CalculateMatrixWidth(input.Length);
        char[,] railCoordinates = CreateEmptyRailMatrix(settings.Rails, matrixWidth);
        Vector2 currentPosition = Vector2.Zero;

        foreach (char letter in input)
        {
            if (currentPosition.X >= matrixWidth) // Break when we reach the end of the matrix's width
            {
                break;
            }

            railCoordinates[(int)currentPosition.Y, (int)currentPosition.X] = letter;
            currentPosition = Vector2.Add(currentPosition, GetMovementOffset(movingDown));

            movingDown = movingDown switch
            {
                true when currentPosition.Y >= settings.Rails - 1 => false,
                false when currentPosition.Y < 1 => true,
                _ => movingDown
            };
        }

        return BuildStringFromRailMatrix(railCoordinates);
    }

    private static int CalculateMatrixWidth(int textLength) => ((textLength - 1) * 2) + 1;

    private static Vector2 GetMovementOffset(bool movingDown) =>
        movingDown ? new Vector2(2, 1) : new Vector2(2, -1);

    private static char[,] CreateEmptyRailMatrix(int rows, int columns)
    {
        var railCoordinates = new char[rows, columns];

        for (int row = 0; row < railCoordinates.GetLength(0); row++)
        {
            for (int column = 0; column < railCoordinates.GetLength(1); column++)
            {
                railCoordinates[row, column] = ' ';
            }
        }
        return railCoordinates;
    }

    private static string BuildStringFromRailMatrix(char[,] matrix)
    {
        StringBuilder result = new();
        int rowCount = matrix.GetLength(0);
        int columnCount = matrix.GetLength(1);


        for (int row = 0; row < rowCount; row++)
        {
            for (int column = 0; column < columnCount; column++)
            {
                result.Append(matrix[row, column]);
            }
            result.Append('\n');
        }

        return result.ToString();
    }
}