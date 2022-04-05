using Bul.Core;
using Bul.Rendering;

namespace Bul.Proofs;

public static partial class PoC
{
   public static void TestLanes()
   {
      var lane = new Lane(9);
      lane[1].Capture(Stone.PlayerOne).Capture(Stone.PlayerTwo);

      var laneTable = new Table()
         .Border(new NoTableBorder())
         .HideFooters();

      laneTable.AddColumn(new TableColumn($"").Width(3));
      for (int col = 0; col < lane.Count; col++)
      {
         laneTable.AddColumn(new TableColumn($"  {col + 1}  ").Width(PoC.ColWidth).Padding(new Padding(0)));
      }

      laneTable.AddEmptyRow();


      // for (int row = 0; row < MaxLane; lane++)
      // {
      var items = new List<IRenderable> {new Text($"{Environment.NewLine}{(char)(0 + 65)}")};
      for (int col = 0; col < lane.Count; col++)
      {
         items.Add(lane[col].Render());
      }

      var row = new TableRow(items);
      laneTable.AddRow(row);

      laneTable.AddEmptyRow();
      // }


      AnsiConsole.Write(laneTable);

      //Console.WriteLine($"{Environment.NewLine}{Environment.NewLine}{lane.AsJsonIndented()}");
   }
}
