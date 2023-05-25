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

void AddNewRock()
{
    rocks.Add(new Rock());
    rockCount++;
}
void ResetRockTimer()
{
    rockTimer = rockTimerMax;
}


void UpdateEntities()
{
    m1.DoAll();
    foreach (Rock r in rocks)
    {
        r.DoAll(rocks, game, m1);
    }

}
while (Raylib.WindowShouldClose() == false)
{
    if (game.DecideScreen())
    {
        game.DecideScreen();
    }
    else
    {
        game.Update(rockCount);
        UpdateEntities();
        rockTimer -= Raylib.GetFrameTime();
        if (ShouldAddNewRock(rockTimer))
        {
            AddNewRock();
            ResetRockTimer();
        }
        //GRAFIK 
        Raylib.BeginDrawing();
        game.DrawHUD(rockCount);
    }
    Raylib.EndDrawing();
}