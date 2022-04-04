namespace Bul.Core;

/// <summary>
/// Represents a lane of spaces
/// </summary>
public class Lane
{
   public Space[] Spaces { get; }

   public Lane(int spaceCount)
   {
      if (spaceCount < GameOptions.MinSpaceCount || spaceCount > GameOptions.MaxSpaceCount)
         throw new ArgumentOutOfRangeException(nameof(spaceCount));

      Spaces = new Space[spaceCount];
      for (int i = 0; i < spaceCount; i++)
         Spaces[i] = new Space();
   }

   public int Count => Spaces.Length;

   public Space this[int space] => Spaces[space];
}
