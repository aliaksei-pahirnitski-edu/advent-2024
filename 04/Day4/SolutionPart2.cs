namespace Day4;

internal static class SolutionPart2
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
        int count = 0;

        for (int i = 1; i < chars.GetLength(0) - 1; i++)
        {
            for (int j = 1; j < chars.GetLength(1) - 1; j++)
            {
                if (chars[i, j] != 'A') continue;

                if ((chars[i - 1, j - 1] == 'M' && chars[i + 1, j + 1] == 'S' || chars[i - 1, j - 1] == 'S' && chars[i + 1, j + 1] == 'M')
                    && (chars[i + 1, j - 1] == 'M' && chars[i - 1, j + 1] == 'S' || chars[i + 1, j - 1] == 'S' && chars[i - 1, j + 1] == 'M')
                    ) count++;
            }
        }

        return count;
    }
}
