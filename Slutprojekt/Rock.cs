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


    public void DoAll(List<Rock> rocks, Game game, Missile m1)
    {
        Update(game.currentDifficulty);
        Draw();
        RemoveRocks(rocks, m1, game);
    }

    public static void RemoveRocks(List<Rock> rocks, Missile m1, Game game)
    {
        // Kollar ifall värdet från funktionen rocks.RemoveAll returnarer siffran 1
        //  Det kommer alltid bara vara en sten som nuddar
        // botten vid en viss tidpunkt, därav kan vi använda == 1.
        //
        if (rocks.RemoveAll(r => r.rect.y >= 750) == 1)
        {
            // Tar bort ett liv
            game.life--;

        }
        // Kollar ifall värdet som returneras från funktionen rocks.RemoveAll inte
        // är lika med 0. Detta innebär att vid en kollision skulle värdet vara 1, eller 
        // möjligen 2 ifall m1 krockar med 2 rocks samtidigt.
        if (rocks.RemoveAll(r => CheckCollision(m1, r)) != 0)
        {
            //Lägger till 1 score
            game.score++;
        }
    }
    public static bool CheckCollision(Missile missile, Rock rock)
    {
        if (Raylib.CheckCollisionCircleRec(missile.position, 10, rock.rect))
        {
            return true;
        }
        else
        {
            return false;
        }

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