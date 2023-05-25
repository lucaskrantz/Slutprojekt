using System;
using System.Numerics;
using Raylib_cs;


public class Missile
{
    public Vector2 position = new Vector2(200, 200);
    public float speed = 10;

    public void DoAll()
    {
        Update();
        Draw();
    }
    public void Update()
    {
        // Uträkning för missilen och musens position, samt hur missilen
        // ska flytta sig mot musen
        Vector2 mousePos = Raylib.GetMousePosition();

        Vector2 diff = mousePos - position;

        // Normalize gör att diff är 1.
        diff = Vector2.Normalize(diff) * speed;

        position += diff;

    }
    // Metod som ritam missilen
    public void Draw()
    {
        Raylib.DrawCircleV(position, 10, Color.RED);
    }

}
