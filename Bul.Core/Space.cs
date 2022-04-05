namespace Bul.Core;

/// <summary>
/// Represents a space on a lane
/// </summary>
public class Space
{
   private readonly Stack<Stone> _stones = new();

   [System.Text.Json.Serialization.JsonIgnore]
   [Newtonsoft.Json.JsonIgnore]
   public bool IsEmpty => !_stones.Any();

   [System.Text.Json.Serialization.JsonIgnore]
   [Newtonsoft.Json.JsonIgnore]
   public int Count => _stones.Count;

   [System.Text.Json.Serialization.JsonIgnore]
   [Newtonsoft.Json.JsonIgnore]
   public Stone Owner => IsEmpty ? Stone.None : _stones.Peek();

   [System.Text.Json.Serialization.JsonIgnore]
   [Newtonsoft.Json.JsonIgnore]
   public Stone Captured => Count > 1 ? _stones.ToList()[ 1 ] : Stone.None;

   [System.Text.Json.Serialization.JsonIgnore]
   [Newtonsoft.Json.JsonIgnore]
   public int OwnerCount => _stones.Count(s => s == Owner);

   [System.Text.Json.Serialization.JsonIgnore]
   [Newtonsoft.Json.JsonIgnore]
   public int CapturedCount => _stones.Count(s => s == Captured);

   public int GetStoneCount(Stone stone) => _stones.Count(s => s == stone); 
   
   public bool CanCapture(Stone stone)
   {
      if (stone == Stone.None)
         throw new ArgumentOutOfRangeException(nameof(stone));

      if (IsEmpty)
         return true;

      return stone != _stones.Peek();
   }

   public Space Capture(Stone stone)
   {
      if (stone == Stone.None)
         throw new ArgumentOutOfRangeException(nameof(stone));

      _stones.Push(stone);

      return this;
   }
}
