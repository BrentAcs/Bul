using Bul.Core;
using Bul.Core.Extensions;
using Bul.Prompts;
using Bul.Rendering;

//PoC.ShowGameTable();
//PoC.TestSpaces();
//PoC.TestLanes();


var game = new Game(GameOptions.Default);
while (!game.IsGameOver())
{
   Console.Clear();
   AnsiConsole.Write(game.Render());

   var action = new TurnPrompt().Show(game);
   if (action == TurnAction.QuiteGame)
   {
      if (YesNoResponse.Yes == YesNoPrompt.Show())
         break;
   }

   if (action == TurnAction.Roll)
   {
      
   }
   
   game.NextTurn();
}

Console.WriteLine("Press any key to close.");
Console.ReadKey(true);
