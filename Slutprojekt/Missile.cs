using System;
using System.Numerics;
using Raylib_cs;







public class Missile
{
    public Vector2 position = new Vector2(200, 200);
    public float speed = 5;

    public void Update()
    {

        Vector2 mousePos = Raylib.GetMousePosition();       

        Vector2 diff = mousePos - position;

        diff = Vector2.Normalize(diff) * speed;

        position += diff;

    }

    public void Draw()
    {
        Raylib.DrawCircleV(position, 10, Color.RED);
    }


    // public void FlyToMousePos()
    // {

    //     Vector2 MissileVector =
    //     while (Missile.x <  )
    //     {

    //     }

    // }
}
