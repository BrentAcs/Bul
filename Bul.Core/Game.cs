namespace Bul.Core;

public class Game
{
   public GameOptions Options { get; }
   public int Turn { get; }
   public Lane[] Lanes { get; }
   public StoneInfo[] StoneInfos { get; }

   public Game(GameOptions options)
   {
      if (options.LaneCount < GameOptions.MinLaneCount || options.LaneCount > GameOptions.MaxLaneCount)
         throw new ArgumentOutOfRangeException(nameof(options.LaneCount));
      Options = options;
      Turn = 0;

      Lanes = new Lane[options.LaneCount];
      for (int i = 0; i < options.LaneCount; i++)
         Lanes[i] = new Lane(options.SpaceCount);

      StoneInfos = new[]
      {
         new StoneInfo {ActiveStoneCount = options.StoneCount, KilledStoneCount = 0},
         new StoneInfo {ActiveStoneCount = options.StoneCount, KilledStoneCount = 0}
      };
   }

   public StoneInfo GetStoneInfo(Stone stone) => StoneInfos[(int)stone-1];
}

public class StoneInfo
{
   public int ActiveStoneCount { get; set; }

   public int KilledStoneCount { get; set; }
   //public int OnBoardStoneCount { get; set; }
}
