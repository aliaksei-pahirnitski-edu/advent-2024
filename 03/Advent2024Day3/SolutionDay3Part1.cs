using System.Text.RegularExpressions;

namespace Advent2024Day3;

internal static class SolutionDay3Part1
{
    private static Regex regex0 = new Regex("mul\\((\\d+),(\\d+)\\)");
    private static Regex regex = new Regex("mul\\((?<a>\\d+),(?<b>\\d+)\\)");

    public static int Solve0(string puzzleInput)
    {        
        return FindPairs0(puzzleInput).Sum(p => p.a * p.b);
    }

    public static int Solve(string puzzleInput)
    {
        
        return FindPairs3(puzzleInput).Sum(p => p.a * p.b);
    }

    public static IEnumerable<(int a, int b)> FindPairs(string puzzleInput)
    {
        IList<(int a, int b)> pairs = [];
        var span = puzzleInput.AsSpan();
        var matches = regex.EnumerateMatches(puzzleInput);
        foreach (var match in matches)
        {
            var piece = span[match.Index..(match.Index + match.Length)];
            var debug = piece.ToString();
        }
        return pairs;
    }

    public static IEnumerable<(int a, int b)> FindPairs3(string puzzleInput)
    {
        IList<(int a, int b)> pairs = [];
        var matches = regex.Matches(puzzleInput);
        foreach (Match match in matches)
        {
            var debug = match.Groups;
            var aGr = match.Groups["a"];
            var bGr = match.Groups["b"];
            var cGr = match.Groups["c"];

            var aStr = aGr.Value;
            var bStr = bGr.Value;

            var a = int.Parse(aGr.ValueSpan);
            var b = int.Parse(bGr.ValueSpan);
            pairs.Add((a, b));
        }
        return pairs;
    }

    public static IEnumerable<(int a, int b)> FindPairs0(string puzzleInput)
    {
        // example: "mul(1,2)mul(3,4)";
        IList<(int a, int b)> pairs = [];

        const string prefix = "mul(";
        var prefixAsSpan = prefix.AsSpan();
        int prefixLen = prefix.Length;

        const char commaChar = ',';
        const char start = 'm';
        const char endChar = ')';
        int minBlockLen = prefix.Length + 4;

        var span = puzzleInput.AsSpan();
        int fullLength = span.Length;
        for (int i = 0; i <= fullLength-minBlockLen; i++)
        {
            if (span[i] != start) continue;
            if (span[i + 1] != prefixAsSpan[1]) continue;
            if (span[i + 2] != prefixAsSpan[2]) continue;
            if (span[i + 3] != prefixAsSpan[3]) continue;

            // prefix 'mul(' found, now search comma
            int foundCommaIndex = 0;
            for (int commaIndex = i + prefixLen; commaIndex < fullLength; commaIndex++)
            {
                if (span[commaIndex] == commaChar)
                {
                    foundCommaIndex = commaIndex;
                    break;
                }
                else if (span[commaIndex] - '0' < 0 || span[commaIndex] - '0' > 9)
                {
                    break;
                }
            }
            if (foundCommaIndex == 0) continue; // comma not found

            // comma found, search closing bracket
            int foundEndIndex = 0;
            for (int endIndex = foundCommaIndex + 1; endIndex < fullLength; endIndex++)
            {
                if (span[endIndex] == endChar)
                {
                    foundEndIndex = endIndex;
                    break;
                }
                else if (span[endIndex] - '0' < 0 || span[endIndex] - '0' > 9)
                {
                    break;
                }
            }
            if (foundEndIndex == 0) continue;

            var n1 = int.Parse(span[(i + prefixLen)..foundCommaIndex]); 
            var n2 = int.Parse(span[(foundCommaIndex + 1)..foundEndIndex]);
            pairs.Add((n1, n2));
        }
        return pairs;
    }
}
