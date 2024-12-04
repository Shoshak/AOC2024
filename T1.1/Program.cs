int GetDistanceSum(List<int> first, List<int> second)
{
    var firstSorted = first.OrderBy(i => i).ToList();
    var secondSorted = second.OrderBy(i => i).ToList();

    List<int> distances = [];

    for (var i = 0; i < first.Count; i++)
    {
        var distance = Math.Abs(firstSorted[i] - secondSorted[i]);
        distances.Add(distance);
    }

    return distances.Sum();
}

List<int> first = [];
List<int> second = [];

foreach (var line in File.ReadLines(args[0]))
{
    var splitLine = line.Split("   ");
    first.Add(int.Parse(splitLine[0])); 
    second.Add(int.Parse(splitLine[1]));
}

Console.WriteLine(GetDistanceSum(first, second));
