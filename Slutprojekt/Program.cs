using Raylib_cs;
using System.Numerics;



//SKAPA KANONERNA
//SKAPA MISSILER 
//FÅ MISSILERNA ATT SKJUTAS MOT MUSPEKAREN
//MISSILERNA SKA SPRÄNGAS EFTER ETT VISST AVSTÅND
//SKAPA BOMBERNA
//FÅ BOMBERNA ATT RITAS SLUMPMÄSSIGT OCH SEDAN FALLA MOT MARKEN
//MISSILERNA SKA SPRÄNGAS VID KONTAKT AV EN BOMB, SAMT SKA BOMBEN FÖRSVINNA
//SKAPA POÄNG, FÅ POÄNG FÖR VARJE BOMB MAN SPRÄNGER
//SKAPA HUSEN 
//IFALL BOMBERNA KOMMER I KONTAKT MED HUSEN SPRÄNGS DOM
//MINDRE POÄNG FÖR VARJE HUS SPRÄNGT
//SKAPA KLASSER FÖR KANONER, MISSILER, BOMBER, HUS
//ANVÄNDA LISTOR FÖR KANONER, MISSILER, BOMBER, HUS.
//METOD FÖR ATT SE IFALL MISSIL KOMMER I KONTAKT MED BOMB
//METOD FÖR ATT SE IFALL BOMB KOMMER I KONTAKT MED HUS



Raylib.InitWindow(1200, 800, "Missile Command");

Raylib.SetTargetFPS(60);



int cannonWidth = 50;
int cannonHeight = 50;

int Score = 0;

int Life = 3;

// List<Rock> rocks = new List<Rock>();

List<Ground> buildings = new List<Ground>();





Missile m1 = new Missile();

Rock r1 = new Rock();


// Rectangle cannon = new Rectangle(10, 700, cannonWidth, cannonHeight);
// Rectangle missile = new Rectangle(10, 300, 15, 15);



while (Raylib.WindowShouldClose() == false)
{


    // LOGIK
    // Rectangle rock = new Rectangle(r1.x, r1.y, 50, 50);




    for (var i = 0; i < r1.rocks.Count; i++)
    {
        Rock rock = r1.rocks[i];

        if (Raylib.CheckCollisionCircleRec(m1.position, 10, rock.rect))
        {
            Score++;
            r1.rocks.RemoveAt(i);
        }


        // if (Raylib.CheckCollisionRecs(g1.rect1, rock.rect))
        // {
        //     Life--;
        //     rocks.RemoveAt(i);
        // }
        // if (Raylib.CheckCollisionRecs(g1.rect2, rock.rect))
        // {
        //     Life--;
        //     rocks.RemoveAt(i);
        // }

        // if (Raylib.CheckCollisionRecs(g1.rect3, rock.rect))
        // {
        //     Life--;
        //     rocks.RemoveAt(i);
        // }




    }



    // rocks.Add(new Rock());









    foreach (Rock r in r1.rocks)
    {
        r.Draw();
        r.Update();
    }
    foreach (Ground b in buildings)
    {
        b.Draw();
    }



    //GRAFIK 
    Raylib.BeginDrawing();
    Raylib.ClearBackground(Color.BLACK);
    Raylib.DrawText($"Current Score:{Score}", 50, 50, 20, Color.GREEN);
    Raylib.DrawText($"Current Life:{Life}", 50, 80, 20, Color.GREEN);


    m1.Update();
    r1.CheckTimer();

    m1.Draw();

    // g1.Draw();
    // g2.Draw();
    // g3.Draw();

    Raylib.EndDrawing();

}





