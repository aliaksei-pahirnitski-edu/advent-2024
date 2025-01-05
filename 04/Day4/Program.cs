// See https://aka.ms/new-console-template for more information
using Day4;

Console.WriteLine("Hello, World!");

var day4 = Solution.FindXmasCount(PuzzleInput.Day4Input); // 2642
Console.WriteLine("Day4 = " + day4);

var arr = Solution.ToArray(PuzzleInput.Day4Input);
var hor = Solution.FindHorizontalCount(arr);
var vert = Solution.FindVerticalCount(arr);
var diag = Solution.FindDiagonalCount(arr);
Console.WriteLine("Hor = " + hor + " vert=" + vert + " diag=" + diag);

var part2 = SolutionPart2.FindXmasCount(PuzzleInput.Day4Input); // 1974
Console.WriteLine("part2 = " + part2);
