using Bul.Core;

namespace Bul;

public class Theme
{
   public static readonly Theme Default = new();
   public static Theme Active = Default;
   
   public class Defaults
   {
      public static readonly TableBorder MainTableBorder = TableBorder.DoubleEdge;
      public static readonly Color MainTableBorderColor = Color.DarkSlateGray1;

      public static readonly Color PlayerNoneColor = Color.Grey11;
      public static readonly Color PlayerOneColor = Color.Blue;
      public static readonly Color PlayerTwoColor = Color.Yellow;
      
      // public static readonly Style TableHeaderStyle = new Style(Color.Yellow, null, Decoration.Italic);
      // public static readonly Style TableLabelStyle = new Style(Color.LightSkyBlue1, null, Decoration.Italic);
      // public static readonly Style TableItemStyle = new Style(Color.LightGreen, null, Decoration.Italic);
   }

   public TableBorder MainTableBorder { get; set; } = Defaults.MainTableBorder;
   public Color MainTableBorderColor { get; set; } = Defaults.MainTableBorderColor;

   public Color PlayerNoneColor { get; set; } = Defaults.PlayerNoneColor;
   public Color PlayerOneColor { get; set; } = Defaults.PlayerOneColor;
   public Color PlayerTwoColor { get; set; } = Defaults.PlayerTwoColor;

   public Color GetPlayerColor(Stone stone)
   {
      switch (stone)
      {
         case Stone.None:
            return PlayerNoneColor;
         case Stone.PlayerOne:
            return PlayerOneColor;
         case Stone.PlayerTwo:
            return PlayerTwoColor;
         default:
            throw new ArgumentOutOfRangeException(nameof(stone), stone, null);
      }
   }
   
   // public Style TableHeaderStyle { get; set; } = Defaults.TableHeaderStyle;
   // public Style TableLabelStyle { get; set; } = Defaults.TableLabelStyle;
   // public Style TableItemStyle { get; set; } = Defaults.TableItemStyle;
}
