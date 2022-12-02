namespace Aoc22.DayOne;

public class DayOne
{
    /// <summary>
    /// Processes the Advent of Code 2022 day one input string and returns the highest calorie sum.
    /// </summary>
    /// <param name="input">String from a text file with lines containing calorie totals for food carried by an elf. Each line represents a unique food item held by an elf. Many elves are represented and elves are seperated by empty line.</param>
    /// <returns>The highest total calories carried by an elf.</returns>
    public int GetDayOnePartOne(string input)
    {
        var max = 0;
        var reader = new StringReader(input);
        var sum = 0;
        while (reader.ReadLine() is { } lineText)
        {
            if (lineText != "")
            {
                if (int.TryParse(lineText, out var result))
                {
                    sum += result;
                    continue;
                }                
            }
            if (sum > max)
            {
                max = sum;
            }
            sum = 0;
        }
        return max;
    }
    
    /// <summary>
    /// Processes the Advent of Code 2022 day one input string and returns the highest calorie sum.
    /// </summary>
    /// <param name="input">String from a text file with lines containing calorie totals for food carried by an elf. Each line represents a unique food item held by an elf. Many elves are represented and elves are seperated by empty line.</param>
    /// <returns>The highest total calories carried by an elf.</returns>
    public int GetDayOnePartTwo(string input)
    {
        var totals = new List<int>();
        var reader = new StringReader(input);
        var sum = 0;
        while (reader.ReadLine() is { } lineText)
        {
            if (lineText != "")
            {
                if (int.TryParse(lineText, out var result))
                {
                    sum += result;
                    continue;
                }                
            }
            totals.Add(sum);
            sum = 0;
        }
        var sorted = totals.OrderByDescending(x => x).ToList();
        return (sorted[0] + sorted[1] + sorted[2]);
    }
}