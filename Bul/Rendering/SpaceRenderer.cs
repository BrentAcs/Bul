using Bul.Core;

namespace Bul.Rendering;

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
