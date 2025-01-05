// See https://aka.ms/new-console-template for more information
using Advent2024Day3;
using System.Diagnostics;

Console.WriteLine("Hello, World!");

//warmup

SolutionDay3Part1.Solve0(PuzzleInput.Instructions);
SolutionDay3Part1.Solve0(PuzzleInput.Instructions);
SolutionDay3Part1.Solve(PuzzleInput.Instructions);

SolutionDay3Part1.Solve0(PuzzleInput.Instructions);
SolutionDay3Part1.Solve0(PuzzleInput.Instructions);
SolutionDay3Part1.Solve(PuzzleInput.Instructions);

/*
var pairs = SolutionDay3Part1.FindPairs3(PuzzleInput.TestInput_161);
foreach (var pair in pairs)
{
    Console.WriteLine(pair);
}
*/
var sw0 = Stopwatch.StartNew();
var result0 = SolutionDay3Part1.Solve0(PuzzleInput.Instructions);
sw0.Stop();
Console.WriteLine("Mull result = " + result0); // 162813399
Console.WriteLine("Mull result took " + sw0.ElapsedMilliseconds + "ms = " + sw0.Elapsed);

var sw1 = Stopwatch.StartNew();
var result = SolutionDay3Part1.Solve(PuzzleInput.Instructions); // 162813399
sw1.Stop();

Console.WriteLine("Mull result = " + result); // 162813399
Console.WriteLine("Mull result took " + sw1.ElapsedMilliseconds + "ms = " + sw1.Elapsed);

/////////// day 2
var day2 = SolutionDay3Part2.SolveDay2(PuzzleInput.Instructions);
Console.WriteLine("Day2 result = " + day2); // 53783319