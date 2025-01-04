// See https://aka.ms/new-console-template for more information
using Advent2024Day3;

Console.WriteLine("Hello, World!");


var pairs = SolutionDay3Part1.FindPairs3(PuzzleInput.TestInput_161);
foreach (var pair in pairs)
{
    Console.WriteLine(pair);
}


// var result = SolutionDay3Part1.Solve(PuzzleInput.TestInput_7);
var result = SolutionDay3Part1.Solve(PuzzleInput.Instructions); // 162813399

Console.WriteLine("Mull result = " + result); // 162813399
