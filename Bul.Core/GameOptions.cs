namespace Bul.Core;

public class GameOptions
{
   /// <summary>
   /// Number of lanes in a game, default is 1.
   /// Maximum is 4
   /// </summary>
   public int LaneCount { get; set; } = 1;

   /// <summary>
   /// Number of spaces in lane, default is 9.
   /// Minimum is 7, maximum is 15
   /// </summary>
   public int SpaceCount { get; set; } = 9;

   /// <summary>
   /// Number of 'stones' per side, default is 5.
   /// Minimum is 5, Maximum is 10 times lane count 
   /// </summary>
   public int StoneCount { get; set; } = 5;
}
