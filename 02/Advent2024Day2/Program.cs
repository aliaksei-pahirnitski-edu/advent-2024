﻿// See https://aka.ms/new-console-template for more information
using System.Collections.Generic;
using System.Diagnostics;

Console.WriteLine("Advent Day 02!");

var input = ReadInput();

var sw = Stopwatch.StartNew();
var result = CountSafe(input);
sw.Stop();
Console.WriteLine($"Took [{sw.Elapsed}]");
// with recursion: ~ 20 mcrSec // 00:00:00.0193139
// with agg: ~ 26 mcrSec // 00:00:00.0264172

Console.WriteLine(result);


int CountSafe(IEnumerable<List<int>> input) => input.Count(IsSafe);

bool IsSafe(List<int> line) => line switch
{
    [int first, int second] => Math.Abs(first - second) <= 3,
    [int first, int second, .. var rest] when IsDecreasingCheck(first, second) => IsDecreasingSafe(second, rest),
    [int first, int second, .. var rest] when IsIncreasingCheck(first, second) => IsIncreasingSafe(second, rest),
    _ => false
};

bool IsIncreasingCheck(int prev, int next) => next > prev && next - prev <= 3;
bool IsDecreasingCheck(int prev, int next) => prev > next && prev - next <= 3;

bool IsSafeRest(int start, List<int> rest, Func<int, int, bool> tendencyCheck) => 
    rest.Aggregate(new PrevNumber(start, true), 
        (acc, next) => acc.IsSafe && tendencyCheck(acc.Prev, next) ? new PrevNumber(next, true) : new PrevNumber(0, false), 
        (acc) => acc.IsSafe);

// this OK
bool IsIncreasingSafe(int start, List<int> rest) => IsSafeRest(start, rest, IsIncreasingCheck);
bool IsDecreasingSafe(int start, List<int> rest) => IsSafeRest(start, rest, IsDecreasingCheck);

// also worked
// bool IsIncreasingSafe(int start, List<int> rest) => WithRecursion(start, rest, IsIncreasingCheck);
// bool IsDecreasingSafe(int start, List<int> rest) => WithRecursion(start, rest, IsDecreasingCheck);

bool WithRecursion(int start, List<int> rest, Func<int, int, bool> tendencyCheck)
    => rest switch
    {
    [] => true,
    [int last] => tendencyCheck(start, last),
    [int next, .. var nextRest] => tendencyCheck(start, next) && WithRecursion(next, nextRest, tendencyCheck),
    _ => false
    };

/*bool IsDecreasingSafe(int start, List<int> rest)
    => rest switch
    {
    [] => true,
    [int last] => start > last && start - last < 3,
    [int ]
    };
*/

IEnumerable<List<int>> ReadInput()
{
    using var stream = new StreamReader("input.txt");
    string? line = null;
    do
    {
        line = stream.ReadLine();
        if (line is not null)
        {
            var split = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            yield return split.Select(int.Parse).ToList();
        }
    }
    while (!string.IsNullOrWhiteSpace(line));
}

public readonly record struct PrevNumber(int Prev, bool IsSafe);