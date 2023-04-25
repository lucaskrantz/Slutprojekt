using System;
using System.Numerics;
using Raylib_cs;



public class Rock
{

    public Rectangle rect = new Rectangle(0, 0, 50, 50);
    public int speed = 3;
    public List<Rock> rocks = new List<Rock>();
    public Random generator = new Random();

    float rockTimer = 3f; // timer in seconds
    float rockTimerMax = 3f; // time interval between rocks
    int count = 0;

    public Rock()
    {
        rect.x = generator.Next(50, 1150);

    }



    public void CheckTimer()
    {
        rockTimer -= Raylib.GetFrameTime();
        if (rockTimer <= 0)
        {
            rocks.Add(new Rock());
            rockTimer = rockTimerMax;
            count++;
        }



    }

    public void CheckCount()
    {
        if (count % 10 == 1)
        {
            rockTimerMax = 2f;
            count = 0;
        }

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
