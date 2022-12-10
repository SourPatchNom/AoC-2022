namespace Aoc22.Day8;

public class DayEight
{
    public int GetPartOne(string input)
    {
        int total = 0;

        List<List<int>> horizontal = new();
        List<List<int>> vertical = new();
        for (int i = 0; i < 99; i++)
        {
            horizontal.Add(new List<int>());
            vertical.Add(new List<int>());
        }
        var reader = new StringReader(input);
        var lineCountHorizontal = 0;
        var lineCountVertical = 0;
        while (reader.ReadLine() is { } lineText)
        {
            lineCountVertical = 0;
            foreach (var character in lineText.ToCharArray())
            {
                var value = int.Parse(character.ToString());
                horizontal[lineCountHorizontal].Add(value);
                vertical[lineCountVertical].Add(value);
                lineCountVertical++;
            }
            lineCountHorizontal++;
        }

        List<List<bool>> horizontalResult = new();
        List<List<bool>> verticalResult = new();
        
        for (int i = 0; i < 99; i++)
        {
            horizontalResult.Add(ToLessThanRest(horizontal[i]));
            verticalResult.Add(ToLessThanRest(vertical[i]));
        }

        //horizontal
        for (int i = 0; i < 99; i++)
        {
            //Vertical
            for (int j = 0; j < 99; j++)
            {
                if (horizontalResult[i][j] && verticalResult[j][i])
                {
                    total++;
                }
            }
        }
        
        Console.WriteLine(lineCountHorizontal+"|"+lineCountVertical);
        return 99*99-total;
    }

    private List<bool> ToLessThanRest(List<int> list)
    {
        List<bool> result = new List<bool>();
        for (int i = 0; i < 99; i++)
        {
            if (i == 0 || i == 98)
            {
                result.Add(false);
                continue;
            }

            bool lessThanLeft = false;
            bool lessThanRight = false;

            //Left
            for (int j = 0; j < i; j++)
            {
                if (list[j] >= list[i])
                {
                    lessThanLeft = true;
                }
            }
            
            //right
            for (int j = i+1; j < 99; j++)
            {
                if (list[j] >= list[i])
                {
                    lessThanRight = true;
                }
            }
            result.Add(lessThanLeft && lessThanRight);
        }
        return result;
    }
    
    
    public int GetPartTwo(string input)
    {

        List<List<int>> horizontal = new();
        List<List<int>> vertical = new();
        for (int i = 0; i < 99; i++)
        {
            horizontal.Add(new List<int>());
            vertical.Add(new List<int>());
        }
        var reader = new StringReader(input);
        var lineCountHorizontal = 0;
        var lineCountVertical = 0;
        while (reader.ReadLine() is { } lineText)
        {
            lineCountVertical = 0;
            foreach (var character in lineText.ToCharArray())
            {
                var value = int.Parse(character.ToString());
                horizontal[lineCountHorizontal].Add(value);
                vertical[lineCountVertical].Add(value);
                lineCountVertical++;
            }
            lineCountHorizontal++;
        }

        List<List<int>> horizontalResult = new();
        List<List<int>> verticalResult = new();
        
        for (int i = 0; i < 99; i++)
        {
            horizontalResult.Add(ToScenicScore(horizontal[i]));
            verticalResult.Add(ToScenicScore(vertical[i]));
        }

        int greatest = 0;
        
        //horizontal
        for (int i = 0; i < 99; i++)
        {
            //Vertical
            for (int j = 0; j < 99; j++)
            {
                var score = horizontalResult[i][j] * verticalResult[j][i];
                if (score > greatest)
                {
                    greatest = score;
                }
            }
        }
        
        return greatest;
    }

    private List<int> ToScenicScore(List<int> list)
    {
        List<int> result = new List<int>();
        for (int i = 0; i < 99; i++)
        {
            int resultLeft = 0;
            int resultRight = 0;

            if (i != 0)
            {
                //Left
                for (int j = i-1; j >= 0; j--)
                {
                    if (list[j] >= list[i])
                    {
                        resultLeft++;
                        break;
                    }
                    resultLeft++;
                }    
            }

            if (i != 98)
            {
                //right
                for (int j = i+1; j < 99; j++)
                {
                    if (list[j] >= list[i])
                    {
                        resultRight++;
                        break;
                    }
                    resultRight++;
                }            
            }

            result.Add(resultLeft * resultRight);
        }
        return result;
    }
}