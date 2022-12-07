namespace Aoc22.Day6;

public class DaySix
{

    public int GetMarker(string input, int length)
    {
        var streamKey = new Queue<char>();
        var count = 0;
        foreach (var character in input.ToCharArray())
        {
            count++;
            while (streamKey.Contains(character)) streamKey.Dequeue();
            streamKey.Enqueue(character);
            if (streamKey.Count == length) return count;;
        }
        return -1;
    }

    //1287
    public int GetPartOne(string input)
    {
        var streamArray = input.ToCharArray();
        var streamKey = new Queue<char>();
        var charCount = 0;
        foreach (var character in streamArray)
        {
            charCount++;
            while (streamKey.Contains(character)) streamKey.Dequeue();
            streamKey.Enqueue(character);
            if (streamKey.Count == 4) return charCount;;
        }
        return -1;
    }
    
    //3716
    public int GetPartTwo(string input)
    {
        var streamArray = input.ToCharArray();
        var streamKey = new Queue<char>();
        var charCount = 0;
        foreach (var character in streamArray)
        {
            charCount++;
            while (streamKey.Contains(character)) streamKey.Dequeue();
            streamKey.Enqueue(character);
            if (streamKey.Count == 14) return charCount;
        }

        return -1;
    }
}