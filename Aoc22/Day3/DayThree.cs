namespace Aoc22.Day3;

public class DayThree
{
    public int GetPartOne(string input)
    {
        var reader = new StringReader(input);
        var lineCount = 0;
        var sum = 0;
        while (reader.ReadLine() is { } lineText)
        {
            if (lineText == "") continue;
            lineCount++;
            var count = lineText.Length;
            var left = lineText.Substring(0, count/2);
            var right = lineText.Substring(count/2, count/2);
            var duplicate = lineText.First(x => left.Contains(x) && right.Contains(x));
            var score = GetScore(duplicate);
            //Console.WriteLine("Line" + lineCount +" Letter"+ duplicate +" Score:"+score);
            sum += score;
        }
        return sum;
    }

    public int GetPartTwo(string input)
    {
        var reader = new StringReader(input);
        var groupCount = 0;
        var sum = 0;
        List<List<char[]>> groups = new List<List<char[]>>();
        List<char[]> package = new List<char[]>();
        while (reader.ReadLine() is { } lineText)
        {
            if (lineText == "") continue;
            package.Add(lineText.ToCharArray());
            if (package.Count != 3) continue;
            groups.Add(package);
            package = new List<char[]>();
        }

        foreach (var list in groups)
        {
            groupCount++;
            var duplicate = list[0].First(x => list[1].Contains(x) && list[2].Contains(x));
            var score = GetScore(duplicate);
            //Console.WriteLine("Group " + groupCount +" Badge Letter "+ duplicate +" Score:"+score);
            sum += score;
        }
        return sum;
    }

    public int GetScore(char value)
    {
        var values = ("abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ").ToList();//.ToCharArray().ToList();
        return values.IndexOf(value) + 1;
    }
}