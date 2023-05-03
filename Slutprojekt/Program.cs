using Raylib_cs;

//SKAPA SPELFÖNSTRET
//SKAPA LISTA FÖR ROCKS
//INSTANSERA GAME
//SKAPA MISSILEN
//SKAPA VARIABLER
//HÅLL KOLL PÅ SCORE, LIFE OSV.
//KOLLA KOLLISIONER
//KOLLA TID SEN START
//KOLLA NY STEN
//KÖRA SPEL
//KOLLA HUR MÅNGA LIV SOM ÄR KVAR
//VISA GAMEOVER FÖNSTER OM LIV = 0
//KOLLA KOLLISION MELLAN MISSIL OCH STEN
//TA BORT STEN IFALL KOLLIDERATA
Raylib.InitWindow(1200, 800, "Missile Command");
Raylib.SetTargetFPS(60);

// Håll koll på stenarna
// Anledningen till att detta är en lista, istället för en array är för att den
// ska kunna expanderas. En array har ett bestämt antal platser, men inte en lista.
List<Rock> rocks = new List<Rock>();
int rockCount = 0;

Game game = new Game();

// Missilen som användaren kontrollerar
Missile m1 = new Missile();

float rockTimer = 3f;
float rockTimerMax = 3f;

bool showStartScreen = true;
bool showGameoverScreen = false;

bool CheckCollision(Missile missile, Rock rock)
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



bool ShouldAddNewRock(float timerValue)
{
    if (timerValue <= 0)
    {
        return true;
    }
    else
    {
        return false;
    }
}

while (Raylib.WindowShouldClose() == false)
{
    if (showStartScreen)
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
        if (ShouldAddNewRock(rockTimer))
        {
            rocks.Add(new Rock());
            rockTimer = rockTimerMax;
            rockCount++;
        }



        // Kolla om Life = 0, isådanafall visar Game-Over -skärmen.
        if (game.life == 0)
        {
            showGameoverScreen = true;
        }

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
        Raylib.DrawText($"Time elapsed:{game.TimeSinceStart()}", 50, 170, 20, Color.GREEN);

        // Ritar och uppdaterar missilen och dess position
        m1.Update();
        m1.Draw();

    }

    Raylib.EndDrawing();
}