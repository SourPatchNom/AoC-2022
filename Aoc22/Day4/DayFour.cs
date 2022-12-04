namespace Aoc22.Day4;

public class DayFour
{
    private List<Tuple<HashSet<int>, HashSet<int>>> ConvertList(string input)
    {
        var set = new List<Tuple<HashSet<int>, HashSet<int>>>();
        
        var reader = new StringReader(input);
        while (reader.ReadLine() is { } lineText)
        {
            if (lineText == "") continue;
            var halved = lineText.Split(",");
            var left = halved[0].Split("-");
            var right = halved[1].Split("-");
            var leftRange = new HashSet<int>();
            var rightRange = new HashSet<int>();
            for (int i = int.Parse(left[0]); i <= int.Parse(left[1]); i++)
            {
                leftRange.Add(i);
            }
            for (int i = int.Parse(right[0]); i <= int.Parse(right[1]); i++)
            {
                rightRange.Add(i);
            }
            set.Add(new Tuple<HashSet<int>, HashSet<int>>(leftRange,rightRange));
        }
        
        
        return set;
    }

    public int GetPartOne(string input)
    {
        var result = ConvertList(input);
        var count = 0;
        foreach (var pair in result)
        {
            if (pair.Item1.Contains(pair.Item2.First()) && pair.Item1.Contains(pair.Item2.Last()))
            {
                count++;
                continue;
            }
            if (pair.Item2.Contains(pair.Item1.First()) && pair.Item2.Contains(pair.Item1.Last())) count++;
        }
        return count;
    }

    public int GetPartTwo(string input)
    {
        var result = ConvertList(input);
        return result.Count(pair => pair.Item1.Intersect(pair.Item2).Any());
    }
}