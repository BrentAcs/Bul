using Bul;

public static class PoC
{
   private const int MaxCol = 15;
   private const int ColWidth = 6;
   private const int MaxLane = 4;
   private const int LaneHeight = 3;

   private static readonly string Spaces = new string(' ', ColWidth - 1);
   private static readonly string Blocks = new string('\u2588', ColWidth - 1);

   // private static string GenEmptyCellText() =>
   //    $"{Spaces}{Environment.NewLine}{Spaces}{Environment.NewLine}{Spaces}";

   private static string GenEmptyCellText() =>
      $"[{Theme.Active.PlayerNoneColor}]{Blocks}[/]{Environment.NewLine}" +
      $"[{Theme.Active.PlayerNoneColor}]{Blocks}[/]{Environment.NewLine}" +
      $"[{Theme.Active.PlayerNoneColor}]{Blocks}[/]";

   private static string GenCellTextPlayerOne() =>
      $"{Spaces}{Environment.NewLine}" +
      $"{Spaces}{Environment.NewLine}" +
      $"[{Theme.Active.PlayerOneColor}]{Blocks}[/]";

   private static string GenCellTextPlayerTwo() =>
      $"{Spaces}{Environment.NewLine}" +
      $"{Spaces}{Environment.NewLine}" +
      $"[{Theme.Active.PlayerTwoColor}]{Blocks}[/]";

   private static string GenCellTextPlayerOneOwnTwo() =>
      $"{Spaces}{Environment.NewLine}" +
      $"[{Theme.Active.PlayerOneColor}]{Blocks}[/]{Environment.NewLine}" +
      $"[{Theme.Active.PlayerTwoColor}]{Blocks}[/]";

   private static string GenCellTextPlayerTwoOwnMultiple() =>
      $"[{Theme.Active.PlayerTwoColor}]{Blocks}[/]{Environment.NewLine}" +
      $"[{Theme.Active.PlayerOneColor}]\u2588\u25881\u2588\u2588[/]{Environment.NewLine}" +
      $"[{Theme.Active.PlayerTwoColor}]\u2588\u25881\u2588\u2588[/]";

   public static void ShowGameTable()
   {
      var laneTable = new Table()
         .Border(new NoTableBorder())
         .HideFooters();

      laneTable.AddColumn(new TableColumn($"").Width(3));
      for (int col = 0; col < MaxCol; col++)
      {
         laneTable.AddColumn(new TableColumn($"  {col + 1}  ").Width(ColWidth).Padding(new Padding(0)));
      }

      laneTable.AddEmptyRow();

      for (int lane = 0; lane < MaxLane; lane++)
      {
         var items = new List<IRenderable> {new Text($"{Environment.NewLine}{(char)(lane + 65)}")};
         for (int col = 0; col < MaxCol; col++)
         {
#if true
            switch (lane)
            {
               case 0 when col == 1:
                  items.Add(new Markup(GenCellTextPlayerOne()));
                  break;
               case 0 when col == 2:
                  items.Add(new Markup(GenCellTextPlayerTwo()));
                  break;
               case 0 when col == 3:
                  items.Add(new Markup(GenCellTextPlayerOneOwnTwo()));
                  break;
               case 0 when col == 4:
                  items.Add(new Markup(GenCellTextPlayerTwoOwnMultiple()));
                  break;
               default:
                  items.Add(new Markup(GenEmptyCellText()));
                  break;
            }
#else
            items.Add(new Markup(GenEmptyCellText()));
#endif
         }

         var row = new TableRow(items);
         laneTable.AddRow(row);

         laneTable.AddEmptyRow();
      }

      var mainTable = new Table()
            //.Width(98)
            .Width(MaxCol * ColWidth + 8)
            .Centered()
            .Border(Theme.Active.MainTableBorder)
            .BorderColor(Theme.Active.MainTableBorderColor)
            .AddColumn(new TableColumn("Bul - A Game of Bollocks").Centered())
            .AddRow(laneTable)
            .Caption("Some game status goes here")
         ;

      Console.OutputEncoding = System.Text.Encoding.Unicode;

      AnsiConsole.Write(mainTable);
   }
}
