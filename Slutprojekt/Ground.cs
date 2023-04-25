using System;
using Raylib_cs;
using System.Numerics;

public class Ground
{


    float BuildingHeight = 100;
    public Ground()
    {
        rect1.height = BuildingHeight;

        
    }



    public Rectangle rect1 = new Rectangle(0, 700, 200, 0);
    // public Rectangle rect2 = new Rectangle(500, 700, 200, 0);
    // public Rectangle rect3 = new Rectangle(1000, 700, 200, 0);



    public void Draw()
    {
        Raylib.DrawRectangleRec(rect1, Color.BLUE);
        // Raylib.DrawRectangleRec(rect2, Color.BLUE);
        // Raylib.DrawRectangleRec(rect3, Color.BLUE);


    }

    public void Update()
    {
        rect1.x += 500;
    }

}

