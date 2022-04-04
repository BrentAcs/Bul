using Bul.Core;
using Bul.Rendering;

//PoC.ShowGameTable();
//PoC.TestSpaces();
//PoC.TestLanes();
var game = new Game(GameOptions.Default);

AnsiConsole.Write(game.Render());

#if false
Console.WriteLine($"{Environment.NewLine}{Environment.NewLine}{game.AsJsonIndented()}");
#endif

Console.WriteLine("Press any key to close.");
Console.ReadKey(true);
