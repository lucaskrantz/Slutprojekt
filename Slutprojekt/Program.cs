using Raylib_cs;

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

// Håll koll på stenarna
List<Rock> rocks = new List<Rock>();
int rockCount = 0;

Game game = new Game();

// Missilen som användaren kontrollerar
Missile m1 = new Missile();

float rockTimer = 3f;
float rockTimerMax = 3f;

bool showStartScreen = true;
bool showGameoverScreen = false;

while (Raylib.WindowShouldClose() == false)
{
    if (showStartScreen)
    {
        // visa startinstruktioner
        Raylib.DrawText("Press LMB to start", 600, 400, 50, Color.GREEN);
        if (Raylib.IsMouseButtonReleased(MouseButton.MOUSE_BUTTON_LEFT))
        {
            showStartScreen = false;
        }

    }
    else if (showGameoverScreen)
    {
        Raylib.ClearBackground(Color.RED);
        Raylib.DrawText("GAME OVER", 600, 400, 50, Color.GREEN);

    }
    else
    {
        // kör spelet

        // uppdatera svårighetsgrad efter ett antal stenar
        if (rockCount >= 10 && rockCount < 20)
        {
            game.currentDifficulty = Game.Difficulty.Medium;
        }
        else if (rockCount >= 20)
        {
            game.currentDifficulty = Game.Difficulty.Hard;
        }

        rockTimer -= Raylib.GetFrameTime();
        if (rockTimer <= 0)
        {
            rocks.Add(new Rock());
            rockTimer = rockTimerMax;
            rockCount++;
        }

        // Kolla om stenen krockar med missilen
        for (var i = 0; i < rocks.Count; i++)
        {
            Rock rock = rocks[i];

            if (Raylib.CheckCollisionCircleRec(m1.position, 10, rock.rect))
            {
                game.score++;
                rocks.RemoveAt(i);
            }

            if (rock.rect.y >= 750)
            {
                game.life--;
                rocks.RemoveAt(i);

            }

            if (game.life == 0)
            {
                showGameoverScreen = true;
            }
        }

        // uppdatera position för alla stenar
        foreach (Rock r in rocks)
        {
            r.Update(game.currentDifficulty);
            r.Draw();
        }

        //GRAFIK 
        Raylib.BeginDrawing();
        Raylib.ClearBackground(Color.BLACK);
        Raylib.DrawText($"Current Score:{game.score}", 50, 50, 20, Color.GREEN);
        Raylib.DrawText($"Current Life:{game.life}", 50, 80, 20, Color.GREEN);
        Raylib.DrawText($"Current Difficulty:{game.currentDifficulty}", 50, 110, 20, Color.GREEN);
        Raylib.DrawText($"Rock count:{rockCount}", 50, 140, 20, Color.GREEN);

        // missilen
        m1.Update();
        m1.Draw();

    }

    Raylib.EndDrawing();
}