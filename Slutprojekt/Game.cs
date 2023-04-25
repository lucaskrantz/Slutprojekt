using System;

public class Game
{
    // Svårighetsgrader
    public enum Difficulty
    {
        Easy,
        Medium,
        Hard
    }

    public Difficulty currentDifficulty = Difficulty.Easy;

    public int score = 0;

    // antal liv
    public int life = 3;
}
