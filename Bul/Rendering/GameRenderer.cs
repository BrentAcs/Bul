using Bul.Core;

namespace Bul.Rendering;

public static class GameRenderer
{
   public static IRenderable Render(this Game game)
   {
      //game.GetStoneInfo(Stone.PlayerOne).ActiveStoneCount;
      //game.GetStoneInfo(Stone.PlayerOne).KilledStoneCount;

      //    color    white     green     red
      //  Player 1: Reserve / OnBoard / Killed

      var caption = "[blue]a caption[/]";


      var table = new Table()
         .Width(game.Lanes[0].Count * RenderOptions.SpaceWidth + 8)
         .Centered()
         .Border(Theme.Active.MainTableBorder)
         .BorderColor(Theme.Active.MainTableBorderColor)
         .AddColumn(new TableColumn("[b]Bul - A Game of Bollocks[/]").Centered())
         .AddRow(game.Lanes.Render())
         .Caption(caption);

      return table;
   }
}
