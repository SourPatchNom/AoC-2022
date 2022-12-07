namespace Aoc22.Day5;

/// <summary>
/// JDTMRWCQJ
/// VHJDDCWRD
/// </summary>
public class DayFive
{
    /// <summary>
    /// Gets the nine stacks with all the crates in them.
    /// </summary>
    /// <returns></returns>
    private List<Stack<string>> GetCrates()
    {
        var cargoDeck = new List<Stack<string>>();
        for (var i = 0; i < 10; i++) cargoDeck.Add(new Stack<string>());
        
        var reader = new StringReader(DayFiveInput.InputA);
        while (reader.ReadLine() is { } lineText)
        {
            if (lineText == "") continue;
            for (int i = 0; i < 9; i++)
            {
                var crate = lineText.Substring(i*4+1, 1);
                if (ShouldSaveCrate(crate)) cargoDeck[i].Push(crate);
            }
        }

        List<string> reverseList = new List<string>();
        for (int i = 0; i < 9; i++)
        {
            while (cargoDeck[i].Count != 0)
            {
                reverseList.Add(cargoDeck[i].Pop());
            }

            foreach (var item in reverseList)
            {
                cargoDeck[i].Push(item);
            }
            
            reverseList.Clear();
        }
        
        
        return cargoDeck;
    }

    private bool ShouldSaveCrate(string input)
    {
        foreach (var i1 in Enumerable.Range(0,10))
        {
            if (input == " ") return false;
            if (input.Equals(i1.ToString())) return false;
        }

        return true;
    }
    
    private List<List<int>> GetActions()
    {
        var list = new List<List<int>>();
        var reader = new StringReader(DayFiveInput.InputB);
        while (reader.ReadLine() is { } lineText)
        {
            List<int> action = new List<int>();
            var split = lineText.Split(" ");
            action.Add(int.Parse(split[1]));
            action.Add(int.Parse(split[3]));
            action.Add(int.Parse(split[5]));
            list.Add(action);
        }

        return list;
    }
    
    public string GetPartOne()
    {
        string result = "";
        var crates = GetCrates();
        var actions = GetActions();
        foreach (var action in actions)
        {
            for (var i = 0; i < action[0]; i++)
            {
                var pop = crates[action[1]-1].Pop();
                crates[action[2]-1].Push(pop);
            }
        }

        List<string> tops = new List<string>();
        foreach (var crate in crates)
        {
            if (crate.Any()) tops.Add(crate.Peek());
        }

        tops.ForEach(x => result += x);
        return result;
    }

    public string GetPartTwo()
    {
        string result = "";
        var crates = GetCrates();
        var actions = GetActions();
        foreach (var action in actions)
        {
            var stackPick = new Stack<string>();
            for (var i = 0; i < action[0]; i++)
            {
                stackPick.Push(crates[action[1]-1].Pop());
            }

            foreach (var crate in stackPick)
            {
                crates[action[2]-1].Push(crate);
            }
            
        }

        List<string> tops = new List<string>();
        foreach (var crate in crates)
        {
            if (crate.Any()) tops.Add(crate.Peek());
        }

        tops.ForEach(x => result += x);
        return result;
    }
}