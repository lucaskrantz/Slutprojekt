using System;
using System.Numerics;
using Raylib_cs;

public class Rock
{
    public Rectangle rect = new Rectangle(0, 0, 50, 50);

    public Random generator = new Random();

    public Rock()
    {
        rect.x = generator.Next(50, 1150);
    }


    // Uppdatera positionen för stenen
    // Justerar hastigheten av hur stenen ska förflytta sig, beroende på difficulty.
    public void Update(Game.Difficulty difficulty)
    {
        if (difficulty == Game.Difficulty.Medium)
        {
            rect.y += 6;
        }
        else if (difficulty == Game.Difficulty.Hard)
        {
            rect.y += 20;
        }
        else
        {
            rect.y += 3;
        }
    }


    public void Draw()
    {
        Raylib.DrawRectangleRec(rect, Color.BLUE);
    }

}