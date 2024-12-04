List<int> first = [];
List<int> second = [];

foreach (var line in File.ReadLines(args[0]))
{
    var splitLine = line.Split("   ");
    first.Add(int.Parse(splitLine[0])); 
    second.Add(int.Parse(splitLine[1]));
}

var frequencies = second
    .GroupBy(i => i)
    .ToDictionary(i => i.Key, i => i.Count());

var similarities = first.Select(i => i * frequencies.GetValueOrDefault(i, 0)).ToList();
Console.WriteLine(similarities.Sum());