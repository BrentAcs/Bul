using Bul.Core;

namespace Bul.Rendering;

public static class LaneRenderer
{
   public static IRenderable Render(this Lane[] lanes)
   {
      var table = new Table()
         .Border(new NoTableBorder())
         .HideFooters();

      // add the columns
      table.AddColumn(new TableColumn($"").Width(3));
      for (int spaceIdx = 0; spaceIdx < lanes[0].Count; spaceIdx++)
      {
         table.AddColumn(new TableColumn($"  {spaceIdx + 1}  ").Width(RenderOptions.SpaceWidth).Padding(new Padding(0)));
      }

      // add the rows
      table.AddEmptyRow();

      for (int laneIdx = 0; laneIdx < lanes.Length; laneIdx++)
      {
         var lane = lanes[laneIdx];
         var items = new List<IRenderable> {new Text($"{Environment.NewLine}{(char)(laneIdx + 65)}")};
         for (int spaceIdx = 0; spaceIdx < lane.Count; spaceIdx++)
         {
            items.Add(lane[spaceIdx].Render());
         }

         var row = new TableRow(items);
         table.AddRow(row);
         table.AddEmptyRow();
      }

      return table;
   }
}
