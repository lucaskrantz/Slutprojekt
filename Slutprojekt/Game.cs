using System;
using Raylib_cs;

public class Game
{
    // Svårighetsgrader
    // Enum skapar egna datatyper. Enda godkännda värdena är Easy, Medium, eller Hard.
    public enum Difficulty
    {
        Easy,
        Medium,
        Hard
    }

    // Instanserar svårighetsgraden som spelet börjar på till Easy.
    public Difficulty currentDifficulty = Difficulty.Easy;

    public int score = 0;

    // antal liv
    public int life = 3;

    // Generisk metod för att räkna ut speltider i ett Raylib spel.
    public int TimeSinceStart()
    {
        double gameTime = Raylib.GetTime();
        int gameSecs = (int)gameTime;
        return gameSecs;
    }
}
