namespace Aoc22.Day7;

public class DaySeven
{
    
    
    public long GetPartOne(string input)
    {
        var result = GetDirectoryTotals(input);
        return result.Values.Where(x => x < 100000).Sum();
    }

    public long GetPartTwo(string input)
    {
        var maxSpace = 70000000;
        var minSpaceNeeded = 30000000;
        var result = GetDirectoryTotals(input);
        var neededSpace = minSpaceNeeded - (maxSpace - result.Values.Max());
        return result.Values.Where(x => x > neededSpace).ToList().Min();
    }
    
    public static Dictionary<string, long> GetDirectoryTotals(string input)
    {
        Dictionary<string, long> lines = new Dictionary<string, long>();
        Stack<string> directory = new Stack<string>();
        long currentDirectoryTotal = 0;
        var reader = new StringReader(input);
        while (reader.ReadLine() is { } lineText)
        {
            switch (lineText)
            {
                case {} x when x == "$ cd ..":
                    directory.Pop();
                    lines[String.Join("/", directory.Reverse())] = lines[String.Join("/", directory.Reverse())] + currentDirectoryTotal;
                    currentDirectoryTotal = lines[String.Join("/", directory.Reverse())];
                    break;
                case {} x when x == "$ cd /":
                    directory.Push("root");
                    lines.Add("root",0);
                    currentDirectoryTotal = 0;
                    break;
                case {} x when x.StartsWith("$ cd "):
                    directory.Push(x.Split(" ")[2]);
                    lines.Add(String.Join("/", directory.Reverse()),0);
                    currentDirectoryTotal = 0;
                    break;
                case {} x when !x.StartsWith("dir ") && !x.StartsWith("$ ls"):
                    currentDirectoryTotal += int.Parse(x.Split(" ")[0]);
                    lines[String.Join("/", directory.Reverse())] = currentDirectoryTotal;
                    break;
            }
        }

        while (directory.Count > 0)
        {
            
            var oldDirTotal = lines[String.Join("/", directory.Reverse())];
            directory.Pop();
            if (directory.Count == 0) return lines;
            lines[String.Join("/", directory.Reverse())] = lines[String.Join("/", directory.Reverse())] + oldDirTotal;
        }
        
        return lines;
    }
}

