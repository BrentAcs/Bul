namespace Bul.Core;

public class Game
{
   private Lane[] _lanes;
   private PlayerContext[] _playerContexts;

   public Game(GameOptions options)
   {
      New(options);
   }

   public Lane[] Lanes => _lanes;
   public GameOptions Options { get; private set; }
   public int Turn { get; private set; }
   public Stone CurrentPlayer { get; private set; } = Stone.None;
   public Lane this[int lane] => _lanes[ lane ];

   public void New(GameOptions options)
   {
      if (options.LaneCount < GameOptions.MinLaneCount || options.LaneCount > GameOptions.MaxLaneCount)
         throw new ArgumentOutOfRangeException(nameof(options.LaneCount));
      Options = options;
      Turn = 0;
      CurrentPlayer = Stone.PlayerOne;

      _lanes = new Lane[ options.LaneCount ];
      for (int i = 0; i < options.LaneCount; i++)
         _lanes[ i ] = new Lane(options.SpaceCount);

      _playerContexts = new[]
      {
         new PlayerContext
         {
            InitialStoneCount = options.StoneCount,
            ReserveStoneCount = options.StoneCount,
            OnBoardStoneCount = 0,
            KilledStoneCount = 0
         },
         new PlayerContext
         {
            InitialStoneCount = options.StoneCount,
            ReserveStoneCount = options.StoneCount,
            OnBoardStoneCount = 0,
            KilledStoneCount = 0
         }
      };
   }

   public void NextTurn()
   {
      CurrentPlayer = CurrentPlayer == Stone.PlayerOne ? Stone.PlayerTwo : Stone.PlayerOne;
   }

   public bool IsGameOver() => false;

   public PlayerContext GetPlayerContext(Stone stone) => _playerContexts[ (int)stone - 1 ];

   public int GetStoneCount(Stone stone) =>
      _lanes.Sum(s => s.GetStoneCount(stone));
}

public class PlayerContext
{
   public int InitialStoneCount { get; set; }

   public int ReserveStoneCount { get; set; }

   public int OnBoardStoneCount { get; set; }

   public int KilledStoneCount { get; set; }
}
