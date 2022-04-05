namespace Bul.Core;

/// <summary>
/// Represents a lane of spaces
/// </summary>
public class Lane
{
   private readonly Space[] _spaces;

   public Lane(int spaceCount)
   {
      if (spaceCount < GameOptions.MinSpaceCount || spaceCount > GameOptions.MaxSpaceCount)
         throw new ArgumentOutOfRangeException(nameof(spaceCount));

      _spaces = new Space[spaceCount];
      for (int i = 0; i < spaceCount; i++)
         _spaces[i] = new Space();
   }

   public int Count => _spaces.Length;

   public Space this[int space] => _spaces[space];

   public int GetStoneCount(Stone stone) =>
      _spaces.Sum(s => s.GetStoneCount(stone));
}
