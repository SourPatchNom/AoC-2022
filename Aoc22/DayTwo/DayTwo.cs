namespace Aoc22.DayTwo;

public static class DayTwo
{
    public static int DayTwoPartOne(string input)
    {
        int score = 0;
        
        var reader = new StringReader(input);
        var roundPoints = 0;
        while (reader.ReadLine() is { } lineText)
        {
            if (lineText != "")
            {
                var sides = lineText.Split(" ");
                switch (sides[0])
                {
                    case "A"://Rock
                        switch (sides[1])
                        {
                            case "X": //Rock
                                roundPoints += 1 + 3;
                                break;
                            case "Y"://Paper
                                roundPoints += 2 + 6;
                                break;
                            case "Z"://Scissor
                                roundPoints += 3 + 0;
                                break;
                        }
                        break;
                    case "B"://Paper
                        switch (sides[1])
                        {
                            case "X": //Rock
                                roundPoints += 1 + 0;
                                break;
                            case "Y"://Paper
                                roundPoints += 2 + 3;
                                break;
                            case "Z"://Scissor
                                roundPoints += 3 + 6;
                                break;
                        }
                        break;
                    case "C"://Scissor
                        switch (sides[1])
                        {
                            case "X": //Rock
                                roundPoints += 1 + 6;
                                break;
                            case "Y"://Paper
                                roundPoints += 2 + 0;
                                break;
                            case "Z"://Scissor
                                roundPoints += 3 + 3;
                                break;
                        }
                        break;
                }
            }
            score += roundPoints;
            roundPoints = 0;
        }
        return score;
    }
    
    public static int DayTwoPartTwo(string input)
    {
        int score = 0;
        int rock = 1;
        int paper = 2;
        int scissor = 3;
        int lose = 0;
        int draw = 3;
        int win = 6;
        var reader = new StringReader(input);
        var roundPoints = 0;
        while (reader.ReadLine() is { } lineText)
        {
            if (lineText != "")
            {
                var sides = lineText.Split(" ");
                switch (sides[0])
                {
                    case "A"://Rock
                        switch (sides[1])
                        {
                            case "X": //Lose (Scissor)
                                roundPoints += scissor + lose;
                                break;
                            case "Y"://Draw (Rock)
                                roundPoints += rock + draw;
                                break;
                            case "Z"://Win (Paper)
                                roundPoints += paper + win;
                                break;
                        }
                        break;
                    case "B"://Paper
                        switch (sides[1])
                        {
                            case "X": //Lose
                                roundPoints += rock + lose;
                                break;
                            case "Y"://Draw
                                roundPoints += paper + draw;
                                break;
                            case "Z"://Win
                                roundPoints += scissor + win;
                                break;
                        }
                        break;
                    case "C"://Scissor
                        switch (sides[1])
                        {
                            case "X": //Lose
                                roundPoints += paper + lose;
                                break;
                            case "Y"://Draw 
                                roundPoints += scissor + draw;
                                break;
                            case "Z"://Win 
                                roundPoints += rock + win;
                                break;
                        }
                        break;
                }
            }
            score += roundPoints;
            roundPoints = 0;
        }
        return score;
    }
}