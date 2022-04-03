using Bul;
using Bul.Core;
using Bul.Core.Extensions;

//PoC.ShowGameTable();
//var options = new GameOptions();

var spaces = new List<Space>
{
   new Space(),
   new Space()
      .Capture(Stone.PlayerOne),
   new Space()
      .Capture(Stone.PlayerTwo),
   new Space()
      .Capture(Stone.PlayerOne)
      .Capture(Stone.PlayerTwo),
   new Space()
      .Capture(Stone.PlayerOne)
      .Capture(Stone.PlayerTwo)
      .Capture(Stone.PlayerOne),
   new Space()
      .Capture(Stone.PlayerOne)
      .Capture(Stone.PlayerTwo)
      .Capture(Stone.PlayerOne)
      .Capture(Stone.PlayerTwo)
      .Capture(Stone.PlayerOne)
};

foreach (var space in spaces)
{
   AnsiConsole.Write(space.Render());
   Console.WriteLine();
   Console.WriteLine();
}

//Console.WriteLine($"{Environment.NewLine}{Environment.NewLine}{spaces.AsJsonIndented()}");

Console.WriteLine("Press any key to close.");
Console.ReadKey(true);

public static class Renderer
{
}

public static class SpaceRenderer
{
   private const int ColWidth = 6;

   private static readonly string Blocks = new string('\u2588', ColWidth - 1);

   public static IRenderable Render(this Space space)
   {
      if (space.IsEmpty)
      {
         return new Markup($"[{Theme.Active.PlayerNoneColor}]{Blocks}[/]{Environment.NewLine}" +
                           $"[{Theme.Active.PlayerNoneColor}]{Blocks}[/]{Environment.NewLine}" +
                           $"[{Theme.Active.PlayerNoneColor}]{Blocks}[/]");
      }

      if (space.Count == 1)
      {
         return new Markup($"[{Theme.Active.PlayerNoneColor}]{Blocks}[/]{Environment.NewLine}" +
                           $"[{Theme.Active.PlayerNoneColor}]{Blocks}[/]{Environment.NewLine}" +
                           $"[{Theme.Active.GetPlayerColor(space.Owner)}]{Blocks}[/]");
      }

      if (space.Count == 2)
      {
         return new Markup($"[{Theme.Active.PlayerNoneColor}]{Blocks}[/]{Environment.NewLine}" +
                           $"[{Theme.Active.GetPlayerColor(space.Owner)}]{Blocks}[/]{Environment.NewLine}" +
                           $"[{Theme.Active.GetPlayerColor(space.Captured)}]{Blocks}[/]");
      }

      return new Markup($"[{Theme.Active.PlayerNoneColor}]{Blocks}[/]{Environment.NewLine}" +
                        $"[{Theme.Active.GetPlayerColor(space.Owner)}]\u2588\u2588{space.OwnerCount:D2}\u2588[/]{Environment.NewLine}" +
                        $"[{Theme.Active.GetPlayerColor(space.Captured)}]\u2588\u2588{space.CapturedCount:D2}\u2588[/]");
   }
}
