using System;
using System.Numerics;
using Raylib_cs;



public class Rock
{

    public  Rectangle rect = new Rectangle(0, 0, 50, 50);
    public int speed = 3;

    public Random generator = new Random();
 


    public Rock()
    {
        rect.x = generator.Next(1200);
        // Vector2 position = new Vector2(x, y);

    }


    public void Update()
    {
        rect.y += speed;
    }

    public void Draw()
    {
        Raylib.DrawRectangleRec(rect, Color.BLUE);

    }

}
