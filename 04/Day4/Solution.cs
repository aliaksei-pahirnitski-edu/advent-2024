namespace Day4;

internal static class Solution
{
    public static int FindXmasCount(string input)
    {
        return FindXmasCount(ToArray(input));
    }

    public static char[,] ToArray(string input)
    {
        var lines = input.Split('\n', StringSplitOptions.RemoveEmptyEntries);
        int n = lines.Length;
        int m = lines[0].Length;
        var chars = new char[n, m];

        for (int i = 0; i < n; i++)
        {
            var t = lines[i].Length;
            for (int j = 0; j < m; j++)
            {
                chars[i, j] = lines[i][j];
            }
        }

        return chars;
    }

    public static int FindXmasCount(char[,] chars)
    {
        var count = 0;
        count += FindHorizontalCount(chars);
        count += FindVerticalCount(chars);
        count += FindDiagonalCount(chars);

        return count;
    }

    public static int FindHorizontalCount(char[,] chars)
    {
        int count = 0;

        for (int i = 0; i < chars.GetLength(0); i++)
        {
            for (int j = 0; j < chars.GetLength(1) - 3; j++)
            {
                if (chars[i, j] == 'X' && chars[i, j + 1] == 'M' && chars[i, j + 2] == 'A' && chars[i, j + 3] == 'S') count++;
                if (chars[i, j + 3] == 'X' && chars[i, j + 2] == 'M' && chars[i, j + 1] == 'A' && chars[i, j] == 'S') count++;
            }
        }

        return count;
    }

    public static int FindVerticalCount(char[,] chars)
    {
        int count = 0;

        for (int i = 0; i < chars.GetLength(0) - 3; i++)
        {
            for (int j = 0; j < chars.GetLength(1); j++)
            {
                if (chars[i, j] == 'X' && chars[i + 1, j] == 'M' && chars[i + 2, j] == 'A' && chars[i + 3, j] == 'S') count++;
                if (chars[i + 3, j] == 'X' && chars[i + 2, j] == 'M' && chars[i + 1, j] == 'A' && chars[i, j] == 'S') count++;
            }
        }

        return count;
    }

    public static int FindDiagonalCount(char[,] chars)
    {
        int count = 0;

        for (int i = 0; i < chars.GetLength(0) - 3; i++)
        {
            for (int j = 0; j < chars.GetLength(1) - 3; j++)
            {
                if (chars[i, j] == 'X' && chars[i + 1, j + 1] == 'M' && chars[i + 2, j + 2] == 'A' && chars[i + 3, j + 3] == 'S') count++;
                if (chars[i + 3, j + 3] == 'X' && chars[i + 2, j + 2] == 'M' && chars[i + 1, j + 1] == 'A' && chars[i, j] == 'S') count++;

                if (chars[i, j + 3] == 'X' && chars[i + 1, j + 2] == 'M' && chars[i + 2, j + 1] == 'A' && chars[i + 3, j] == 'S') count++;
                if (chars[i + 3, j] == 'X' && chars[i + 2, j + 1] == 'M' && chars[i + 1, j + 2] == 'A' && chars[i, j + 3] == 'S') count++;
            }
        }

        return count;
    }
}
