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
bool ShouldAddNewRock(float timerValue) // Bestämmer ifall ny rock ska läggas till
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

void AddNewRock() // lägger till en ny rock
{
    rocks.Add(new Rock());
    rockCount++;
}
void ResetRockTimer() // Startar om rock-timern
{
    rockTimer = rockTimerMax;
}


void UpdateEntities() // Uppdaterar alla entites, som missilen eller rocks
{
    m1.DoAll();
    foreach (Rock r in rocks)
    {
        r.DoAll(rocks, game, m1);
    }

}
while (Raylib.WindowShouldClose() == false)
{
    if (game.DecideScreen()) //Ifall DecideScreen är true så visas antingen Start- eller Gameover skärmen.
    {
        game.DecideScreen();
    }
    else
    {
        game.Update(rockCount); // Updaterar spelet, typ som att kolla liv eller difficulty
        UpdateEntities();
        rockTimer -= Raylib.GetFrameTime();
        if (ShouldAddNewRock(rockTimer))
        {
            AddNewRock();
            ResetRockTimer();
        }
        //GRAFIK 
        Raylib.BeginDrawing();
        game.DrawHUD(rockCount); // ritar HUD-en
    }
    Raylib.EndDrawing();
}