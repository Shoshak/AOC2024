﻿bool IsSafe(List<int> report)
{
    var increasing = false;
    var decreasing = false;
    for (var i = 0; i < report.Count; i++)
    {
        var j = i + 1;
        if (j >= report.Count)
        {
            break;
        }

        if (report[i] == report[j])
        {
            return false;
        }
        if (report[i] > report[j])
        {
            decreasing = true;
        }
        if (report[i] < report[j])
        {
            increasing = true;
        }
        if (increasing && decreasing)
        {
            return false;
        }

        var diff = Math.Abs(report[i] - report[j]);
        if (diff is < 1 or > 3)
        {
            return false;
        }
    }

    return true;
}

var reports = File
    .ReadLines(args[0])
    .Select(r => r
        .Split(" ")
        .Select(int.Parse)
        .ToList())
    .ToList();

var safeReports = reports
    .Where(IsSafe)
    .ToList();
    
foreach (var safeReport in safeReports)
{
    foreach (var i in safeReport)
    {
        Console.Write($"{i} ");
    }
    Console.WriteLine();
}

Console.WriteLine($"{safeReports.Count} reports are safe");