namespace Advent2024Day3;

internal static class SolutionDay3Part2
{
    public static int SolveDay2(string puzzleInput)
    {        
        return FindPairs0(puzzleInput).Sum(p => p.a * p.b);
    }

    public static IEnumerable<(int a, int b)> FindPairs0(string puzzleInput)
    {
        // example: "mul(1,2)mul(3,4)";
        IList<(int a, int b)> pairs = [];

        bool enabled = true;
        const string doCommand = "do()";
        var doSpan = doCommand.AsSpan();
        const string dontCommand = "don't()";
        var dontSpan = dontCommand.AsSpan();

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
            // check enable
            var foundDont = true;
            for (int j = 0; j < dontSpan.Length; j++)
            {
                foundDont = foundDont && span[i + j] == dontSpan[j];
            }
            if (foundDont) enabled = false;

            var foundDo = true;
            for (int j = 0; j < doSpan.Length; j++)
            {
                foundDo = foundDo && span[i + j] == doSpan[j];
            }
            if (foundDo) enabled = true;

            if (!enabled) continue;

            // check mul
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
