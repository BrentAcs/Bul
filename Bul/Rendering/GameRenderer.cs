using Bul.Core;

namespace Bul.Rendering;

public static class GameRenderer
{
   public static IRenderable Render(this Game game)
   {
      var table = new Table()
         .Width(game.Lanes[ 0 ].Count * RenderOptions.SpaceWidth + 8)
         .Centered()
         .Border(Theme.Active.MainTableBorder)
         .BorderColor(Theme.Active.MainTableBorderColor)
         .AddColumn(new TableColumn("[b]Bul - A Game of Bollocks[/]").Centered())
         .AddRow(game.Lanes.Render())
         .Caption(GetCaption(game));

      return table;
   }

   private static string GetCaption(Game game)
   {
      //    color     white     white     green     red
      //  Player 1: Initial / Reserve / OnBoard / Killed

      var ctx1 = game.GetPlayerContext(Stone.PlayerOne);
      var ctx2 = game.GetPlayerContext(Stone.PlayerTwo);

      return $"{GetPlayerCaption(ctx1, Theme.Active.PlayerOneColor)} -V- {GetPlayerCaption(ctx2, Theme.Active.PlayerTwoColor)}";
   }

   private static string GetPlayerCaption(PlayerContext ctx, Color color) =>
      $"[{color}]Player[/]: [white]{ctx.InitialStoneCount}[/] / [white]{ctx.ReserveStoneCount}[/] / [green]{ctx.OnBoardStoneCount}[/] / [red]{ctx.KilledStoneCount}[/]";
}
