// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

//int[] list1 = [3, 4, 2, 1, 3, 3];
//int[] list2 = [4, 3, 5, 3, 9, 3];
// var input = ReadInput();
var (list1, list2) = ReadInput();

var result = GetTotalDistance(list1, list2);

Console.WriteLine(result);   // 2580760

int GetTotalDistance(IReadOnlyList<int> first, IReadOnlyList<int> second) =>
    first.OrderBy(x => x).Zip(second.OrderBy(x => x))
    .Select(x => Math.Abs(x.First - x.Second))
    .Sum();

(List<int> first, List<int> second) ReadInput()
{
    var first = new List<int>();
    var second = new List<int>();
    using (var reader = new StreamReader("input.txt"))
    {
        var line = reader.ReadLine();
        while (!string.IsNullOrWhiteSpace(line))
        {
            var split = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            first.Add(int.Parse(split[0]));
            second.Add(int.Parse(split[1]));
            line = reader.ReadLine();
        }
    }
    return (first, second);
}