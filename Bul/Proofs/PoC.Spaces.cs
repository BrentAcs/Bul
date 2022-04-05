using Bul.Core;
using Bul.Core.Extensions;
using Bul.Rendering;

namespace Bul.Proofs;

public static partial class PoC
{
   public static void TestSpaces()
   {
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

      Console.WriteLine($"{Environment.NewLine}{Environment.NewLine}{spaces.AsJsonIndented()}");
   }
}
