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

    bool showStartScreen = true;
    bool showGameoverScreen = false;
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

    public void ChangeDifficulty(int rockCount)
    {
        if (rockCount >= 10 && rockCount < 20)
        {
            currentDifficulty = Difficulty.Medium;
        }
        else if (rockCount >= 20)
        {
            currentDifficulty = Difficulty.Hard;
        }
    }





    public void CheckLife()
    {
        if (life == 0)
        {
            showGameoverScreen = true;
        }
    }

    public void ShowStartScreen()
    {

        // visa startinstruktioner
        Raylib.DrawText("Press LMB to start", 400, 350, 50, Color.GREEN);
        Raylib.DrawText("Use the mouse to control the missile.", 400, 410, 20, Color.GREEN);
        Raylib.DrawText("Your mission is to stop the ateroids from destroying earth", 400, 440, 20, Color.GREEN);
        Raylib.DrawText("Dont let the asteroids touch the ground!", 400, 470, 20, Color.GREEN);

        if (Raylib.IsMouseButtonReleased(MouseButton.MOUSE_BUTTON_LEFT))
        {
            showStartScreen = false;
        }

    }

    public void ShowGameoverScreen()
    {
        if (showGameoverScreen)
        {
            Raylib.ClearBackground(Color.RED);
            Raylib.DrawText("GAME OVER", 600, 400, 50, Color.GREEN);

        }
    }

    public bool DecideScreen()
    {
        if (showStartScreen)
        {
            ShowStartScreen();
            return true;
        }
        if (showGameoverScreen)
        {
            ShowGameoverScreen();
            return true;
        }

        else
        {
            return false;
        }

    }
    public void DrawHUD(int rockCount)
    {
        Raylib.ClearBackground(Color.BLACK);
        Raylib.DrawText($"Current Score:{score}", 50, 50, 20, Color.GREEN);
        Raylib.DrawText($"Current Life:{life}", 50, 80, 20, Color.GREEN);
        Raylib.DrawText($"Current Difficulty:{currentDifficulty}", 50, 110, 20, Color.GREEN);
        Raylib.DrawText($"Rock count:{rockCount}", 50, 140, 20, Color.GREEN);
        Raylib.DrawText($"Time elapsed:{TimeSinceStart()}", 50, 170, 20, Color.GREEN);
    }

    public void Update(int rockCount)
    {
        CheckLife();
        ChangeDifficulty(rockCount);
    }
}
